using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    public class AttributeHelper
    {
        public string GetPropertyDisplayName<T>(string propertyName)
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty(propertyName);

            object attribute = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false)
                                           .FirstOrDefault();

            if (attribute == null)
            {
                return propertyInfo.Name;
            }
            else
            {
                return ((DisplayNameAttribute)attribute).DisplayName;
            }

        }
    }
}
