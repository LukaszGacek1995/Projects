using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wyszukiwarka
{
    public delegate int LicznikWystapienSlowaDelegate(string zadanie, string slowo);
    internal class MechanikaSprawdzania : IElementyWyszukiwarki
    {
        private ZasilDanymi zasilanieDanymi { get; set; }
        public string testowaWlasciwosc { get; set; }

        private int liczZnalezionychSlow { get;set; }

        public List<int> tablicaWartosciWynikowych { get; set; }

        int liczbaWystepowaniaSlowa = 0;

        private LicznikWystapienSlowaDelegate licznikDelegatu { get; set; }


        public MechanikaSprawdzania(ZasilDanymi zasilanieDanymi, LicznikWystapienSlowaDelegate licznikDelegatu)
        {
            this.zasilanieDanymi = zasilanieDanymi;
            this.tablicaWartosciWynikowych = new List<int>();
            this.licznikDelegatu = licznikDelegatu;
        }
        public void MechanizmSprawdzania()
        {
            List<string> listaZdanZInternetu = zasilanieDanymi.ListaZZdaniami;
            List<string> listaWybranychSlowUzytkownik = zasilanieDanymi.ListaZWprowadzonymiSlowamiUzytkownik;
            
            foreach(string zdaniaSlowaIteracja in listaZdanZInternetu)
            {
                foreach(string slowaUzytkowniakWyszukiwanie in listaWybranychSlowUzytkownik)
                {
                    if(zdaniaSlowaIteracja.Contains(slowaUzytkowniakWyszukiwanie))
                    {
                        liczbaWystepowaniaSlowa += licznikDelegatu(zdaniaSlowaIteracja, slowaUzytkowniakWyszukiwanie);
                    }
                }
                tablicaWartosciWynikowych.Add(liczbaWystepowaniaSlowa);
            }
            ZwracanieDanych();
        }

        public string ZwracanieDanych()
        {
            return "Obliczyłem wyniki wyszukiwania poniżej podam wartości:";
        }
    }
}
