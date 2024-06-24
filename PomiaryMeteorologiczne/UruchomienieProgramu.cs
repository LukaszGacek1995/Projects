namespace PomiaryMeteorologiczne
{
    //public class UruchomienieProgramu
    //{
    //    public static void Start()
    //    {
    //        DelegatWprowadzanieDanych delegatWprowadzanieDanych = LiczbaStacjiMeteorologicznych;
    //        ZasilanieDanymiWejsciowymi zasilanieDanymiWejsciowymi = new ZasilanieDanymiWejsciowymi(delegatWprowadzanieDanych);
    //        PrzeprowadzObliczenia przeprowadzObliczenia = new PrzeprowadzObliczenia();

    //        DaneWejscie(zasilanieDanymiWejsciowymi);
    //        Obliczanie(przeprowadzObliczenia);
    //        Wynik(przeprowadzObliczenia);
    //    }

    //    public static void DaneWejscie(ZasilanieDanymiWejsciowymi zasilanieDanymiWejsciowymi)
    //    {
    //        zasilanieDanymiWejsciowymi.WprowadzDane();
    //    }

    //    public static void Obliczanie(PrzeprowadzObliczenia przeprowadzObliczenia)
    //    {
    //        przeprowadzObliczenia.ObliczanieGlowne();
    //    }

    //    public static void Wynik(PrzeprowadzObliczenia przeprowadzObliczenia)
    //    {
    //        przeprowadzObliczenia.GenerujRaporty();
    //    }

    //    private static void LiczbaStacjiMeteorologicznych(out int N, out Dictionary<int, Tuple<int, int>> Slownik)
    //    {
    //        Console.WriteLine("Wprowadź liczbę stacji meteorologicznych");
    //        N = int.Parse(Console.ReadLine());

    //        Slownik = new Dictionary<int, Tuple<int, int>>();

    //        for (int i = 0; i < N; i++)
    //        {
    //            Console.WriteLine($"Wprowadź ID oraz współrzędne stacji {i + 1}:");
    //            int id = int.Parse(Console.ReadLine());
    //            int x = int.Parse(Console.ReadLine());
    //            int y = int.Parse(Console.ReadLine());
    //            Slownik.Add(id, new Tuple<int, int>(x, y));
    //        }
    //    }

    //}
}