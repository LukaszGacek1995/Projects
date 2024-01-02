using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrMatematyczny
{
    internal class DaneNaSztywno
    {
       private readonly Dictionary<int, char> slownikWartosciNaSztywno  = new Dictionary<int, char>();

        public Dictionary<int, char> SlownikWartosciNaSztywno
        {
            get
            {
                return slownikWartosciNaSztywno;
            }
        }

        public void Alfabet()
        {            
            string literyAlfabetuString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] literyAlfabetu = literyAlfabetuString.ToCharArray();
            

            for (int i = 0; i <literyAlfabetu.Length; i++)
            {
                char litry = literyAlfabetu[i];
                slownikWartosciNaSztywno.Add(i + 1, litry);
            }
        }
    }
}
