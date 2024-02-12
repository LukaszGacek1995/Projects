using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Słodnik
{
    internal class MechanikSprawdzania
    {
        public List<string> tablicaZKomedami { get; set; }


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
                else if(komendyNormalizacyjne.StartsWith("Add ["))
                {
                    DodawanieZSufixem(komendy);
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
        }
    }
}
