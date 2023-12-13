using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class MechanizmSprawdzaniaPozycjiLogika
    {
        public List<string> GlownaLogika(List<int> listaParametrow)
        {
            List<string> listaWynikow = new List<string>();
            var n = listaParametrow[0];
            var k = listaParametrow[1];

            List<string> listaDaneZanakow = DodanieZnakow(n);

            Console.WriteLine("Wprowadź teraz kody, które należy sprawdzić");
            List<string> weryfikacjaKodow = PorywnywanieElementow(k);

            if (n != null && k != null)
            {
                List<string> dostepneLubNie = ZwracanieDostepnosciKsiazek(listaDaneZanakow, weryfikacjaKodow);
                foreach (var iteracjaDodawanie in dostepneLubNie)
                {
                    listaWynikow.Add(iteracjaDodawanie);
                }
            }
            return listaWynikow;
        }

        private List<string> DodanieZnakow(int n)
        {
            List<string> listaKodow = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string wartosci = Console.ReadLine();
                if (wartosci.Length > 5 && wartosci.Length <= 7)
                {
                    listaKodow.Add(wartosci);
                }
            }
            return listaKodow;
        }

        private List<string> PorywnywanieElementow(int k)
        {
            List<string> listaKodowDoSprawdzenia = new List<string>();
            for (int i = 0; i < k; i++)
            {
                string wartosci2 = Console.ReadLine();
                if (wartosci2.Length > 5 && wartosci2.Length <= 7)
                {
                    listaKodowDoSprawdzenia.Add(wartosci2);
                }
            }
            return listaKodowDoSprawdzenia;
        }

        private List<string> ZwracanieDostepnosciKsiazek(List<string> listaDaneZanakow, List<string> weryfikacjaKodow)
        {
            List<string> listaZwracajaca = new List<string>();

            foreach (string iteracjaWeryfikacjaKodow in weryfikacjaKodow)
            {
                int count = 0;

                foreach (string iteracjaListaDaneZanakow in listaDaneZanakow)
                {
                    if (string.Equals(iteracjaListaDaneZanakow, iteracjaWeryfikacjaKodow, StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                    }
                }

                if (count > 0)
                {
                    listaZwracajaca.Add(count.ToString());
                }
                else
                {
                    listaZwracajaca.Add("BRAK");
                }
            }

            return listaZwracajaca;
        }
    }
}
