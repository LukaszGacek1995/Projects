using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Warsztat
{
    public class Warsztat
    {
        public delegate string DelegatInfoPodPrzebieg();
        public event DelegatInfoPodPrzebieg DelegatInfoPodPrzebiegEvent;

        public delegate string DelgatInformujacyOKoniecznosciLubNiekoniecznosciPrzegladu();
        public event DelgatInformujacyOKoniecznosciLubNiekoniecznosciPrzegladu EventDoPrzegladuTakczyNie;


        public event EventHandler PrzekierowanieDoWykonywanieNormalnegoPrzegladuPoweryfikacji;

        public Tuple<string, string, int, float> daneSamochodu;
        public bool CzyPodlegaPodPrzeglad { get; set; }
        public string MarkaSamochodu { get; set; }
        public string ModelSamochodu { get; set; }
        public int RokProdukcji { get; set; }
        public float Przebieg { get; set; }

        string marka;
        string model;
        int rok;
        float przebieg;

        public Warsztat(string markaSam, string markSam, int rokProdSam, float przebiegSam)
        {
            this.MarkaSamochodu = markaSam;
            this.ModelSamochodu = markaSam;
            this.RokProdukcji = rokProdSam;
            this.Przebieg = przebiegSam;

        }
        public void DodanieSamochcoduDoWarsztatu()
        {
            Console.WriteLine("Wprowadź ile samochodów będziesz wprowadzał do Warsztatu");

            int[] liczbaWprowadzanychSamochodówTablica = new int[int.Parse(Console.ReadLine())];
            foreach (int liczbaIteracji in liczbaWprowadzanychSamochodówTablica)
            {
                Console.WriteLine("Proszę dane smochodu tj. markę, model, rok produkcji oraz akutalny przebieg");

                string wprowadzoneDanePrzezUzytkownia = Console.ReadLine();

                string[] wprowadzoneDanePrzezUzytkowniaTablica = wprowadzoneDanePrzezUzytkownia.Split(' ');
                string marka = wprowadzoneDanePrzezUzytkowniaTablica[0];
                string model = wprowadzoneDanePrzezUzytkowniaTablica[1];
                int rok = int.Parse(wprowadzoneDanePrzezUzytkowniaTablica[2]);
                float przebieg = float.Parse(wprowadzoneDanePrzezUzytkowniaTablica[3]);

                Samochod samochod = new Samochod(marka, model, rok, przebieg);

                samochod.DadaniePojazdowDoBazyDanycgWarsztatu();
            }
        }

        public void SprawdzanieCzyaktualnePojazdyPotrzebujaPrzeglad()
        {
            daneSamochodu = new Tuple<string, string, int, float>(marka, model, rok, przebieg);

            if ((daneSamochodu.Item4 >= 10001 && daneSamochodu.Item4 <= 100000)
            || daneSamochodu.Item4 >= 100000)
            {
                DelegatInfoPodPrzebiegEvent += WeryfikacjaPrzegladuAtomatyczne;

            }

        }

        public void PoWprowadzeniuSprawdzanieCzyPojaazdyPorzebujaPrzegladu()
        {

        }

        public void WeryfikacjaOrazZmianyPoaktualizaacji()
        {

        }

        public string WeryfikacjaPrzegladuAtomatyczne()
        {
            /*ObslugaSerwisowaSamochodu()*/;


            //coś wartościowego zwrócić 
            return null;
        }

        public void ObslugaSerwisowaSamochodu(object sender, EventArgs l)
        {
            Console.WriteLine("Są prowadzone prace serwisowe");
            Console.WriteLine("Przeprowadzaono prace serwisowe");
            Console.WriteLine("Wykonano prace serwiswoe");

        }

        public void PrzekoroczeniePrzeglodowKomunikat()
        {
            Console.WriteLine("Przekroczoneo przebieg 10 000, należy zgłosić się do serwisu");
            Console.WriteLine("Przekroczoneo przebieg 100 000, należy zgłosić się do serwisu");

        }

        public string InformacjaZeNie()
        {
            return "Przegląd nie jest obeceniepotrzebny";
        }
    }
}

