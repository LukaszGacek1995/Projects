//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace PomiaryMeteorologiczne
//{
//    public delegate void DelegatPrzekazanieTworzeniePomiaru(string[] tablicaTrzechDanychDlaPDelegat);
//    public delegate void DelegatePrzekazanieTworzenieRaportu(string[] tablicaTrzechDanychDlaRDelegate2);
//    public delegate void DelegatWprowadzanieDanych(out int N, out Dictionary<int, Tuple<int, int>> Slownik);

//    public abstract class WprowadzanieKlasaBase
//    {
//        public abstract string ZasilanieDanymi();
//    }

//    public class ZasilanieDanymiWejsciowymi : WprowadzanieKlasaBase
//    {
//        public const string P = "P";
//        public const string R = "R";

//        private int liczbaStacjiPomiarowych;
//        public Dictionary<int, Tuple<int, int>> WspolrzedneKazdejStacji;
//        public DelegatWprowadzanieDanych delegatWprowadzanieDanych;

//        public Dictionary<int, List<double>> DanePomiarow { get; private set; }
//        public List<Tuple<int, int, double>> DaneRaportu { get; private set; }

//        public ZasilanieDanymiWejsciowymi(DelegatWprowadzanieDanych wprowadzanieDanych)
//        {
//            WspolrzedneKazdejStacji = new Dictionary<int, Tuple<int, int>>();
//            DanePomiarow = new Dictionary<int, List<double>>();
//            DaneRaportu = new List<Tuple<int, int, double>>();
//            delegatWprowadzanieDanych = wprowadzanieDanych;
//        }

//        public void WprowadzDane()
//        {
//            delegatWprowadzanieDanych(out liczbaStacjiPomiarowych, out WspolrzedneKazdejStacji);
//        }

//        public override string ZasilanieDanymi()
//        {
//            return "Wprowadz wspolrzedne stacji pomiarowych";
//        }

//        public void PrzetworzWejscieDanych(string wejscie)
//        {
//            var daneWStringu = wejscie.Split(' ');

//            if (daneWStringu.Length > 0)
//            {
//                if (daneWStringu[0].ToLower().Contains(P.ToLower()))
//                {
//                    WprowadzPomiar(daneWStringu);
//                }
//                else if (daneWStringu[0].ToLower().Contains(R.ToLower()))
//                {
//                    WprowadzRaport(daneWStringu);
//                }
//            }
//        }

//        public void WprowadzPomiar(string[] tablicaTrzechDanychDlaPDelegat)
//        {
//            if (tablicaTrzechDanychDlaPDelegat.Length != 3)
//            {
//                Console.WriteLine("Nieprawidłowe dane wejściowe do pomiaru.");
//                return;
//            }

//            if (!int.TryParse(tablicaTrzechDanychDlaPDelegat[1], out int stacjaID) ||
//                !double.TryParse(tablicaTrzechDanychDlaPDelegat[2], out double temperatura))
//            {
//                Console.WriteLine("Nieprawidłowe dane wejściowe do pomiaru.");
//                return;
//            }

//            if (!DanePomiarow.ContainsKey(stacjaID))
//            {
//                DanePomiarow[stacjaID] = new List<double>();
//            }

//            DanePomiarow[stacjaID].Add(temperatura);
//        }

//        public void WprowadzRaport(string[] tablicaTrzechDanychDlaRDelegate2)
//        {
//            if (tablicaTrzechDanychDlaRDelegate2.Length != 5)
//            {
//                Console.WriteLine("Nieprawidłowe dane wejściowe do raportu.");
//                return;
//            }

//            if (!int.TryParse(tablicaTrzechDanychDlaRDelegate2[1], out int d1) ||
//                !int.TryParse(tablicaTrzechDanychDlaRDelegate2[2], out int d2) ||
//                !int.TryParse(tablicaTrzechDanychDlaRDelegate2[3], out int a1) ||
//                !int.TryParse(tablicaTrzechDanychDlaRDelegate2[4], out int a2))
//            {
//                Console.WriteLine("Nieprawidłowe dane wejściowe do raportu.");
//                return;
//            }

//            double min = double.MaxValue;
//            double max = double.MinValue;
//            double suma = 0;
//            int liczbaElementow = 0;

//            foreach (var pomiar in DanePomiarow)
//            {
//                int idStacji = pomiar.Key;
//                int x = WspolrzedneKazdejStacji[idStacji].Item1;
//                int a = WspolrzedneKazdejStacji[idStacji].Item2;

//                if ((d1 <= x && x <= d2 && a1 <= a && a <= a2) ||
//                    (d1 <= x && x <= d2 && (a >= a1 || a <= a2 + 360)))
//                {
//                    foreach (var temperatura in pomiar.Value)
//                    {
//                        if (temperatura < min)
//                            min = temperatura;
//                        if (temperatura > max)
//                            max = temperatura;
//                        suma += temperatura;
//                        liczbaElementow++;
//                    }
//                }
//            }

//            if (liczbaElementow == 0)
//            {
//                Console.WriteLine(EnumWaertosci.BRAK_DANYCH);
//            }
//            else
//            {
//                double avg = suma / liczbaElementow;
//                Console.WriteLine($"{min:F1} {max:F1} {avg:F6}");
//            }
//        }

//        public void ObliczSrednia()
//        {
//            foreach (var raport in DaneRaportu)
//            {
//                double suma = 0;
//                int liczbaElementow = 0;
//                foreach (var temp in DanePomiarow[raport.Item1])
//                {
//                    suma += temp;
//                    liczbaElementow++;
//                }
//                double srednia = liczbaElementow == 0 ? 0 : suma / liczbaElementow;
//                Console.WriteLine($"{raport.Item1} {raport.Item2} {srednia:F6}");
//            }
//        }

//        public void ObliczMax()
//        {
//            foreach (var raport in DaneRaportu)
//            {
//                double max = double.MinValue;
//                foreach (var temp in DanePomiarow[raport.Item1])
//                {
//                    if (temp > max)
//                        max = temp;
//                }
//                Console.WriteLine($"{raport.Item1} {raport.Item2} {max:F1}");
//            }
//        }

//        public void ObliczMin()
//        {
//            foreach (var raport in DaneRaportu)
//            {
//                double min = double.MaxValue;
//                foreach (var temp in DanePomiarow[raport.Item1])
//                {
//                    if (temp < min)
//                        min = temp;
//                }
//                Console.WriteLine($"{raport.Item1} {raport.Item2} {min:F1}");
//            }
//        }
//    }
////}
//}


