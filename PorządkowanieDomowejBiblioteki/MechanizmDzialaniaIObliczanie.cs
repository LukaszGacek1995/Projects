using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorządkowanieDomowejBiblioteki
{
    internal class MechanizmDzialaniaIObliczanie
    {
        private TylkoStruktueraDanychDodawanie slownik { get; }
        int liczenieTytuly = 0;
        int liczenieStrong = 0;
        int liczenieWyskosci = 0;

        public int WynikObliczenia()
        {
            var slownikPelneDaneKlucz = slownik.SlownikDanych.Keys.ToList();
            var slowniPelneDaneWartosc = slownik.SlownikDanych.Values;

            int zwracaWartoscNajszybszaTytul = 0;

            for (int i = 0; i < slownikPelneDaneKlucz.Count - 1; i++)
            {
                string obecnyTytul = slownikPelneDaneKlucz[i];
                string kolejnyTyul = slownikPelneDaneKlucz[i + 1];

                int tupleObecnaLiczbaStron = slownik.SlownikDanych[obecnyTytul].Item1;
                int tupleKolejnyLiczbaStron = slownik.SlownikDanych[obecnyTytul + 1].Item1;

                if (obecnyTytul == kolejnyTyul)
                {
                    liczenieTytuly++;
                }

                if (liczenieTytuly >= 1)
                {
                   return zwracaWartoscNajszybszaTytul = SegregacjaPoLiczbieStrong(tupleObecnaLiczbaStron, tupleKolejnyLiczbaStron);
                }
                else
                {
                 return zwracaWartoscNajszybszaTytul = SegregacjaPoTytule(slownik.SlownikDanych);
                }
            }
            return zwracaWartoscNajszybszaTytul;
        }

        private int SegregacjaPoTytule(Dictionary<string, Tuple<int, int>> slownikPelneDaneKlucz)
        {
            int uporzadkowanieRosnacoKsiazekTytulem = slownikPelneDaneKlucz
                .OrderBy(x => x.Key)
                .ToDictionary(y => y.Key, y => y.Value)
                .Count();

            return uporzadkowanieRosnacoKsiazekTytulem;
        }

        private int SegregacjaPoLiczbieStrong(int tupleObecnaLiczbaStron, int tupleKolejnyLiczbaStron)
        {
            var slownikPelneDaneKlucz = slownik.SlownikDanych.Keys.ToList();
            var slowniPelneDaneWartosc = slownik.SlownikDanych.Values;

            int zwracanaWartoscNAjszybsza = 0;

            for (int i = 0; i < slownikPelneDaneKlucz.Count - 1; i++)
            if (tupleObecnaLiczbaStron == tupleKolejnyLiczbaStron)
            {
                liczenieStrong++;
            }
            if (liczenieStrong >= 1)
            {
               return zwracanaWartoscNAjszybsza = SegregacjaPoWysokosci(slownik.SlownikDanych);
            }
            return zwracanaWartoscNAjszybsza;
        }

        private int SegregacjaPoWysokosci(Dictionary<string, Tuple<int, int>> slownikPelneDanePoWysokosci)
        {
            int uporzadkowanieRosnacoKsiazekWysokosc = slownikPelneDanePoWysokosci
                .OrderBy(x => x.Value.Item2)
                .ToDictionary(y => y.Key, y => y.Value)
                .Count();
            return uporzadkowanieRosnacoKsiazekWysokosc;
        }
    }
}
