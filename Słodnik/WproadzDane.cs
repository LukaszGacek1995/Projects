using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Słodnik
{
    public delegate void KomendyDelgatu(string komenda);

    internal class WproadzDane
    {
        public int LiczbaPolecen { get; set; }
        public List<string> ListaWprowadzonychKomend { get; set; }

        public KomendyDelgatu KomendyDelegatu;

        public void UstawienieObslugiKomendy(KomendyDelgatu komendyDelegatu)
        {
            this.KomendyDelegatu = komendyDelegatu;
        }

        public void Dane()
        {
            bool flagaPonowienia = true;

            while (flagaPonowienia)
            {
                Console.WriteLine("Wprowadź liczbę poleceń");
                LiczbaPolecen = int.Parse(Console.ReadLine());
                if (LiczbaPolecen > 0 && LiczbaPolecen < 10000)
                {
                    Komendy();
                    flagaPonowienia = false;
                }
                else
                {
                    Console.WriteLine("Prekroczono zakres - wprowadź ponownie");
                }
            }
        }

        public void Komendy()
        {
            Console.WriteLine("Wprowadź Komendy");

            ListaWprowadzonychKomend = new List<string>();

            for (int i = 0; i < LiczbaPolecen; i++)
            {
                string wprowadzonaWartosc = Console.ReadLine();
                ListaWprowadzonychKomend.Add(wprowadzonaWartosc);
                KomendyDelegatu?.Invoke(wprowadzonaWartosc);
            }
        }
    }
}
