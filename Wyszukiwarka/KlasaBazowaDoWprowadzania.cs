using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wyszukiwarka
{
 //Będzie do dziedziczenia 
    internal abstract class KlasaBazowaDoWprowadzania
    {
        public virtual string Komenda1()
        {
           
          return "Wprowadź Dane";
        }
        public virtual string Komenda2() 
        {
          return "Przekroczono zakres, spróbuj jeszcze raz";
        }
    }
}
