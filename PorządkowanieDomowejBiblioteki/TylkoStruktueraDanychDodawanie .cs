using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorządkowanieDomowejBiblioteki
{
    //----------------------- DOPISAĆ DZIEDZICZENIE-----------------------------
    public class TylkoStruktueraDanychDodawanie :  IElementyInterface
    {
        public int liczbaKsiazek { get; set; }
        public Dictionary<string, Tuple<int, int>> SlownikDanych { get; set; }
        public int liczbaTestow { get; set; }

        public bool flaga = false;
        public bool flaga2 = false;


        public void WprowadzDane()
        {

            Console.WriteLine("Wprowadz liczbę przypadków testowych");
            while (!flaga)
            {
                 liczbaTestow = int.Parse(Console.ReadLine());

                if (liczbaTestow >= 0 && liczbaTestow < 10)
                {
                    for (int i = 0; i < liczbaTestow; i++)
                    {
                        Console.WriteLine("Wprowadz liczbę książek");
                        while (flaga2)
                        {


                            if (int.TryParse(Console.ReadLine(), out int liczbaKsiazek))
                            {
                                if (liczbaKsiazek >= 1 && liczbaKsiazek <= 30000)
                                {
                                    Console.WriteLine($"Wprowadzono {liczbaKsiazek} książek");
                                }
                                else
                                {
                                    Console.WriteLine("Wybrano liczbę książek z poza zakresu, spróbój ponownie");
                                }
                            }
                            flaga2 = true;
                        }
                        for (int j = 0; j < liczbaKsiazek; j++)
                        {
                            Console.WriteLine("Wprowadz liczbę stron, wysokość oraz skrócony tytuł książki ");
                            DaneKsiazki(liczbaKsiazek);
                        }
                    }
                    flaga = true;
                }
                else
                {
                    Console.WriteLine("Przekroczono zakres, proszę wprowadzić poprawny");

                }
            }
        }

        private void DaneKsiazki(int liczbaKsiazek)
        {

            for (int i = 0; i < liczbaKsiazek; i++)
            {


                var daneKsiazki = Console.ReadLine();
                string[] stringDane = daneKsiazki.Trim().Split(' ');



                if (int.TryParse(stringDane[0], out int pierwszaWartosc) && (int.TryParse(stringDane[1], out int drugaWartosc)))
                {
                    string slowo = stringDane[2];


                    Tuple<int, int> wartoscTupla = Tuple.Create(pierwszaWartosc, drugaWartosc);

                    SlownikDanych.Add(slowo, wartoscTupla);
                }
                else
                {
                    Console.WriteLine($"Została/zostały wprowadzone wartości które nie są typu int, aktualne wartości: {pierwszaWartosc} oraz {drugaWartosc}");
                }
            }
        }
    }
}
