using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiaryMeteorologiczne
{
    internal class WprowadzanieKlasaBase
    {
        internal virtual Dictionary<int, int> ZasilanieDanymi()
        {
            Console.WriteLine("Wprowadż dane ");

            return null;
        }
    }
}
