using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiaryMeteorologiczne
{
    internal interface IZasilanie
    {
        public void WprowadzDane();
        public Dictionary<int, int> SlownikWprowadzonychWartosci { get; set; }
    }
}
