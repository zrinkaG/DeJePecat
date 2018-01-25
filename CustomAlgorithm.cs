using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace DeJePecat
{
    internal class CustomAlgorithm : IAlgorithm
    {

        private static string _kernelPath = @"D:\FESB\Studij\Pecati\TheTemplate.png";
        private int _kernelRows;
        private int _kernelCols;
        int[] blackPixelsX, blackPixelsY, whitePixelsX, whitePixlesY;
        int counterBlackPixels, counterWhitePixels;
        int rX, rY, minX, minY, maxX, maxY;
        byte[] _kernelData;
        byte[] _orignalData;
        private int _originalImageRows;
        private int _originalImageCols;

        private const int WHITE_BOUND = 245;
        private const int BLACK_BOUND = 10;
        private const int STEP_PIXELS = 10;

        int stampProcedureExecutedCounter;


        public List<Stamp> Start(string[] sourceImageFilePaths, string destinationFolder)
        {
            LoadKernelImage();
            stampProcedureExecutedCounter = 0;

            List<Stamp> matchingTemplateStamps = new List<DeJePecat.Stamp>();
            CalculateKernelCoordinates();

            foreach (string path in sourceImageFilePaths)
            {
                LoadOriginalImage(path);
                matchingTemplateStamps.AddRange(LocateStamp(path, destinationFolder));
            }

            DisposeObjects();
            return matchingTemplateStamps;

        }

        private void DisposeObjects()
        {
            blackPixelsX = null;
            blackPixelsY = null;
            whitePixelsX = null;
            whitePixlesY = null;

            _kernelData = null;
            _orignalData = null;

        }

        private void LoadKernelImage()
        {
            Mat kernelImage = new Mat(_kernelPath, LoadImageType.Grayscale);

            _kernelRows = kernelImage.Rows;
            _kernelCols = kernelImage.Cols;

            _kernelData = new byte[kernelImage.Width * kernelImage.Height];
            GCHandle handle = GCHandle.Alloc(_kernelData, GCHandleType.Pinned);

            Mat tempMat = new Mat(kernelImage.Size, DepthType.Cv8U, 1);
            tempMat.SetTo(new MCvScalar(255));


            using (Mat m2 = new Mat(kernelImage.Size, DepthType.Cv8U, 1, handle.AddrOfPinnedObject(), kernelImage.Width))
                CvInvoke.BitwiseAnd(tempMat, kernelImage, m2);

            handle.Free();
            kernelImage.Dispose();
            tempMat.Dispose();


        }

        private void LoadOriginalImage(string path)
        {
            Mat originalImage = new Mat(path, LoadImageType.Grayscale);
            _originalImageCols = originalImage.Cols;
            _originalImageRows = originalImage.Rows;

            Mat tempMat = new Mat(originalImage.Size, DepthType.Cv8U, 1);
            tempMat.SetTo(new MCvScalar(255));

            _orignalData = new byte[originalImage.Width * originalImage.Height];
            GCHandle handle = GCHandle.Alloc(_orignalData, GCHandleType.Pinned);

            using (Mat m2 = new Mat(originalImage.Size, DepthType.Cv8U, 1, handle.AddrOfPinnedObject(), originalImage.Width))
                CvInvoke.BitwiseAnd(tempMat, originalImage, m2);

            handle.Free();
            originalImage.Dispose();
            tempMat.Dispose();


        }
        public List<Stamp> LocateStamp(string path, string destinationFolder)
        {
            stampProcedureExecutedCounter++;

            List<Stamp> stamps = new List<Stamp>();
            Mat originalImage = new Mat(path, LoadImageType.Grayscale);

            Mat originalWV = new Mat(originalImage.Rows, originalImage.Cols, DepthType.Cv8U, 1);
            originalImage.Dispose();

            Image<Gray, Byte> image = new Image<Gray, byte>(path);


            int originalWvRows = originalWV.Rows;
            int originalWvCols = originalWV.Cols;

            SimulateApplyingKernel(originalWV, originalWvRows, originalWvCols, stamps, destinationFolder);
            foreach (var currentStamp in stamps)
            {
                var extractedStamp = Utility.GetImageRoiFromCorner(image, currentStamp.X, currentStamp.Y, _kernelRows);
                extractedStamp.Save(currentStamp.FileName);
            }

            image.Dispose();
            originalImage.Dispose();
            originalWV.Dispose();

            return stamps;
        }
        void SimulateApplyingKernel(Mat originalWV, int originalWVRows, int originalWVCols, List<Stamp> stamps, string destinationFolder)
        {
            int i, j;


            int stepRows = STEP_PIXELS;
            int stepCols = STEP_PIXELS;


            for (i = 0; i + _kernelRows < originalWVRows; i += stepRows)
            {
                for (j = 0; j + _kernelCols < originalWVCols; j += stepCols)
                {
                    if (!IsTextAreaPredicted2(i, j, originalWV))
                    {
                        if (IsStampLocated(i, j))
                        {
                            string saveTo = Path.Combine(destinationFolder, "Custom algorithm-" + Guid.NewGuid().ToString() + "_CUT.jpg");
                            stamps.Add(new DeJePecat.Stamp() { X = i, Y = j, FileName = saveTo });

                            i += _kernelRows;
                            j += _kernelCols;
                        }
                    }
                    else
                    {
                        i += _kernelRows;
                        j += _kernelCols;
                    }
                }
            }
        }

        bool IsTextAreaPredicted2(int x, int y, Mat image)
        {

            //Promijeniti na raspored, ne samo aritmeticku sredinu!
            int densityThreshold = 245;
            int i, j, m, n;

            float density;
            int sum = 0;

            int quadrantCounter = 0;
            int quadrantRows, quadrantCols;
            int quadrantSize = 3; //svaku dimenziju dijelimo s quadrantSize;


            quadrantRows = _kernelRows / quadrantSize;
            quadrantCols = _kernelCols / quadrantSize;

            int debugValue = 0;

            //byte[] imageData = image.GetData();

            if (x + _kernelRows > image.Rows || y + _kernelCols > image.Cols)
                return false;

            int imageCols = image.Cols;

            for (i = 0; i + quadrantRows < _kernelRows; i += quadrantRows)
            {
                for (j = 0; j + quadrantCols < _kernelCols; j += quadrantCols)
                {
                    sum = 0;
                    for (m = 0; m < quadrantRows; m++)
                    {
                        for (n = 0; n < quadrantCols; n++)
                        {
                            debugValue = _orignalData[(i + x + m) * imageCols + (j + y + n)];
                            sum += debugValue;

                        }
                    }
                    density = (float)sum / (quadrantRows * quadrantCols);

                    if (density < densityThreshold)
                        quadrantCounter++;
                }
            }
            if (quadrantCounter > (quadrantSize * quadrantSize - (int)quadrantSize * 0.33))//todo koef
                return true;

            return false;
        }
        bool IsStampLocated(int x, int y)
        {
            bool isApplied = false;
            int originalValue;

            int[] quadrantCounterBlack = new int[4] { 0, 0, 0, 0 };
            int[] quadrantCounterWhite = new int[4] { 0, 0, 0, 0 };

            for (int i = 0; i < counterBlackPixels; i++)
            {
                if ((blackPixelsX[i] + x) * _originalImageCols + blackPixelsY[i] + y >= _orignalData.Length)
                    return false;

                    originalValue = _orignalData[(blackPixelsX[i] + x) * _originalImageCols + blackPixelsY[i] + y];
                //originalValue = MatValues.GetDoubleValue(originalImage, blackPixelsX[i] + x, blackPixelsY[i] + y);

                if (originalValue < BLACK_BOUND)
                    quadrantCounterBlack[quadrantIndex(blackPixelsX[i], blackPixelsY[i])]++;
            }

            for (int i = 0; i < counterWhitePixels; i++)
            {
                if ((whitePixelsX[i] + x) * _originalImageCols + whitePixlesY[i] + y >= _orignalData.Length)
                    return false;

                originalValue = _orignalData[(whitePixelsX[i] + x) * _originalImageCols + whitePixlesY[i] + y];

                //originalValue = MatValues.GetDoubleValue(originalImage,whitePixelsX[i] + x, whitePixlesY[i] + y);

                if (originalValue > WHITE_BOUND)
                    quadrantCounterWhite[quadrantIndex(whitePixelsX[i], whitePixlesY[i])]++;
            }

            int qCounterBlack = 0;
            int qCounterWhite = 0;
            for (int i = 0; i < 4; i++)
            {
                if (quadrantCounterBlack[i] > 20)
                    qCounterBlack++;

                if (quadrantCounterWhite[i] > 200)
                    qCounterWhite++;
            }

            //if ((float)numOfBlackPixelsOriginalImage/counterBlackPixels > 0.5 && (float)numOfWhitePixelsOriginalImage/counterWhitePixels > 0.5)
            if (qCounterBlack > 3 && qCounterWhite > 3)
            {
                isApplied = true;
            }
            return isApplied;
        }


        void CalculateKernelCoordinates()
        {
            int tempMinX, tempMinY;

            int i, j;
            int debugValue;

            counterBlackPixels = 0;
            counterWhitePixels = 0;

            for (i = 0; i < _kernelRows; i++)
            {
                for (j = 0; j < _kernelCols; j++)
                {
                    debugValue = _kernelData[i * _kernelCols + j];
                    if (debugValue < BLACK_BOUND)
                        counterBlackPixels++;
                    else if (debugValue > WHITE_BOUND)
                        counterWhitePixels++;
                }
            }

            blackPixelsX = new int[counterBlackPixels];
            blackPixelsY = new int[counterBlackPixels];
            whitePixelsX = new int[counterWhitePixels];
            whitePixlesY = new int[counterWhitePixels];

            int counterBlackTemp = 0;
            int counterWhiteTemp = 0;

            tempMinX = _kernelRows - 1;
            tempMinY = _kernelCols - 1;

            for (i = 0; i < _kernelRows; i++)
            {
                for (j = 0; j < _kernelCols; j++)
                {
                    debugValue = _kernelData[i * _kernelCols + j];
                    if (debugValue < BLACK_BOUND)
                    {
                        blackPixelsX[counterBlackTemp] = i;
                        blackPixelsY[counterBlackTemp] = j;
                        counterBlackTemp++;
                    }
                    else if (debugValue > WHITE_BOUND)
                    {
                        whitePixelsX[counterWhiteTemp] = i;
                        whitePixlesY[counterWhiteTemp] = j;
                        counterWhiteTemp++;
                    }
                }
            }

            minX = blackPixelsX[0];
            maxX = blackPixelsX[0];
            minY = blackPixelsY[0];
            maxY = blackPixelsY[0];

            for (i = 0; i < counterBlackPixels; i++)
            {
                if (minX > blackPixelsX[i])
                    minX = blackPixelsX[i];

                if (maxX < blackPixelsX[i])
                    maxX = blackPixelsX[i];
            }

            for (i = 0; i < counterBlackPixels; i++)
            {
                if (minY > blackPixelsY[i])
                    minY = blackPixelsY[i];

                if (maxY < blackPixelsY[i])
                    maxY = blackPixelsY[i];
            }

            rX = (maxX - minX) / 2;
            rY = (maxY - minY) / 2;


        }
        int quadrantIndex(int x, int y)
        {
            if (x > rX && y < rY)
                return 0;
            if (x > rX && y > rY)
                return 3;
            if (x < rX && y < rY)
                return 2;
            else
                return 1;
        }

    }
}