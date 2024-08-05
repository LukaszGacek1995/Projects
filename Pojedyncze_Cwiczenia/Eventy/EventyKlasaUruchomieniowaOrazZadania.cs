using System;
using System.Collections.Generic;
using System.IO;
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

    // ------------------------------------------------------------ Kolejne ćwiczenie eventy

    class Counter5
    {
        public event EventHandler<int> CountChanged;
        private int count;

        public int Count
        {
            get { return count; }
            private set
            {
                count = value;
                OnCountChanged(count);
            }
        }

        public void Increment()
        {
            Count++;
        }

        protected virtual void OnCountChanged(int newCount)
        {
            CountChanged?.Invoke(this, newCount);
        }
    }

    class Program55
    {
        static void Main()
        {
            Counter5 counter = new Counter5();
            counter.CountChanged += OnCountChanged;
            counter.Increment();
            counter.Increment();
        }

        static void OnCountChanged(object sender, int newCount)
        {
            Console.WriteLine($"Count is now: {newCount}");
        }
    }

    //------------------------------------------------------------Kolejne ćwiczenie z eventami 
    class ShoppingList
    {
        public List<string> items = new List<string>();

        public void AddItem(string item)
        {
            items.Add(item);
            Console.WriteLine($"Added {item} to the shopping list.");
        }

        public void RemoveItem(string item)
        {
            if (items.Remove(item))
            {
                Console.WriteLine($"Removed {item} from the shopping list.");
            }
            else
            {
                Console.WriteLine($"{item} not found in the shopping list.");
            }
        }

        public void PrintList()
        {
            Console.WriteLine("Shopping List:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }

    
    class Program7
    {
        public delegate void DelegatDlaKolejnegoZadaniaZLista();
        public event DelegatDlaKolejnegoZadaniaZLista eventZadanieKolejne;
        public void Uruchamianie7()
        {
            eventZadanieKolejne += PoinformowanieOObecnosciKonkretnegoTeksu;

            ShoppingList shoppingList = new ShoppingList();
            shoppingList.AddItem("Milk");
            shoppingList.AddItem("Bread");
            if(shoppingList.items.Contains("Bread"))
            {
                eventZadanieKolejne?.Invoke();
            }
            shoppingList.RemoveItem("Milk");
            shoppingList.PrintList();
        }

        public void PoinformowanieOObecnosciKonkretnegoTeksu()
        {
            Console.WriteLine("Dodano element - wywołano event");
        }
    }

    // --------------------------------------------------------- Kolejny przykład symulator gry
    class Game
    {
        
        public event EventHandler OnGryEvent;
        public void Start()
        {
            Console.WriteLine("Game started.");
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"Playing... {i + 1} second(s)");
            }
            OnGryEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    class ProgramSymulator
    {
        public void InformujOZakonczeniu(object sender, EventArgs e)
        {
            Console.WriteLine("Game over.");
        }
        static void Main()
        {
            Game game = new Game();
            ProgramSymulator programSymulator = new ProgramSymulator();

            game.OnGryEvent += programSymulator.InformujOZakonczeniu;

            game.Start();
        }
    }

    //------------------------------------------------------- Kolejne Cw eventu

    class FileMonitor
    {
        public  EventHandler<string> ecentFirtsExist;
        public  EventHandler<string> ecentSecontExist;
        public void Monitor(string path)
        {


            if (File.Exists(path))
            {
                ecentFirtsExist?.Invoke(this, path);

            }
            else
            {
                ecentSecontExist?.Invoke(this, path);
            }
        }

        public  void PierwszaMetoda(object sender, string path)
        {
            Console.WriteLine($"{path} exists.");
        }

        public   void DrugaMetoda(object sender, string path)
        {
            Console.WriteLine($"{path} does not exist.");
        }
    }

    class ProgramMonitorowanie
    {
       

        static void Main()
        {
            FileMonitor monitor = new FileMonitor();
           monitor.ecentFirtsExist += monitor.PierwszaMetoda;
            monitor.ecentSecontExist += monitor.DrugaMetoda;

            monitor.Monitor("example.txt");
        }
    }
    //---------------------------------------------------------------------
    public class CounterEvent 
    {
        private int _count = 0;
        public void Increment()
        {
            _count++;
            Console.WriteLine($"Current count: {_count}");
        }
    }

    public class ProgramEvent
    {
        public delegate void DelegatDoEventu();
        public event DelegatDoEventu EventDoZAdania;
        public  void Main()
        {
            CounterEvent counter = new CounterEvent();
            EventDoZAdania += counter.Increment;

            for (int i = 0; i < 5; i++)
            {
                ObslugaZdarzenia();
            }
        }

        public void ObslugaZdarzenia ()
        {
            EventDoZAdania?.Invoke();
        }
    }

    //-----------------------------------------------------------------------
    public class Timer10
    {


        private bool _running = false;
        Program10 program10 = new Program10();
        public void Start()
        {
            _running = true;
            while (_running)
            {
                Thread.Sleep(1000);
                Tick();
            }
        }

        public void Stop()
        {
            _running = false;
        }

        private void Tick()
        {
            Console.WriteLine("Tick");

        }
    }

    public class Program10
    {
        //public delegate void Dellega();
        public event EventHandler DeleagatDoTimer10;


        Timer10 timer;
        public void Main()
        {
             timer = new Timer10();

            Thread timerThread = new Thread(timer.Start);
            timerThread.Start();

            DeleagatDoTimer10 += Zatrzymanie;

            Thread.Sleep(5000);

            DeleagatDoTimer10?.Invoke(this, EventArgs.Empty);

            
        }

        public void Zatrzymanie(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }

    // -------------------------------------------------------------------- Kolejny przykład
    public class TemperatureSensor
    {
        public event EventHandler PowiadomienieEventElo;

        private double _temperature;
      
        public void SetTemperature(double temperature)
        {
            PowiadomienieEventElo += PowiadomienieUstawienieJeden;
            PowiadomienieEventElo += PowiadomienieUstawienieDwa;


            _temperature = temperature;
            if (_temperature > 30)
            {
                PowiadomienieEventElo?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                PowiadomienieEventElo?.Invoke(this, EventArgs.Empty);
            }
        }
        public void PowiadomienieUstawienieJeden(Object sender, EventArgs e)
        {
            Console.WriteLine($"Warning: High temperature detected: {_temperature}°C");
        }

        public void PowiadomienieUstawienieDwa(Object sender, EventArgs s)
        {
            Console.WriteLine($"Temperatura poniżej 30 stopni {_temperature}°C");
        }
    }

    public class ProgramDoKolejnego
    {
        public static void Main()
        {
            TemperatureSensor sensor = new TemperatureSensor();

            
            sensor.SetTemperature(25);
            sensor.SetTemperature(35);
        }
    }
}
