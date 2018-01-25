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
    internal class MatchingTemplateAlgorithm : IAlgorithm
    {
        public Stamp LocateStamp(string path)
        {
            throw new NotImplementedException();
        }

        public List<Stamp> LocateStamp(string path, string destinationFolder)
        {
            throw new NotImplementedException();
        }

        public List<Stamp> Start(string[] sourceImageFilePaths, string destinationFolder)
        {
            List<Stamp> dummyCustom = new List<DeJePecat.Stamp>();
            dummyCustom.Add(new Stamp() { FileName = "Slika 2", X = 105, Y = 1000 });
            dummyCustom.Add(new Stamp() { FileName = "Slika 2", X = 204, Y = 2000 });
            dummyCustom.Add(new Stamp() { FileName = "Slika 2", X = 303, Y = 3000 });
            dummyCustom.Add(new Stamp() { FileName = "Slika 2", X = 406, Y = 4000 });
            dummyCustom.Add(new Stamp() { FileName = "Slika 2", X = 508, Y = 5000 });
            dummyCustom.Add(new Stamp() { FileName = "Slika 2", X = 609, Y = 6000 });
            dummyCustom.Add(new Stamp() { FileName = "Slika 2", X = 706, Y = 7000 });
            dummyCustom.Add(new Stamp() { FileName = "Slika 2", X = 1060, Y = 100 });

            Thread.Sleep(2010);
            return dummyCustom;
        }
    }
}