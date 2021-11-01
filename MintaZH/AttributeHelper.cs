using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    /*
     a) Készítsen egy Helper osztályt AttributeHelper néven, mely képes visszaadni egy tulajdonság megjelenítési
        nevét. Ha a tulajdonságnak nincs DisplayName attribútuma, akkor a tulajdonság nevét adjuk vissza. (4 pont)
        Segítség: GetPropertyDisplayName<T>(string propertyName), ahol T az osztály, amely tulajdonságát
        szeretnénk kifejezni, propertyName a tulajdonság neve, melynek a DisplayName attribútumát szeretnénk
        megjeleníteni.

        Meghívásra példa: 
                AttributeHelper helper = new AttributeHelper();
                helper.GetPropertyDisplayName<Product>(nameof(Product.Name));
     */
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
