namespace GrupowanieKontaktow
{
    public class KlasaUruchomieniowa
    {

        public static void UruchomProgrma()
        {
            ZasilanieDanych zasilanieDanych = new ZasilanieDanych();
            Dictionary<string, int[]> listaDanych =  zasilanieDanych.DaneWejsciowe();

            WeryfikacjaOrazTworzenieGrup weryfikacjaOrazTworzenieGrup = new WeryfikacjaOrazTworzenieGrup();
            weryfikacjaOrazTworzenieGrup.MechanizmPrzydzielaniaGrup();
           int wynik = weryfikacjaOrazTworzenieGrup.MechanizmLiczeniaNajwiekszejGrupy();

            Console.Write(wynik);

            Console.ReadKey();
        }
    }
}