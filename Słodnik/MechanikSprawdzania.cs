using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Słodnik
{
    internal class MechanikSprawdzania
    {
        public List<string> tablicaAdd { get; set; }


        public void GlwonyMechanizmDzialania(List<string> tablicaKomend)
        {
           List<string> listaADD = new List<string>();
            
           logikaPoczatkowychKomend(tablicaKomend);
        }

        public void logikaPoczatkowychKomend(List<string> tablicaKomend)
        {
            string add = "add";
            tablicaAdd = new List<string>();

            

            foreach (string s in tablicaKomend) 
            {
                //Przeanalizować ten fragemnt kodu
                int indexADD = s.IndexOf(add) + s.Length;
                string pozostalyText = s.Substring(indexADD).Trim();
                //--------
                if (s.Contains(add))
                {
                    tablicaAdd.Add(pozostalyText);
                }

            }
        }

        public static void MetodaTablic()
        {

        }

    }
}
