namespace Wyszukiwarka
{
    public static class KlasaStartowaProgramu
    {
        public static void Start()
        {
            ZasilDanymi zasilDanymi = new ZasilDanymi();
            string[] tablicaZdan = zasilDanymi.Dane();

            // TEN FRAGEMNT SOBIE PRZEANALIZOWAĆ
            List<string> listaZdan = zasilDanymi.ListaZZdaniami;
            List<string> lizstaSlowCustom = zasilDanymi.ListaZWprowadzonymiSlowamiUzytkownik;
            //
        }
    }
}