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
    public delegate void DelagatPrzekazanie(string przekazanie);
    internal class MechanikSprawdzania
    {
        public List<string> tablicaZKomedami { get; set; }
        private string ostatnieDodaneSłowo;
        List<string> listaSlowMiedzyWprowadzonymi;


        public void GlwonyMechanizmDzialania(List<string> tablicaKomend)
        {
            tablicaZKomedami = new List<string>();

            foreach (string komendy in tablicaKomend)
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
                    WypisywanieSlowLeksykograficznie(komendyNormalizacyjne);
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
        }
        

        public void DodawanieWartosci(string komendy)
        {
            string wartoscDodawana = komendy.Substring(3).Trim();
            if (!tablicaZKomedami.Contains(wartoscDodawana))
            {
                tablicaZKomedami.Add(wartoscDodawana);
                ostatnieDodaneSłowo = wartoscDodawana;
            }
            else
            {
                Console.WriteLine("Słowo już istnieje w słowniku.");
            }

        }

        public void UsuwanieWartosci(string komendy)
        {
            string wartosci = komendy.Substring(6).Trim();
            if (tablicaZKomedami.Contains(wartosci))
            {
                tablicaZKomedami.Remove(wartosci);
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
            if (ostatnieDodaneSłowo != null && dlugoscSufixa < ostatnieDodaneSłowo.Length)
            {
                string poczatkoweLitery = ostatnieDodaneSłowo.Substring(0, dlugoscSufixa);
                string noweSłowo = poczatkoweLitery + suffix;
                tablicaZKomedami.Add(noweSłowo);
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

            for (int i = 0; i < tablicaZKomedami.Count; i++)
            {
                if (string.Compare(tablicaZKomedami[i], slowoPoczatkowe) > 0 && string.Compare(tablicaZKomedami[i], slowoKoncowe) < 0)
                {
                    count++;
                }
            }
            tablicaZKomedami.Add(count.ToString());
        }
        public void WypisywanieSlowLeksykograficznie(string komendaNormalizacji)
        {
            listaSlowMiedzyWprowadzonymi = new List<string>();

            string[] slowaPierwszeOrazDrugie = komendaNormalizacji.Substring(5).Split(' ');
            string pierwszeSlowo = slowaPierwszeOrazDrugie[0];
            string drugieSlowo = slowaPierwszeOrazDrugie[1];

            for (int i = 0; i < tablicaZKomedami.Count; i++)
            {
                if (string.Compare(tablicaZKomedami[i], pierwszeSlowo) > 0 && string.Compare(tablicaZKomedami[i], drugieSlowo) < 0)
                {
                    listaSlowMiedzyWprowadzonymi.Add(tablicaZKomedami[i]);
                }
            }
        }
        private void WypisanieKonkretnegosłowa(string komendy)
        {

            int numerSlowa;
            if (int.TryParse(komendy.Substring(4), out numerSlowa) && numerSlowa > 0 && numerSlowa <= tablicaZKomedami.Count)
            {
                List<string> posortowanaLista = tablicaZKomedami.OrderBy(x => x).ToList();
                Console.WriteLine(posortowanaLista[numerSlowa - 1]);
            }
            else
            {
                Console.WriteLine("Niepoprawny numer słowa.");
            }
        }
    }
}
