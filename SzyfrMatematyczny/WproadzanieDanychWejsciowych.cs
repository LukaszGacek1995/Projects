using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrMatematyczny
{
    internal class WproadzanieDanychWejsciowych
    {
       private List<int> listaSzyftow = new List<int>();

        public List<int> ListaSzyftow
        {
            get
            {
                return listaSzyftow;
            }
        }

        public void GromadzenieDanych()
        {
            bool flaga = false;
            int wprowadzInt;

            while (!flaga)
            {
                Console.WriteLine("Wproadź liczbę zaszyfrowanych wiadomości");
                
                string wprowadz = Console.ReadLine();

                if(int.TryParse(wprowadz, out wprowadzInt) && wprowadzInt > 0 && wprowadzInt <= 1000 && wprowadzInt != null)
                { 

                    flaga = true;
                    int liczbazaszyfrowana = wprowadzInt;

                    Console.WriteLine($"Wprowadź szyfr, tyle razy: {liczbazaszyfrowana}");

                    for (int i = 0; i < liczbazaszyfrowana; i++)
                    {
                        string wprowadzanieSring = Console.ReadLine();
                        string[] wprowadzanieTablica = wprowadzanieSring.Split(' ');
                        int wprowadzanieTablicaint = int.Parse(wprowadzanieTablica[i]);
                        listaSzyftow.Add(wprowadzanieTablicaint);
                    }
                }
                else
                {
                    Console.WriteLine("Wprowadzono wartość z poza zakresu, spróbuj jeszcze raz");
                    continue;
                }
            }
        }
    }
}
