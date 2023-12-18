using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class UruchamianieProgramu
    {
        public static void KlasaWywolujaca()
        {
            ParametryWejsciowe parametry = new ParametryWejsciowe();
            var listaParametrow = parametry.Wprowadzenie();

            MechanizmSprawdzaniaPozycjiLogika mechanizmSprawdzaniaPozycjiLogika = new MechanizmSprawdzaniaPozycjiLogika();
            var logika = mechanizmSprawdzaniaPozycjiLogika.GlownaLogika(listaParametrow);

            foreach (var iteracjaWyniku in logika)
            {
                Console.WriteLine(iteracjaWyniku);
            }

            Console.ReadKey();
        }
    }
}
