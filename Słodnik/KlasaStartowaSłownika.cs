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
            wproadzDane.Dane();

            List<string> tablicaKomend = wproadzDane.listaWprowadzonychKomend;

            MechanikSprawdzania mechanikSprawdzania = new MechanikSprawdzania();
            mechanikSprawdzania.GlwonyMechanizmDzialania(tablicaKomend);

            List<string> tablicaZWynikami = mechanikSprawdzania.tablicaZKomedami;

            foreach (string s in tablicaZWynikami)
            {
                Console.WriteLine("");
                Console.WriteLine("Wyniki poniżej");
                Console.WriteLine($"{s}");
            }
            Console.ReadKey();
        }
    }
}
