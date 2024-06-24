//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//public delegate void DelegatPrzekazaniePrzeliczanie(Dictionary<int, Tuple<int, int>> stacjaWspolrzedneWszystkie);

//namespace PomiaryMeteorologiczne
//{

//    internal class PrzeprowadzObliczenia : ObliczanieKlasaBase
//    {
//        private ZasilanieDanymiWejsciowymi zasilanieDanymiWejsciowymi;

//        public PrzeprowadzObliczenia()
//        {
//            zasilanieDanymiWejsciowymi = new ZasilanieDanymiWejsciowymi(LiczbaStacjiMeteorologicznych);
//        }

//        public void ObliczanieGlowne()
//        {
//            Dictionary<int, Tuple<int, int>> wspolrzedneKazdejStacji = zasilanieDanymiWejsciowymi.WspolrzedneKazdejStacji;

//            PrzeliczWartosciMatematyczne(wspolrzedneKazdejStacji);
//        }

//        private void PrzeliczWartosciMatematyczne(Dictionary<int, Tuple<int, int>> wspolrzedneKazdejStacji)
//        {
//            zasilanieDanymiWejsciowymi.ObliczMin();
//            zasilanieDanymiWejsciowymi.ObliczMax();
//            zasilanieDanymiWejsciowymi.ObliczSrednia();
//        }

//        public void GenerujRaporty()
//        {
//            zasilanieDanymiWejsciowymi.ObliczSrednia();
//            zasilanieDanymiWejsciowymi.ObliczMax();
//            zasilanieDanymiWejsciowymi.ObliczMin();
//        }

//        internal override Tuple<double, double, double, float> WyliczanieWartosci()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
