using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrMatematyczny
{
    internal class RozszyfrowywanieKodu
    {
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
                    int jednocyfrowaLiczba = int.Parse(cyfra);

                    PorownanieWartosci(jednocyfrowaLiczba, kolekcjaDanychNaSztywno);
                }
            }
        }
        public void PorownanieWartosci(int jednocyfrowaLiczba, Dictionary<int, char> kolekcjaDanychNaSztywno)
        {
            foreach (var wartosciSztywne in kolekcjaDanychNaSztywno)
            {
                int klucz = wartosciSztywne.Key;
                char wartosc = wartosciSztywne.Value;

                if(jednocyfrowaLiczba == klucz )
                {
                    Console.WriteLine($"Odszyfrowana wartość: {wartosc}");
                    break;
                }
            }
        }
    }
}
