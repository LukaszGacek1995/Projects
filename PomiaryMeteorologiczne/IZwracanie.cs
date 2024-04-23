using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiaryMeteorologiczne
{
    internal interface IZwracanie
    {
        public string WynikWartoscString();
        public Tuple<int, int, double> WynikWartoscTuple(int x, int y, int z);
        public Tuple<int, int, double> WartosciWynik { get; }
    }
}
