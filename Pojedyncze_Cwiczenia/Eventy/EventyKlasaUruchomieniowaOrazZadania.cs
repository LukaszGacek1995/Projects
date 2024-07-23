using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class Program
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

}
