using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobus
{
    internal class DaneWejscioweWprowadzenie
    {
        public int T1 { get; set; }
        public int T2 { get; set; }
        public int M { get; set; }
        public int N1 { get; set; }
        public int N2 { get; set; }

        List<int> listaDanychWejsciowych = new List<int>();

        public List<int> Wprowadzenie()
        {
            Console.WriteLine("Wprowadź dane wejściowe: chwila przybycia(miejsce spotkania), chwila przybycia kolegi," +
                              "liczba przystanków, liczba autobusów Z ZAJEZDNI, liczba autobusów DO ZAJEZDNI");
            Console.WriteLine("Wprowadzone wartości oddziel spacjami");

            string[] wartosciTablicaString = Console.ReadLine().Split(' ');

            if (!WprowadzDane(wartosciTablicaString))
            {
                Console.WriteLine("Błąd w wprowadzonych danych. Spróbuj jeszcze raz.");
              
                return null;
            }

            List<Tuple<int, int, int>> rozkladJazdy = RozkladJazdy(M);

            return listaDanychWejsciowych;
        }

        private bool WprowadzDane(string[] wartosciTablicaString)
        {
            try
            {
                T1 = int.Parse(wartosciTablicaString[0]);
                T2 = int.Parse(wartosciTablicaString[1]);
                M = int.Parse(wartosciTablicaString[2]);
                N1 = int.Parse(wartosciTablicaString[3]);
                N2 = int.Parse(wartosciTablicaString[4]);

                if (WalidujDane())
                {
                    listaDanychWejsciowych.Add(T1);
                    listaDanychWejsciowych.Add(T2);
                    listaDanychWejsciowych.Add(M);
                    listaDanychWejsciowych.Add(N1);
                    listaDanychWejsciowych.Add(N2);
                    return true;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd w formacie danych. Spróbuj jeszcze raz.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Wprowadzona wartość przekracza dopuszczalny zakres. Spróbuj jeszcze raz.");
            }
            
            return false;
        }

        private bool WalidujDane()
        {
            if (T1 >= 0 && T1 <= 10000 && T2 >= 0 && T2 <= 10000 &&
                M >= 2 && M <= 100 && M * (N1 + N2) <= 10000 && M > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Wprowadzono wartości z poza zakresu, spróbuj jeszcze raz");
                return false;
            }
        }

        public List<Tuple<int,int,int>> RozkladJazdy(int M)
        {
            Console.WriteLine("Proszę wprowadzić rozkład jazdy");


        List<Tuple<int, int, int>> rozkladyJazdy = new List<Tuple<int, int, int>>();

            for (int i = 0; i < M; i++)
            {
                string[] stringTuplaRozkladJazdy = Console.ReadLine().Split(' ');
                int[] intTupleRozkladJazdy = new int[stringTuplaRozkladJazdy.Length];

                for (int j = 0; j < M; j++)
                {
                    intTupleRozkladJazdy[j] = int.Parse(stringTuplaRozkladJazdy[j]);
                }

                var rozklad = new Tuple<int, int, int>(intTupleRozkladJazdy[0], intTupleRozkladJazdy[1], intTupleRozkladJazdy[2]);

                rozkladyJazdy.Add(rozklad);
            }

            return rozkladyJazdy;       
        }
    }
}
