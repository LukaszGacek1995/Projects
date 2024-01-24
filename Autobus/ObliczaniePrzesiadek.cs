using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobus
{
    internal class ObliczaniePrzesiadek
    {
        public void Przesiadki(List<int> danewejsioweCztery, List<Tuple<int, int, int>> rozkłady)
        {
            int T1 = danewejsioweCztery[0];
            int T2 = danewejsioweCztery[1];
            int M = danewejsioweCztery[2];
            int N1 = danewejsioweCztery[3];
            int N2 = danewejsioweCztery[4];


            List<Tuple<int, int, int>> posortowaneRozkładu = rozkłady.OrderBy(z => z.Item1).ToList();

            int najkrotszyCzas = int.MinValue;

            for (int i = 0; i < M; i++)
            {

                int czasOczekiwania = Math.Max(0, posortowaneRozkładu[i].Item1 - T1);
                int czasPodrozy = 0;
                int czasPrzesiadki = 0;

                for(int j = i; j<M; j++)
                {
                    if (posortowaneRozkładu[j].Item3 > N1)
                    {
                        czasPodrozy = posortowaneRozkładu[j].Item1 - posortowaneRozkładu[i].Item1;
                        czasPodrozy = Math.Max(0, posortowaneRozkładu[j].Item1 - posortowaneRozkładu[i].Item2);
                        break; 
                    }
                }
                int calkowityCzas = czasOczekiwania + czasPodrozy + czasPrzesiadki;
                if (posortowaneRozkładu[i].Item2 <= T2 && calkowityCzas < najkrotszyCzas)
                {
                    najkrotszyCzas = calkowityCzas;
                }
            }
            Console.WriteLine($"Najkrótszy czas oczekiwania to {najkrotszyCzas}");
        }
    }
}
