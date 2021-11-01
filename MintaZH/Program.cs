using System;
using System.Linq;

namespace MintaZH
{
    class Program
    {
        static void Main(string[] args)
        {
            FoodReceiptsContext context = new FoodReceiptsContext();
            Refigerator frigo = Refigerator.LoadXml("frigo.xml");
            AttributeHelper helper = new AttributeHelper();
            
            // a. feladat
            Console.WriteLine($"Number of Receipts: {context.Receipts.Count()}");

            // b. feladat
            Console.WriteLine("Seductive receipts:");
            /*
            foreach (Receipts receipt in context.Receipts)
            {
                if (receipt.IsSeductive)
                {
                    Console.WriteLine($"{receipt.Name}, ID: {receipt.Id}");
                }
            }
            */

            foreach (Receipts receipt in context.Receipts.Where(x => x.IsSeductive))
            {
                Console.WriteLine($"{receipt.Name}, ID: {receipt.Id}");
            }

            // c. feladat
            Console.WriteLine("Receipts that need Oil:");
            foreach (Receipts receipt in 
                context.Receipts.Where(x => x.Ingredients.Any(y => y.Name.ToLower() == "olaj"))
                .OrderByDescending(x => x.Price))
            {
                Console.WriteLine($"{receipt.Name}, ID: {receipt.Id}");
            }

            // d. feladat
            Console.WriteLine("Needed amount if we were to make every receipt:");
            foreach (var ingredient in 
                context.Receipts
                       .SelectMany(x => x.Ingredients)
                       .GroupBy(x => x.Name)
                       .Select(x => new { Name = x.Key, Count = x.Sum(y => y.Amount) })
                       .OrderBy(x => x.Count))
            {
                Console.WriteLine($"{ingredient.Name}, Amount: {ingredient.Count}");
            }

            // e. feladat
            Console.WriteLine("Products in the refigerator:");
            foreach (Product product in frigo.Products)
            {
                Console.Write($"{helper.GetPropertyDisplayName<Product>(nameof(product.Name))}: {product.Name}");
                Console.Write($"{helper.GetPropertyDisplayName<Product>(nameof(product.Amount))}: {product.Amount}\n");
            }

            Console.ReadLine();
        }
    }
}
