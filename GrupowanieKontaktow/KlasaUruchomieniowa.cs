namespace GrupowanieKontaktow
{
    public class KlasaUruchomieniowa
    {

        public static void UruchomProgrma()
        {
            ZasilanieDanych zasilanieDanych = new ZasilanieDanych();
            Dictionary<string, int[]> listaDanych = zasilanieDanych.DaneWejsciowe();

            WeryfikacjaOrazTworzenieGrup weryfikacjaOrazTworzenieGrup = new WeryfikacjaOrazTworzenieGrup(listaDanych);
            int wynik = weryfikacjaOrazTworzenieGrup.MechanizmLiczeniaNajwiekszejGrupy();

            Console.Write(wynik);

            Console.ReadKey();
        }
    }
}