using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeJePecat
{
    public class Stamp
    {
        public string FileName { get; set; } //unique in folder + no.
        public int X { get; set; } //coordinates
        public int Y { get; set; }
        public StampState State { get; set; }

    }
}
