using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace DeJePecat
{
    internal class HoughAlgorithm : IAlgorithm
    {
        

        public List<Stamp> Start(string[] sourceImageFilePaths, string destinationFolder)
        {
            List<Stamp> houghAlgorithm = new List<DeJePecat.Stamp>();
       
            foreach(string path in sourceImageFilePaths)
            {
                houghAlgorithm.AddRange(LocateStamp(path, destinationFolder));
            }
            
            return houghAlgorithm;

        }

        public List<Stamp> LocateStamp(string path, string destinationFolder)
        {
            Image<Gray, Byte> image = new Image<Gray, byte>(path);
            List<Stamp> stamps = new List<Stamp>();

            CvInvoke.MedianBlur(image, image, 5);
            //CircleF[] circles = CvInvoke.HoughCircles(image, HoughType.Gradient, 1.5, 500, 100, 100, 90, 150);
            CircleF[] circles = CvInvoke.HoughCircles(image, HoughType.Gradient, 3.15, 400, 100, 330, 40, 160);

            FileInfo fi = new FileInfo(path);
            
            int i = 0;
            foreach (CircleF circle in circles)
            {
                Stamp stamp = new DeJePecat.Stamp();
                string saveTo = Path.Combine(destinationFolder, "HoughesAlgorithm_" + fi.Name + "#" + Guid.NewGuid().ToString()  + ".jpg");

                stamp.FileName = fi.Name;
                stamp.X = (int)circle.Center.X;
                stamp.Y = (int)circle.Center.Y;

                stamps.Add(stamp);
                int ix, iy;

                var extractedStamp = Utility.GetImageRoiFromCenter(image, (int)circle.Center.X, (int)circle.Center.Y, image.Width, image.Width, image.Height,  image.Height, out ix, out iy, 150);
                extractedStamp.Save(saveTo);
                i++;
            }

            return stamps;
        }
    }
}