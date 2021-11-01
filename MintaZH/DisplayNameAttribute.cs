using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    [AttributeUsage(AttributeTargets.Property)]
    class DisplayNameAttribute : Attribute
    {
        public string DisplayName { get; private set; }
        public DisplayNameAttribute(string displayName)
        {
            this.DisplayName = displayName;
        }
    }
}
