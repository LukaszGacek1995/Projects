namespace Warsztat
{
    public class KlasaUruchamiajacaWarsztat
    {

        public static void StartKlasaWarsztat()
        {
            Warsztat warsztat = new Warsztat();
            warsztat.DodanieSamochcoduDoWarsztatu();

            Samochod samochod = new Samochod();
            samochod.MonitorowaniePrzebieguSamochodu();



        }
    }
}
