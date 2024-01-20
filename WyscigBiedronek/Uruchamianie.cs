using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WyscigBiedronek
{

    //JEST MODYFIKACJA
    ////-PIERWSZYM WIERSZU JEST LICZBA BIEDRODNE 
    //  -DRUGIM WSPOLRZENE METY
    //  -KOLEJNYCH WSPOLRZENE STARTU BIEDRONEK 

    public class Uruchamianie
    {
        public static void UruchamianieProgramu()
        {
            DaneWejsciowe daneWejsciowe = new DaneWejsciowe();
            Tuple<int, List<Tuple<int, int, int>>, Tuple<int, int, int>> wejscieDane = daneWejsciowe.WprowadzDane();


            ObliczanieIleZostalo obliczanieIleZostalo = new ObliczanieIleZostalo();
            int liczba = obliczanieIleZostalo.ObliczenieKoncowe(wejscieDane);


            Console.WriteLine($"Maksymalna liczba biedronek pozostałych to {liczba}");
            Console.ReadKey();
        }

    }
}