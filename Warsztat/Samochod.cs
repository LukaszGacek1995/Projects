using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warsztat
{
    public class Samochod
    {
        public event EventHandler EventDoPowiadamianiaPrzegladAutomatyczny;
        public delegate void DelegatDo200Tysiecy();
        public event DelegatDo200Tysiecy EventPowiadamiajacyORokuPowyzej2000;

        public string Marka { get; set; }
        public string Model { get; set; }
        public int RokProdukcji { get; set; }
        public float Przebieg { get; set; }

        public int OplataDodatkowa { get; set; }

        public int KosztSerwisuCalkowity { get;set; }

        public bool PotwierdzeniePrzejsciaLubNiePrzejsciaPrzegladu { get; set; }
        public Samochod(string marka, string model, int rok     , float przebieg)
        {
            marka = this.Marka;
            model = this.Model;
            rok = this.RokProdukcji;
            przebieg = this.Przebieg;
        }

        public Tuple<Dictionary<string, string>, int, float> TupleParametryAutaSamochod { get; set; }

        public void DadaniePojazdowDoBazyDanycgWarsztatu()
        {
            Dictionary<string, string> slowanikZMarkamiOrazModelami = new Dictionary<string, string>();
            slowanikZMarkamiOrazModelami.Add(Marka, Model);
            TupleParametryAutaSamochod = new Tuple<Dictionary<string, string>, int, float>(slowanikZMarkamiOrazModelami, RokProdukcji, Przebieg);
        }
        public void MonitorowaniePrzebieguSamochodu()
        {


            string test = "";

            if (TupleParametryAutaSamochod.Item3 >= 10001 && TupleParametryAutaSamochod.Item3 <= 100000 || TupleParametryAutaSamochod.Item3 >= 100000)
            {
                EventDoPowiadamianiaPrzegladAutomatyczny += PowiadomienieOprzegladznieAutoamtyczne_AktualnyPrzebiegOrazJakieJestPrzekroczeni;
                EventDoPowiadamianiaPrzegladAutomatyczny?.Invoke(object.Equals(test), EventArgs.Empty);
                    
                   
            }
        }

        public void MetodaSprawdzajaceCzyPowineneBycPrzegladWNajblizszcymCzsie()
        {

        }

        public void PowiadomienieOprzegladznieAutoamtyczne_AktualnyPrzebiegOrazJakieJestPrzekroczeni(object sender, EventArgs e)
        {
            Console.WriteLine("Czasna przegląd - aktualnyPrzebieg {this.Przebieg}");
            Warsztat warsztat = new Warsztat();
            warsztat.PrzekierowanieDoWykonywanieNormalnegoPrzegladuPoweryfikacji += warsztat.ObslugaSerwisowaSamochodu;
            //przekierowanie do naormalnych przegladow 
        }

        public void MechanizmModnitorowaniaRocznika()
        {
            // jężeli samochód jest starszy niż 2000 rok to konieczna jest dodatkow opłata
            if (this.RokProdukcji <= 2000)
            {

            }

        }

        public void PrzekierowanieDoOplat()
        {
            EventPowiadamiajacyORokuPowyzej2000 += NapiczajDodatkoweOplaty;
            EventPowiadamiajacyORokuPowyzej2000.Invoke();
        }

        private void NapiczajDodatkoweOplaty(object? sender, EventArgs e)
        {
            int Oplata;
            Oplata = this.OplataDodatkowa + 15000;
        }
    }
}
