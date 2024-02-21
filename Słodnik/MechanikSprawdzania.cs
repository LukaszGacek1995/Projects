using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Słodnik
{
    internal class MechanikSprawdzania
    {
        public List<string> TablicaZKomedami { get; set; }
        private string OstatnieDodaneSłowo;
        List<string> ListaSlowMiedzyWprowadzonymi;

        public void ObslugaKomendy(string komendy)
        {
            string komendyNormalizacyjne = komendy.ToLowerInvariant();

            if (komendyNormalizacyjne.StartsWith("add"))
            {
                DodawanieWartosci(komendy);
            }
            else if (komendyNormalizacyjne.StartsWith("delete"))
            {
                UsuwanieWartosci(komendy);
            }
            else if (komendyNormalizacyjne.Contains("add ["))
            {
                DodawanieZSufixem(komendy);
            }
            else if (komendyNormalizacyjne.StartsWith("count"))
            {
                WyliczanieLeksykograficzne(komendy);
            }
            else if (komendyNormalizacyjne.StartsWith("list"))
            {
                WypisywanieSlowLeksykograficznie(komendy);
            }
            else if (komendyNormalizacyjne.StartsWith("show"))
            {
                WypisanieKonkretnegosłowa(komendy);
            }
            else
            {
                Console.WriteLine("Nieznana komenda" + komendy);
            }
        }

        public void DodawanieWartosci(string komendy)
        {
            string wartoscDodawana = komendy.Substring(3).Trim();
            if (!TablicaZKomedami.Contains(wartoscDodawana))
            {
                TablicaZKomedami.Add(wartoscDodawana);
                OstatnieDodaneSłowo = wartoscDodawana;
            }
            else
            {
                Console.WriteLine("Słowo już istnieje w słowniku.");
            }
        }

        public void UsuwanieWartosci(string komendy)
        {
            string wartosci = komendy.Substring(6).Trim();
            if (TablicaZKomedami.Contains(wartosci))
            {
                TablicaZKomedami.Remove(wartosci);
            }
            else
            {
                Console.WriteLine("Element do usunięcia nie istnieje w liście ");
            }
        }

        public void DodawanieZSufixem(string komendy)
        {
            int indexPoczatkowySuf = komendy.IndexOf("[") + 1;
            int indexKoncowySuf = komendy.IndexOf("]");
            int dlugoscSufixa = int.Parse(komendy.Substring(indexPoczatkowySuf, indexKoncowySuf - indexPoczatkowySuf));

            string suffix = komendy.Substring(indexKoncowySuf + 1).Trim();
            if (OstatnieDodaneSłowo != null && dlugoscSufixa < OstatnieDodaneSłowo.Length)
            {
                string poczatkoweLitery = OstatnieDodaneSłowo.Substring(0, dlugoscSufixa);
                string noweSłowo = poczatkoweLitery + suffix;
                TablicaZKomedami.Add(noweSłowo);
            }
            else
            {
                Console.WriteLine("Niepoprawna komenda - zbyt krótkie poprzednie słowo lub zbyt duży indeks dla suffixa.");
            }
        }

        public void WyliczanieLeksykograficzne(string komendy)
        {
            string[] slowa = komendy.Substring(5).Trim().Split(' ');
            string slowoPoczatkowe = slowa[0];
            string slowoKoncowe = slowa[1];

            int count = 0;

            for (int i = 0; i < TablicaZKomedami.Count; i++)
            {
                if (string.Compare(TablicaZKomedami[i], slowoPoczatkowe) > 0 && string.Compare(TablicaZKomedami[i], slowoKoncowe) < 0)
                {
                    count++;
                }
            }
            TablicaZKomedami.Add(count.ToString());
        }

        public void WypisywanieSlowLeksykograficznie(string komendaNormalizacji)
        {
            ListaSlowMiedzyWprowadzonymi = new List<string>();

            string[] slowaPierwszeOrazDrugie = komendaNormalizacji.Substring(5).Split(' ');
            string pierwszeSlowo = slowaPierwszeOrazDrugie[0];
            string drugieSlowo = slowaPierwszeOrazDrugie[1];

            for (int i = 0; i < TablicaZKomedami.Count; i++)
            {
                if (string.Compare(TablicaZKomedami[i], pierwszeSlowo) > 0 && string.Compare(TablicaZKomedami[i], drugieSlowo) < 0)
                {
                    ListaSlowMiedzyWprowadzonymi.Add(TablicaZKomedami[i]);
                }
            }
        }

        private void WypisanieKonkretnegosłowa(string komendy)
        {
            int numerSlowa;
            if (int.TryParse(komendy.Substring(4), out numerSlowa) && numerSlowa > 0 && numerSlowa <= TablicaZKomedami.Count)
            {
                List<string> posortowanaLista = TablicaZKomedami.OrderBy(x => x).ToList();
                Console.WriteLine(posortowanaLista[numerSlowa - 1]);
            }
            else
            {
                Console.WriteLine("Niepoprawny numer słowa.");
            }
        }
    }
}
