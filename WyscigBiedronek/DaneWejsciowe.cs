using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WyscigBiedronek
{
    internal class DaneWejsciowe
    {
        public void WprowadzDane()
        {
            //3
            List<Tuple<int, int, int>> wspolrzedneBiedronek = new List<Tuple<int, int, int>>();

            Console.WriteLine("Proszę wprowadzić liczb biedronek biorących udział w wyścigu");
            //1
            int liczbaBiedronek = int.Parse(Console.ReadLine());

            Console.WriteLine("Proszę wprowadzić wpółrzędne mety");
            string[] wspStringMety = Console.ReadLine().Split(' ');
            int[] wspIntMety = new int[wspStringMety.Length];
            //2
            Tuple<int, int, int> wspolrzedneMety = new Tuple<int, int, int>(wspIntMety[0], wspIntMety[1], wspIntMety[2]);

            if (wspStringMety.Length == 3)
            {
                wspIntMety[0] = int.Parse(wspStringMety[0]);
                wspIntMety[1] = int.Parse(wspStringMety[1]);
                wspIntMety[2] = int.Parse(wspStringMety[2]);
            }
            else
            {
                Console.WriteLine("Wybrano zbytmało lub zbyt dużo cyfr, spróbuj ponowie wprowadzić wartości");
            }

            Console.WriteLine("Wprowadz współrzędne startu biedronek");

            for (int i = 0; i < liczbaBiedronek; i++)
            {
                string wpro = Console.ReadLine();
                string[] wproString = wpro.Split(' ');
                int[] wprowadzenieInt = new int[wproString.Length];

                if (wproString.Length == 3)
                {
                    wprowadzenieInt[0] = int.Parse(wproString[0]);
                    wprowadzenieInt[1] = int.Parse(wproString[1]);
                    wprowadzenieInt[2] = int.Parse(wproString[2]);
                    Tuple<int, int, int> ddf = new Tuple<int, int, int>(wprowadzenieInt[0], wprowadzenieInt[1], wprowadzenieInt[2]);
                    wspolrzedneBiedronek.Add(ddf);

                }
                else
                {
                    Console.WriteLine("Wybrano zbytmało lub zbyt dużo cyfr, spróbuj ponowie wprowadzić wartości");
                }
                Tuple<int, int, int> dd = new Tuple<int, int, int>(wprowadzenieInt[0], wprowadzenieInt[1], wprowadzenieInt[2]);
            }
            Tuple<int, List<Tuple<int, int, int>>, Tuple<int, int, int>> UczesnicyWspolrzeneMeta = new Tuple<int, List<Tuple<int, int, int>>, Tuple<int, int, int>>(liczbaBiedronek, wspolrzedneBiedronek, wspolrzedneMety);

        }
    }
}

