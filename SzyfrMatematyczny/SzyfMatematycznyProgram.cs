using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzyfrMatematyczny;

public class SzyfMatematycznyProgram
{
    public static void Uruchamianie()
    {
        WproadzanieDanychWejsciowych wproadzanieDanychWejsciowych = new WproadzanieDanychWejsciowych();
        wproadzanieDanychWejsciowych.GromadzenieDanych();

        RozszyfrowywanieKodu rozszyfrowywanieKodu = new RozszyfrowywanieKodu();
        DaneNaSztywno daneNaSztywno = new DaneNaSztywno();
        daneNaSztywno.Alfabet();

        rozszyfrowywanieKodu.RozszyfrowywanieZakonczone += HandleRozszyfrowanieZakonczone;

        rozszyfrowywanieKodu.Rozszyfrowyanie(wproadzanieDanychWejsciowych.ListaSzyftow,daneNaSztywno.SlownikWartosciNaSztywno);
        Console.ReadKey();
    }

    private static void HandleRozszyfrowanieZakonczone(string wynik)
    {
        Console.WriteLine($"Rozzszyforwyanie zakończone, wynik: {wynik} ");
    }
}