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
         


        int liczbaWprowadzanychHaselCustomPojedyncze = 0;
        
        internal string[] Dane()
        {
            PeleZdaniaWWyszukiwarce();
            WprowadzWartosciUzytkowniak();

            return null;
        }

        private void PeleZdaniaWWyszukiwarce()
        {
            bool flaga = false;

            int liczbawprowadzonychZdan = 0;
           
           

            while (!flaga)
            {
                Komenda1();

                string liczbawprowadzonychZdanBezBialychZnakow = Console.ReadLine().Trim();
                liczbawprowadzonychZdan = int.Parse(liczbawprowadzonychZdanBezBialychZnakow);

                if (liczbawprowadzonychZdan != null && liczbawprowadzonychZdan > 0 && liczbawprowadzonychZdan <= 10000)
                {
                    flaga = true;
                }
                else
                {
                    Komenda2();
                    flaga = false;
                }
            }

            for (int i = 0; i < liczbawprowadzonychZdan; i++)
            {
                ListaZZdaniami = Console.ReadLine().Split().ToList();
            }
        }

        private void WprowadzWartosciUzytkowniak()
        {
            bool flaga = false;

            while (!flaga)
            {
                Komenda3();
                string liczbaWprowadzanychHaselCustom = Console.ReadLine().Trim();
                liczbaWprowadzanychHaselCustomPojedyncze = int.Parse(liczbaWprowadzanychHaselCustom);

                if (liczbaWprowadzanychHaselCustomPojedyncze != null && liczbaWprowadzanychHaselCustomPojedyncze > 0 && liczbaWprowadzanychHaselCustomPojedyncze <= 10000)
                {
                    flaga = true;
                }
                else
                {
                    Komenda2();
                    flaga = false;
                }
            }
            for(int i =0; i< liczbaWprowadzanychHaselCustomPojedyncze; i++)
            {
                ListaZWprowadzonymiSlowamiUzytkownik = Console.ReadLine().Split().ToList();
            }
        }

        public override string Komenda3()
        {
            return "Proszę wprowadzić liczbę wyszukiwanych słów, a poniżej te słowa";
        }
        public override string Komenda1()
        {
            return "Wproszę wprowadzić liczbę przypadków testowych - liczba rzeczywista bez odspęptów";
        }
    }
}
