namespace PorządkowanieDomowejBiblioteki
{
    public class KlasaStartowa
    {
        public TylkoStruktueraDanychDodawanie klasaZDanymi { get; set; }

        public KlasaStartowa()
        {
            klasaZDanymi = new TylkoStruktueraDanychDodawanie();
        }

        public static void UruchomProgram()
        {
            var klasaZDanymi = new KlasaStartowa();
             klasaZDanymi.klasaZDanymi.WprowadzDane();

            //Dictionary<string, Tuple<int, int>> slownikZDanymi = klasaZDanymi.klasaZDanymi.SlownikDanych;
            int liczbaTestow = klasaZDanymi.klasaZDanymi.liczbaTestow;
            MechanizmDzialaniaIObliczanie mechanizmDzialaniaIObliczanie = new MechanizmDzialaniaIObliczanie();
            for (int i = 0; i < liczbaTestow; i++)
            {
                int wynik = mechanizmDzialaniaIObliczanie.WynikObliczenia();
                Console.WriteLine(wynik);
            }
            Console.ReadKey();
        }
    }
}