using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace GrupowanieKontaktow
{
    public class ZasilanieDanych
    {
        public Dictionary<string, int[]> slownikImieLiczby;
        public int N { get; set; }
        public int M { get; set; }


        public Dictionary<string, int[]> DaneWejsciowe()
        {
            Console.WriteLine("Wprowadź długość listy kontaktów oraz ilość grup (oddzielone spacją, maksymalnie 1000 i 500)");

            int count = 0;

            slownikImieLiczby = new Dictionary<string, int[]>();

            while (count < 20)
            {
                string[] wprowadzoneWartosci = Console.ReadLine().Trim().Split(' ');

                N = int.Parse(wprowadzoneWartosci[0]);
                M = int.Parse(wprowadzoneWartosci[1]);

                if (N == 0 && M == 0)
                {
                    Console.WriteLine("Wybrano wartości 0 dla N i M - zakończenie testów");
                    break;
                }

                if (N > 1000 || M > 500)
                {
                    Console.WriteLine("Przekroczono maksymalny rozmiar dla N lub M. Wprowadź ponownie.");
                    continue;
                }

                for (int i = 0; i < N; i++)
                {
                    DzialanieJednegoTestu(slownikImieLiczby);
                }

                count++;
            }

            if (count >= 20)
            {
                Console.WriteLine("Osiągnięto limit 20 testów.");
            }

            return slownikImieLiczby;
        }
        public void DzialanieJednegoTestu(Dictionary<string, int[]> slownikImieLiczby)
        {
            
            string[] imieOrazCyfry = Console.ReadLine().Split(' ');
            string imie = imieOrazCyfry[0];

            int[] cyfryPoImieniu = new int[imieOrazCyfry.Length - 1];

            for (int i = 1; i < imieOrazCyfry.Length; i++)
            {
                cyfryPoImieniu[i - 1] = int.Parse(imieOrazCyfry[i]);
            }

            slownikImieLiczby.Add(imie, cyfryPoImieniu);
        }
    }
}