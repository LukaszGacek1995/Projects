namespace Wyszukiwarka
{
    public static class KlasaStartowaProgramu
    {
        public static void Start()
        {
            ZasilDanymi zasilDanymi = new ZasilDanymi();
            zasilDanymi.Dane();

            LicznikWystapienSlowaDelegate licznikDelegatu = new LicznikWystapienSlowaDelegate(LicznikWystapienSlowaMetoda);

            MechanikaSprawdzania mechanikaSprawdzania = new MechanikaSprawdzania(zasilDanymi, licznikDelegatu);
            mechanikaSprawdzania.MechanizmSprawdzania();

            List<int> wyniki = mechanikaSprawdzania.tablicaWartosciWynikowych;
            List<string> zdania = zasilDanymi.ListaZZdaniami;

            for (int i = 0; i < wyniki.Count; i++)
            {
                Console.WriteLine($"{wyniki[i]}");
            }

            Console.ReadKey();
        }
        public static int LicznikWystapienSlowaMetoda(string zadanie, string slowo)
        {
            return int.Parse(slowo);
        }
    }
}