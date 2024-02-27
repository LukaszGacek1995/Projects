using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupowanieKontaktow
{
    public class WeryfikacjaOrazTworzenieGrup
    {
        public ZasilanieDanych zasilanieDanych { get; set; }

        public void MechanizmPrzydzielaniaGrup()
        {
            Dictionary<string, int[]> slownikDane = zasilanieDanych.slownikImieLiczby;

            MechanizmLiczeniaNajwiekszejGrupy();
        }


        public void MechanizmLiczeniaNajwiekszejGrupy()
        {
            int liczbaGrup = zasilanieDanych.M;

        }
    }
}
