using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Słodnik
{
    internal class MechanikSprawdzania
    {
        public List<string> tablicaZKomedami { get; set; }
        private string ostatnieDodaneSłowo;


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
                else if(komendyNormalizacyjne.StartsWith("delete"))
                {
                    UsuwanieWartosci(komendy);
                }
                else if(komendyNormalizacyjne.Contains("add ["))
                {
                    DodawanieZSufixem(komendy);
                }
                else if(komendyNormalizacyjne.StartsWith("count"))
                {
                    WyliczanieLeksykograficzne(komendy);
                }
                else if(komendyNormalizacyjne.StartsWith("list"))
                {
                    WypisywanieSlowLeksykograficznie(komendy);
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
            tablicaZKomedami.Add(wartoscDodawana);
            ostatnieDodaneSłowo = wartoscDodawana;
        }

        public void UsuwanieWartosci(string komendy)
        {
            string wartosci = komendy.Substring(6).Trim();
            if(tablicaZKomedami.Contains(wartosci))
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
            if (ostatnieDodaneSłowo != null && dlugoscSufixa <ostatnieDodaneSłowo.Length)
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
            for(int i=0; i<tablicaZKomedami.Count; i++)
            {
                if(string.Compare(tablicaZKomedami[i], slowoPoczatkowe) > 0 && string.Compare(tablicaZKomedami[i], slowoKoncowe) < 0)
                {
                    count++;
                }
            }
            tablicaZKomedami.Add(count.ToString());
        }
        public void WypisywanieSlowLeksykograficznie(string komendy)
        {
            // UZUPEŁNIĆ
        }
    }
}
