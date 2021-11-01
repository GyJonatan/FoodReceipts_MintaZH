using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MintaZH
{
    public class Refigerator
    {
        [DisplayName("Márka")]
        public string Brand { get; set; }

        [DisplayName("Kapacitás")]
        public int Capacity { get; set; }

        public List<Product> Products { get; set; }

        public static Refigerator LoadXml(string path)
        {
            XDocument doc = XDocument.Load(path);
            XElement fridgeXml = doc.Element("refigerator");

            var products = from productNode in fridgeXml.Descendants("product")
                           select new Product()
                           {
                               Amount = int.Parse(productNode.Attribute("amount").Value),
                               Name = (string)productNode.Value
                           };
            
            Refigerator frigo = new Refigerator
            {
                Brand = (string)fridgeXml.Attribute("brand"),
                Capacity = (int)fridgeXml.Attribute("capacity"),
                Products = products.ToList()
            };

            /*foreach (var item in fridgeXml.Descendants("product"))
            {
                frigo.Products.Add(new Product()
                {
                    Name = item.Value,
                    Amount = int.Parse(item.Attribute("amount").Value)
                });
            }*/
            

            return frigo;
        }
    }
}
