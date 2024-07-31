using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pojedyncze_Cwiczenia.Eventy
{
    public class EventyKlasaUruchomieniowaOrazZadania
    {
        public static void Main()
        {
            PierwszeZadanieEventy program1 = new PierwszeZadanieEventy();
            program1.UruchomPierwszyProgram();
        }
    }

    public class Counter
    {

        public delegate void DelegatDoEventu();
        public event DelegatDoEventu EventDlaKalkulator;

        private int _count;

        public int Count
        {
            get { return _count; }
            set
            {
                if (_count != value)
                {
                    _count = value;

                    EventDlaKalkulator?.Invoke();
                }
            }
        }
    }

    public class PierwszeZadanieEventy
    {

        public void UruchomPierwszyProgram()
        {
            Counter counter = new Counter();

            counter.EventDlaKalkulator += PowiadomienieOZmianieLiczby;

            counter.Count = 10;
            counter.Count = 20;
        }

        public static void PowiadomienieOZmianieLiczby()
        {
            Console.WriteLine("Została zmieniona liczna w kalkulatorze");
        }
    }
    //----------------------------------Drugie zadanie

    public class Timer
    {
        //--------------
        public delegate void DelgatDoUplywajacegoCzasu();
        public event DelgatDoUplywajacegoCzasu EventDoCzasuUplywajacego;
        public void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                EventDoCzasuUplywajacego.Invoke();
            }
        }
    }

    public class Program3
    {
        public static void UruchomPierwszyProgramDwa(string[] args)
        {
            Timer timer = new Timer();
            //---------------
            timer.EventDoCzasuUplywajacego += InfoOCzasie;
            timer.Start();
        }

        //------------------drugi przykład 
        public static void InfoOCzasie()
        {
            Console.WriteLine("Upłynął czas elo");
        }
    }

    //------------------------------------------------- trzecie zadanie 


    public class Downloader
    {

        public delegate void DelegatDlaTrzeciegoZadania();
        public event DelegatDlaTrzeciegoZadania TrzecieZadanieEvent;
        public void StartDownload()
        {
            for (int i = 0; i <= 100; i += 20)
            {
                System.Threading.Thread.Sleep(500); // symulacja pobierania
                TrzecieZadanieEvent?.Invoke();                           // Tu dodaj kod, który wywoła event, przekazując aktualny postęp
            }
        }
    }

    public class Program4
    {
        public static void Main(string[] args)
        {
            Downloader downloader = new Downloader();
            // Tu dodaj kod subskrybujący event
            downloader.TrzecieZadanieEvent += InformacjaOWykonaniuSieIteracji;

            downloader.StartDownload();
        }

        public static void InformacjaOWykonaniuSieIteracji()
        {
            Console.WriteLine("Dokonało się działanie");
        }
    }
    //----------------------------------------------------- Kolejne zadanie 

    public class TemperatureMonitor
    {

        public delegate void DelegaDoTemperaturaMonitor();
        public event DelegaDoTemperaturaMonitor EventDelegaDoTemperaturaMonitor;

        private int _temperature;
        private int _threshold = 30;

        public int Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;

                EventDelegaDoTemperaturaMonitor?.Invoke();
            }
        }
    }

    public class Program5
    {
        public static void Main(string[] args)
        {
            TemperatureMonitor monitor = new TemperatureMonitor();
            monitor.EventDelegaDoTemperaturaMonitor += Powiadomienie;

            monitor.Temperature = 25;
            monitor.Temperature = 35;
        }

        public static void Powiadomienie()
        {
            Console.WriteLine("Przeszło");
        }
        // Tu dodaj metodę obsługującą event
    }

    //----------------------------------------------------------------KOLEJNY PRZYKŁAD

    class Program12
    {
        public static event EventHandler<string> eventDlaProgramo12;


        public void MetodaStartowaProgram12()
        {
            eventDlaProgramo12 += PowiadomienieOEnterze;
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            
            GreetUser(name);
        }


        public void PowiadomienieOEnterze(object sender, string name)
        {

            GreetUser(name);
        }
        static void GreetUser(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }

    //------------------------------------------------------------KOLEJNE PRZYKŁADY

    
    class Counter2
    {
        public event EventHandler<int> eventDlaCount2;
        public int Count { get; private set; }

        
        public void Increment2()
        {
            Count++;
            if( this.Count == 2 )
            {
                eventDlaCount2?.Invoke(this, Count );
            }

            Console.WriteLine($"Count is now: {Count}");
        }
    }

    class Program
    {
        static void Main()
        {
 
            Counter2 counter = new Counter2();
            counter.eventDlaCount2 += PowiadomoieniODwa;

            counter.Increment2();
            counter.Increment2();

        }

        static void PowiadomoieniODwa(object sender, int e)
        {
            Console.WriteLine("Teraz jest liczba 2");
        }
    }
}
