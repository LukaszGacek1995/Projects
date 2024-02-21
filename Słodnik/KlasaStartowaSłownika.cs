using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Słodnik
{
    public static class KlasaStartowaSłownika
    {
        public static void UruchomSlownik()
        {
            WproadzDane wproadzDane = new WproadzDane();
            MechanikSprawdzania mechanikSprawdzania = new MechanikSprawdzania();

            wproadzDane.UstawienieObslugiKomendy(mechanikSprawdzania.ObslugaKomendy);

            wproadzDane.Dane();

            List<string> tablicaKomend = wproadzDane.ListaWprowadzonychKomend;

            mechanikSprawdzania.TablicaZKomedami = new List<string>();

            mechanikSprawdzania.ObslugaKomendy(tablicaKomend[0]);

            Console.WriteLine("");
            Console.WriteLine("Wyniki poniżej");

            foreach (string s in mechanikSprawdzania.TablicaZKomedami)
            {
                Console.WriteLine($"{s}");
            }
            Console.ReadKey();
        }
    }
}
