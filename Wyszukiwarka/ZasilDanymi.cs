using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Wyszukiwarka
{
    internal class ZasilDanymi : KlasaBazowaDoWprowadzania
    {

        public List<string> ListaZZdaniami { get; set; }
        public List<string> ListaZWprowadzonymiSlowamiUzytkownik { get; set; }

        public ZasilDanymi()
        {
            ListaZZdaniami = new List<string>();
            ListaZWprowadzonymiSlowamiUzytkownik = new List<string>();
        }

        public void Dane()
        {
            PoleZdaniaWWyszukiwarce();
            WprowadzWartosciUzytkowniak();
        }

        private void PoleZdaniaWWyszukiwarce()
        {
            Console.WriteLine("Proszę wprowadzić liczbę przypadków testowych:");
            int liczbaWprowadzonychZdan = int.Parse(Console.ReadLine());

            for (int i = 0; i < liczbaWprowadzonychZdan; i++)
            {
                string wprowadzaniePozycjiInternet = Console.ReadLine();
                ListaZZdaniami.Add(wprowadzaniePozycjiInternet.ToLower());
            }
        }

        private void WprowadzWartosciUzytkowniak()
        {
            Console.WriteLine("Proszę wprowadzić liczbę wyszukiwanych słów:");
            int liczbaWprowadzanychHaselCustomPojedyncze = int.Parse(Console.ReadLine());

            for (int i = 0; i < liczbaWprowadzanychHaselCustomPojedyncze; i++)
            {
                string wprowadzaniePozycjiUzytkownika = Console.ReadLine();
                ListaZWprowadzonymiSlowamiUzytkownik.Add(wprowadzaniePozycjiUzytkownika.ToLower());
            }
        }
    }
}
