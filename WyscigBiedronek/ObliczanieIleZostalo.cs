using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyscigBiedronek
{
    internal class ObliczanieIleZostalo
    {
        internal int ObliczenieKoncowe(Tuple<int, List<Tuple<int, int, int>>, Tuple<int, int, int>> daneWejsciowe)
        {
            int liczbaBiedronek = daneWejsciowe.Item1;
            List<Tuple<int, int, int>> wspolrzedneBiedronek = daneWejsciowe.Item2;
            Tuple<int, int, int> wspolrzedneMety = daneWejsciowe.Item3;

            int biedronkiTak = 0;

            foreach(var wspolrzedneBied in wspolrzedneBiedronek)
            {
                if(PorownajWartosci(wspolrzedneBied, wspolrzedneMety))
                {
                    biedronkiTak++;
                }

            }
            return biedronkiTak;
        }
        public bool PorownajWartosci (Tuple<int, int, int> wspolrzedneBiedronek, Tuple<int, int, int> wspolrzedneMety)
        {
            bool biedronkaBierzeLuNie = true;

            if(wspolrzedneBiedronek.Item1 == wspolrzedneMety.Item1 
              && wspolrzedneBiedronek.Item2 == wspolrzedneMety.Item2)
            {
                biedronkaBierzeLuNie = false;
            }
            return biedronkaBierzeLuNie;
        }
    }
}
