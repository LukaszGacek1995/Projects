using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        ParametryWejsciowe parametry = new ParametryWejsciowe();
        var listaParametrow = parametry.Wprowadzenie();

        MechanizmSprawdzaniaPozycjiLogika mechanizmSprawdzaniaPozycjiLogika = new MechanizmSprawdzaniaPozycjiLogika();
        var logika = mechanizmSprawdzaniaPozycjiLogika.GlownaLogika(listaParametrow);

        foreach (var iteracjaWyniku in logika)
        {
            Console.WriteLine(iteracjaWyniku);
        }

        Console.ReadKey();
    }
}