using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    public class Product
    {
        [DisplayName("Név")]
        public string Name { get; set; }
        [DisplayName("Mennyiség")]
        public int Amount { get; set; }
    }
}
