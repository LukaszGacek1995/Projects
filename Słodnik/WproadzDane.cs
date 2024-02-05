using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Słodnik
{
    internal class WproadzDane
    {
        public int liczbapolecen { get; set; }
        public List<string> listaWprowadzonychKomend { get; set; }

        public void Dane()
        {
            bool flagaPonowienia = true;

            while (flagaPonowienia)
            {
                Console.WriteLine("Wprowadź liczbę poleceń");
                liczbapolecen = int.Parse(Console.ReadLine());
                if (liczbapolecen > 0 && liczbapolecen < 10000)
                {
                    Komendy();
                    flagaPonowienia = false;
                }
                else
                {
                    Console.WriteLine("Prekroczono zakres - wprowadź ponowenie");
                }
            }
        }

        public void Komendy()
        {
            Console.WriteLine("Wprowadz Komendy");

            listaWprowadzonychKomend = new List<string>();

            for (int i = 0; i < liczbapolecen; i++)
            {
                string wprowadzonaWartosc = Console.ReadLine();
                listaWprowadzonychKomend.Add(wprowadzonaWartosc);
            }
        }
    }
}
