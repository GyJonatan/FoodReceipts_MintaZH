using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    //b) Készítse el úgy az attribútumot, hogy tulajdonságokon lehessen egyedül alkalmazni! (0,5 pont)
    [AttributeUsage(AttributeTargets.Property)]



    //a) Hozzon létre egy attribútumot DisplayName néven! (0,5 pont)
    class DisplayNameAttribute : Attribute
    {
        /*
        c) Legyen egy nyilvános tulajdonsága, amelyben a megjelenítési nevet lehet eltárolni. (0,5 pont) 
           Ezt az értéket az attribútum konstruktorában is értékül lehessen adni. (0,5 pont)
        */
        public string DisplayName { get; private set; }
        public DisplayNameAttribute(string displayName)
        {
            this.DisplayName = displayName;
        }
    }
}
