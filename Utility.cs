using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using System.Linq;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Diagnostics;

namespace DeJePecat
{
    public enum StampState
    {
        NotProccesed,
        TP,
        FP,
        FN,
        Matched,
        NotMatched
    }
    public static class Utility
    {
        public static string[] GetImageFilePaths(string sourceFolder)
        {
            return Directory.GetFiles(sourceFolder, "*.jpg", SearchOption.AllDirectories);
        }

        public static void Serialize(List<Stamp> stamps, string destFolder, string guid, string algorithmName, long duration)
        {
          string serialized = JsonConvert.SerializeObject(stamps, Formatting.Indented);
          File.WriteAllText(Path.Combine(destFolder, algorithmName + "-" + guid + "_#"+ duration.ToString() + "#.json"), serialized);
        }

        internal static void MakeJson(String sourceFolder)
        {
            var csvFiles = Directory.GetFiles(sourceFolder, "*.csv", SearchOption.AllDirectories);

            List<Stamp> stampsInAllCsvs = new List<Stamp>();

            foreach (string file in csvFiles)
            {
                List<Stamp> currStamps = GetStampsFromFile(file);
                stampsInAllCsvs.AddRange(currStamps);
            }

            Serialize(stampsInAllCsvs, sourceFolder, Guid.NewGuid().ToString(), "LABLED STAMPS", 0);
        }

        private static List<Stamp> GetStampsFromFile(string file)
        {
            string[] lines = File.ReadAllLines(file);

            
            List<Stamp> stamps = new List<Stamp>();
           for(int i = 1; i < lines.Length; i++)
            {
                if(lines[i].Contains("pecat"))
                {
                    string[] data = lines[i].Split(',');

                    Stamp currStamp = new Stamp();
                    var indexOfSeparator = data[1].LastIndexOf(':');
                    currStamp.FileName = data[1].Substring(0, indexOfSeparator);

                    int offsetsX = Int32.Parse(data[4]) / 2;
                    int offsetsY = Int32.Parse(data[5]) / 2;

                    currStamp.X = Int32.Parse(data[2]) + offsetsX;
                    currStamp.Y = Int32.Parse(data[3]) + offsetsY;

                    stamps.Add(currStamp);
                }
            }
            return stamps;
        }

        public static List<Stamp> Deserialize(string path)
        {
            string serialized = File.ReadAllText(path);
            List<Stamp> stamps = JsonConvert.DeserializeObject<List<Stamp>>(serialized);
            return stamps;
        }

        public static void CompareResults(List<Stamp> labeled, List<Stamp> counted, string labeledFilePath, string countedFilePath, string resultPath)
        {

            string resultMessage = String.Empty;

            #region Messages
            resultMessage += "Labeled stamps from: " + labeledFilePath + Environment.NewLine;
            resultMessage += "Counted stamps from: " + countedFilePath + Environment.NewLine;
            resultMessage += Environment.NewLine;
            resultMessage += "Number of labeled stamps:" + labeled.Count.ToString() + Environment.NewLine;
            resultMessage += "Number of counted stamps:" + counted.Count.ToString() + Environment.NewLine;
            resultMessage += Environment.NewLine;
            #endregion

            labeled.ForEach(a => a.State = StampState.NotProccesed);

            foreach (var itemC in counted)
            {
                var sameName = labeled.Where(x => x.FileName.Equals(itemC.FileName) && (x.State == StampState.NotProccesed || x.State == StampState.NotMatched)).ToList();
                if(sameName.Count == 0)
                {
                    itemC.State = StampState.FP;
                    continue;
                }
              
                labeled.Where(x => x.FileName.Equals(itemC.FileName) && (x.State == StampState.NotProccesed || x.State == StampState.NotMatched)).ToList().ForEach(a => a.State = StampState.NotMatched);

                bool matchFound = false;
                foreach (var itemL in sameName)
                {
                    if(CompareResults(itemC, itemL))
                    {
                        itemL.State = StampState.Matched;
                        itemC.State = StampState.TP;
                        matchFound = true;
                    }
                   
                }

                if(!matchFound)
                {
                    itemC.State = StampState.FP;
                    
                }
            }

            int fn = labeled.Where(x => x.State == StampState.NotMatched || x.State == StampState.NotProccesed).Count();
            int tp = counted.Where(x => x.State == StampState.TP).Count();
            int fp = counted.Where(x => x.State == StampState.FP).Count();
            int test = labeled.Where(x => x.State == StampState.Matched).Count();

            #region Messages
            resultMessage += "TP = " + tp.ToString() + Environment.NewLine;
            resultMessage += "FP = " + fp.ToString() + Environment.NewLine;
            resultMessage += "FN = " + fn.ToString() + Environment.NewLine;
            resultMessage +=  Environment.NewLine;
            #endregion

            Debug.WriteLine("FN" + String.Join("#", labeled.Where(x => x.State == StampState.NotMatched || x.State == StampState.NotProccesed).Select(x => x.FileName)));
            if ((tp + fp + fn) == 0)
            {
                resultMessage += "tp + fp + fn = 0! Something went terribly wrong!" + Environment.NewLine;
            }
            else
            {
                double Fm = (double)(2 * tp) / (2 * tp + fp + fn);
                resultMessage += "RESULT Fm = " + String.Format("{0:0.00}",Fm) + Environment.NewLine;
            }
            File.WriteAllText(resultPath, resultMessage);
        }

        internal static Image<Gray, byte> GetImageRoiFromCenter(Image<Gray, byte> image, int x, int y, int imageWidth, int previewWidth, int imageHeight, int previewHeight, out int ix, out int iy, int size)
        {
            int roiX, roiY;
            roiX = size;
            roiY = size;

            double coefX = (imageWidth / (double)(previewWidth));
            double coefY = (imageHeight / (double)(previewHeight));

            Size stampSize = new Size((int)(roiX * 2 * coefX), (int)(roiY * 2 * coefY));
            image.ROI = new Rectangle(new Point((int)((x- roiX) * coefX), (int)((y- roiY) * coefY)), stampSize);
            Image<Gray, Byte> cut = new Image<Gray, byte>(stampSize);
            cut = image.Clone();

            ix = (int)(x * coefX);
            iy = (int)(y * coefY);

            return cut;
        }
        internal static Image<Gray, byte> GetImageRoiFromCorner(Image<Gray, byte> image, int x, int y, int size)
        {

            Size stampSize = new Size(size,size);
            image.ROI = new Rectangle(new Point(y,x), stampSize);
            Image<Gray, Byte> cut = new Image<Gray, byte>(stampSize);
            cut = image.Clone();         

            return cut;
        }

        private static bool CompareResults(Stamp counted, Stamp labeled)
        {
            double dozvoljeniPostotak = 0.02;

                //if (labeled.X >= counted.X - (int)(counted.X * dozvoljeniPostotak) && labeled.X <= counted.X + (int)(counted.X * dozvoljeniPostotak) &&
                //    labeled.Y >= counted.Y - (int)(counted.Y * dozvoljeniPostotak) && labeled.Y <= counted.Y + (int)(counted.Y * dozvoljeniPostotak))
                //    return true;
            if (Math.Abs(labeled.X - counted.X) <= 50 && Math.Abs(labeled.Y - counted.Y) <= 50)
                return true;

            return false;
        }
    }
}