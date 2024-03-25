using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorządkowanieDomowejBiblioteki
{
    //----------------------- DOPISAĆ DZIEDZICZENIE-----------------------------

    public delegate void Delegat(string dane);

    public class TylkoStruktueraDanychDodawanie : IElementyInterface
    {

        public delegate void DelegatoDoEventuOUzupełnieniu();
        public event DelegatoDoEventuOUzupełnieniu eventPowiadomienieOUzupelnieniu;


        public int liczbaKsiazek { get; set; }
        public Dictionary<string, Tuple<int, int>> SlownikDanych { get; set; }
        public int liczbaTestow { get; set; }

        public bool flaga = false;
        public bool flaga2 = false;


        public TylkoStruktueraDanychDodawanie()
        {
            SlownikDanych = new Dictionary<string, Tuple<int, int>>();
        }
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
                        while (!flaga2)
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
                            Delegat delegat = DaneKsiazki;
                            delegat(Console.ReadLine());
                            //DaneKsiazki(liczbaKsiazek);
                        }
                    }
                    flaga = true;
                }
                else
                {
                    Console.WriteLine("Przekroczono zakres, proszę wprowadzić poprawny");

                }
            }

            eventPowiadomienieOUzupelnieniu += PowiadomienieUzupełenie;
            eventPowiadomienieOUzupelnieniu?.Invoke();
        }

        private void PowiadomienieUzupełenie()
        {
           Console.WriteLine("Dane wprowadzaone pprowadzone poprawnie");
        }

        private void DaneKsiazki(string dane)
        {

            for (int i = 0; i < liczbaKsiazek; i++)
            {


                var daneKsiazki = Console.ReadLine();
                string[] stringDane = dane.Trim().Split(' ');

                int drugaWartosc = 0;
                int pierwszaWartosc = 0;
                if (int.TryParse(stringDane[0], out pierwszaWartosc) && (int.TryParse(stringDane[1], out drugaWartosc)))
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
