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

            MechanizmSprawdzaniaPozycjiLogika mechanizmSprawdzaniaPozycjiLogika = new MechanizmSprawdzaniaPozycjiLogika(Logika);
            var logika = mechanizmSprawdzaniaPozycjiLogika.GlownaLogika(listaParametrow);

            foreach (var iteracjaWyniku in logika)
            {
                Console.WriteLine(iteracjaWyniku);
            }

            Console.ReadKey();
        }

        public static List<string> Logika(List<string> listaDaneZnako, List<string> weryfikacjaKodow)
        {
            if (listaDaneZnako == null || weryfikacjaKodow == null)
            {
                Console.WriteLine("Błąd: jedna z list jest równa null. Wprowadź poprawne dane");
                return new List<string>();
            }

            Dictionary<string, int> iloscWystapien = ZliczWystapienia(listaDaneZnako);

            List<string> wyniki = new List<string>();

            foreach (var zapytanie in weryfikacjaKodow)
            {
                if (iloscWystapien.ContainsKey(zapytanie))
                {
                    wyniki.Add(iloscWystapien[zapytanie].ToString());
                }
                else
                {
                    wyniki.Add("BRAK");
                }
            }

            return wyniki;
        }

        private static Dictionary<string, int> ZliczWystapienia(List<string> lista)
        {
            if(lista == null)
            {
                Console.WriteLine("Błąd: lista jest null. Proszę wprowadzić poprawne wartośći");
                return new Dictionary<string, int>();
            }

            Dictionary<string, int> iloscWystapien = new Dictionary<string, int>();

            foreach (var element in lista)
            {
                if (iloscWystapien.ContainsKey(element))
                {
                    iloscWystapien[element]++;
                }
                else
                {
                    iloscWystapien[element] = 1;
                }
            }

            return iloscWystapien;
        }
    }
}
