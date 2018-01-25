using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeJePecat
{
    public interface IAlgorithm
    {
        List<Stamp> Start(string[] sourceImageFilePaths, string destinationFolder);
        List<Stamp> LocateStamp(string path, string destinationFolder);

    }
}
