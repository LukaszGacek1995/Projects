using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorządkowanieDomowejBiblioteki
{
    public interface IElementyInterface
    {
        public void WprowadzDane();
        public Dictionary<string, Tuple<int, int>> SlownikDanych { get; set; }
    }
}