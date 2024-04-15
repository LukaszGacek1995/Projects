using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wyszukiwarka
{
    internal interface IElementyWyszukiwarki
    {
         public void MechanizmSprawdzania();
         public string ZwracanieDanych();
        public string testowaWlasciwosc { get; set; }
    }
}
