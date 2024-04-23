using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiaryMeteorologiczne
{
    internal abstract class ObliczanieKlasaBase
    {
        internal abstract Tuple<double, double, double, float>  WyliczanieWartosci();
    }
}
