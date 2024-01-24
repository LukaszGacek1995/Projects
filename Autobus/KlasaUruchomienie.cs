using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Autobus
{
    public class KlasaUruchomienie
    {
        public static void Wlacz()
        {
            DaneWejscioweWprowadzenie daneWejscioweWprowadzenie = new DaneWejscioweWprowadzenie();
            List<int> daneWejscioweCztery = daneWejscioweWprowadzenie.Wprowadzenie();

            int T1 = daneWejscioweWprowadzenie.T1;
            int T2 = daneWejscioweWprowadzenie.T2;
            int M = daneWejscioweWprowadzenie.M;
            int N1 = daneWejscioweWprowadzenie.N1;
            int N2 = daneWejscioweWprowadzenie.N2;

           List<Tuple<int, int, int>> rozkladyJazdy = daneWejscioweWprowadzenie.RozkladJazdy(M);

            ObliczaniePrzesiadek obliczaniePrzesiadek = new ObliczaniePrzesiadek();
            obliczaniePrzesiadek.Przesiadki(daneWejscioweCztery, rozkladyJazdy);


        }

    }
}