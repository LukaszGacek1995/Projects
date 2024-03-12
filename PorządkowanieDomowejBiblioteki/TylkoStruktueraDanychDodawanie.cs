using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorządkowanieDomowejBiblioteki
{
    public class TylkoStruktueraDanychDodawanie : IElementyInterface
    {
        public Dictionary<Tuple<int, int>, string> SlownikDanych { get; set; }
        public void WprowadzDane()
        {

        }
    }
}
