using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PomiaryMeteorologiczne
{
    internal class ZwracanieKlasaBase
    {
        public virtual string ZwracanieBarkuDanych()
        {
            return "BRAK DANYCH";
        }

        public virtual Tuple<double, double, double> ZwracanieMinMaxAvrg()
        {
            Tuple<double, double, double> daneWyjsiowe = new Tuple<double, double, double>(2.2, 1.2, 15.3122223);

            return daneWyjsiowe;
        }
    }
}
