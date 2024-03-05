using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupowanieKontaktow
{
    public class WeryfikacjaOrazTworzenieGrup
    {
        private Dictionary<string, int[]> slownikDane;

        public WeryfikacjaOrazTworzenieGrup(Dictionary<string, int[]> dane)
        {
            slownikDane = dane;
        }

        public int MechanizmLiczeniaNajwiekszejGrupy()
        {
            Dictionary<int, List<string>> slownikZKluczemPo = new Dictionary<int, List<string>>();
            foreach (var kontakt in slownikDane)
            {
                string osoba = kontakt.Key;
                int[] grupy = kontakt.Value;

                foreach (var grupa in grupy)
                {
                    if (!slownikZKluczemPo.ContainsKey(grupa))
                    {
                        slownikZKluczemPo.Add(grupa, new List<string>());
                    }
                    slownikZKluczemPo[grupa].Add(osoba);
                }
            }

            int dolnaGranica = 1;
            int golrnaGrnica = slownikDane.Count;
            int minimalnaLiczbaOsobWNajwiekszejGrupie = golrnaGrnica;

            while (dolnaGranica <= golrnaGrnica)
            {
                int srednia = (dolnaGranica + golrnaGrnica) / 2;

                if (CzyMoznaPodzielicNagrupy(slownikZKluczemPo, srednia))
                {
                    minimalnaLiczbaOsobWNajwiekszejGrupie = srednia;

                    golrnaGrnica = srednia - 1;
                }
                else
                {
                    dolnaGranica = srednia + 1;
                }
            }
            return minimalnaLiczbaOsobWNajwiekszejGrupie;
        }

        private bool CzyMoznaPodzielicNagrupy(Dictionary<int, List<string>> slownikZKluczemPo, int liczbaOsobWNajwiekszejGrupie)
        {
            int aktualnaGrupa = 0;
            int liczbaGrup = 0;

            foreach (var group in slownikZKluczemPo)
            {
                foreach (var osoba in group.Value)
                {
                    if (group.Key != aktualnaGrupa)
                    {
                        liczbaGrup++;
                        aktualnaGrupa = group.Key;
                    }
                }
            }
            return liczbaGrup <= liczbaOsobWNajwiekszejGrupie;
        }
    }
}
