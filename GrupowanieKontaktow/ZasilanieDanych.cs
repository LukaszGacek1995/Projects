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
        public Dictionary<string, int[]> DaneWejsciowe()
        {
            Console.WriteLine("Wprowadź długość listy kontaktów oraz ilość grup (oddzielone spacją, maksymalnie 1000 i 500)");

            Dictionary<string, int[]> slownikImieLiczby = new Dictionary<string, int[]>();

            while (true)
            {
                string[] wprowadzoneWartosci;
                try
                {
                    wprowadzoneWartosci = Console.ReadLine().Trim().Split(' ');
                    if (wprowadzoneWartosci.Length < 2)
                    {
                        Console.WriteLine("Wprowadzono zbyt mało wartości");
                        continue;
                    }

                    int N = int.Parse(wprowadzoneWartosci[0]);
                    int M = int.Parse(wprowadzoneWartosci[1]);

                    if (N == 0 && M == 0)
                    {
                        Console.WriteLine("Zakończono testy.");
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
                }
                catch (FormatException)
                {
                    Console.WriteLine("Błędne dane wejściowe. Spróbuj ponownie.");
                }
            }

            return slownikImieLiczby;
        }
        public void DzialanieJednegoTestu(Dictionary<string, int[]> slownikImieLiczby)
        {
            string input = Console.ReadLine();

            string[] imieOrazCyfry = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string imie = imieOrazCyfry[0];

            int[] cyfryPoImieniu = new int[imieOrazCyfry.Length - 1];

            for (int i = 1; i < imieOrazCyfry.Length; i++)
            {
                if (!int.TryParse(imieOrazCyfry[i], out cyfryPoImieniu[i - 1]))
                {
                    Console.WriteLine("Błędne dane wejściowe");
                    return;
                }
            }

            slownikImieLiczby.Add(imie, cyfryPoImieniu);
        }
    }
}