using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrMatematyczny
{
    internal class RozszyfrowywanieKodu
    {
        public delegate void RozszyfrowywanieZakonczoneEventHandler(string wynik);

        public event RozszyfrowywanieZakonczoneEventHandler RozszyfrowywanieZakonczone;

        string wynik;
        List<char> wynikString = new List<char>();

        public void Rozszyfrowyanie(List<int> listaWprowadzonychSzyfrow, Dictionary<int, char> kolekcjaDanychNaSztywno)
        {
            WproadzanieDanychWejsciowych wproadzanieDanychWejsciowych = new WproadzanieDanychWejsciowych();
            DaneNaSztywno daneNaSztywno = new DaneNaSztywno();

            foreach (int szyfr in listaWprowadzonychSzyfrow)
            {
                string szyfrString = szyfr.ToString();

                for (int i = 0; i < szyfrString.Length; i++)
                {
                    string cyfra = szyfrString[i].ToString();
                    int jednocyfrowaLiczba;
                    try
                    {
                         jednocyfrowaLiczba = int.Parse(cyfra);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Nieprawidłowy formatliczby w szyfsze, pomijam ją");
                        continue;
                    }

                    try
                    {
                        PorownanieWartosci(jednocyfrowaLiczba, kolekcjaDanychNaSztywno);
                    }
                    catch(KeyNotFoundException)
                    {
                        Console.WriteLine($"Brak klucza w kolekcji. Pomijam tę liczbę.");
                        continue;
                    }
                }
            }
            string wynikLaczony = new string(wynikString.ToArray());
            Console.WriteLine($"Rozszyfrowany kod:{wynikLaczony}");

            RozszyfrowywanieZakonczone?.Invoke(wynikLaczony);
        }
        public void PorownanieWartosci(int jednocyfrowaLiczba, Dictionary<int, char> kolekcjaDanychNaSztywno)
        {
            foreach (var wartosciSztywne in kolekcjaDanychNaSztywno)
            {
                int klucz = wartosciSztywne.Key;
                char wartosc = wartosciSztywne.Value;

                if(jednocyfrowaLiczba == klucz )
                { 
                    wynikString.Add((char)wartosc);
                    break;
                }
            }
        }
    }
}
