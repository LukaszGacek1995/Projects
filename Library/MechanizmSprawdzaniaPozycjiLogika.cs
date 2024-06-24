using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{

    internal class MechanizmSprawdzaniaPozycjiLogika
    {
        public delegate List<string> LogikaDelegate(List<string> listaDaneZnakow, List<string> weryfikacjaKodow);
        private LogikaDelegate logikaDelegate;

        public MechanizmSprawdzaniaPozycjiLogika(LogikaDelegate logikaDelegate)
        {
            this.logikafforDelegate = logikaDelegate;
        }

        public List<string> GlownaLogika(List<int> listaParametrow)
        {
            List<string> listaWynikow = new List<string>();
            var n = listaParametrow[0];
            var k = listaParametrow[1];

            List<string> listaDaneZnakow = DodanieZnakow(n);

            Console.WriteLine("Wprowadź teraz kody, które należy sprawdzić");
            List<string> weryfikacjaKodow = PorywnywanieElementow(k);

            if (n != 0 && k != 0)
            {
                List<string> dostepneLubNie = logikaDelegate(listaDaneZnakow, weryfikacjaKodow);
                foreach (var iteracjaDodawanie in dostepneLubNie)
                {
                    listaWynikow.Add(iteracjaDodawanie);

                }
                return listaWynikow;
            }

             List<string> DodanieZnakow(int n)
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
        }
    }
}

