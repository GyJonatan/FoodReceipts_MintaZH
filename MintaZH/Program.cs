using System;
using System.Linq;

namespace MintaZH
{
    /*
     a) Hozzon létre egy Service-based Database-t FoodReciepts néven! (0,5 pont)
            Csak hozzá kell adnunk egy új itemet, ami egy service-based database.
            Állítsuk a Build Actiont contentre és a Copy to Outputot Copy alwaysre
            a .mdf és a .ldf fájl esetében.
     */

    class Program
    {
        static void Main(string[] args)
        {
            FoodReceiptsContext context = new FoodReceiptsContext();
            Refigerator frigo = Refigerator.LoadXml("frigo.xml");
            AttributeHelper helper = new AttributeHelper();

            //a) Mennyi recept van az adatbázisban? (1,5 pont)
            Console.WriteLine($"Number of Receipts: {context.Receipts.Count()}\n");

            //b) Jelenítse meg a konzolon a csajozós recepteket! (1,5 pont)
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
                Console.WriteLine($"{receipt.Name},\tID: {receipt.Id}");
            }

            /*
             c) Rendezze be ár szerint csökkenő módon azokat a recepteket, amelyek alapanyagai között található Olaj
                megnevezésű alapanyag! (4 pont)
             */
            Console.WriteLine("\nReceipts that need Oil:");
            foreach (Receipts receipt in 
                context.Receipts.Where(x => x.Ingredients.Any(y => y.Name.ToLower() == "olaj"))
                .OrderByDescending(x => x.Price))
            {
                Console.WriteLine($"{receipt.Name},\tID: {receipt.Id}");
            }

            /*
             d) Amennyiben elkészítenénk az összes receptet, melyik alapanyagból mennyire lenne szükségünk? Az
                eredményben az alapanyag nevét és összesített darabszámát jelenítse meg oly módon, hogy az összesített
                mennyiség szerint növekvő módon jelenjen meg! (3 pont)
             */
            Console.WriteLine("\nNeeded amount if we were to make every receipt:");
            foreach (var ingredient in 
                context.Receipts
                       .SelectMany(x => x.Ingredients)
                       .GroupBy(x => x.Name)
                       .Select(x => new { Name = x.Key, Count = x.Sum(y => y.Amount) })
                       .OrderBy(x => x.Count))
            {
                Console.WriteLine($"{ingredient.Name},\tAmount: {ingredient.Count}");
            }

            /*
             e) Jelenítse meg a konzolon a hűtő tartalmát. (1 pont) A megjelenítés során alkalmazza a termék
                tulajdonságain eltárolt DisplayName attribútum értékét! (2,5 pont)
             */
            Console.WriteLine("\nProducts in the refigerator:");
            foreach (Product product in frigo.Products)
            {
                Console.Write($"{helper.GetPropertyDisplayName<Product>(nameof(product.Name))}: {product.Name}");
                Console.Write($"\t{helper.GetPropertyDisplayName<Product>(nameof(product.Amount))}: {product.Amount}\n");
            }

            Console.ReadLine();
        }
    }
}
