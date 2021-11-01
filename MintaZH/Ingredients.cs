using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    /*
     b) CodeFirst módszerrel hozza létre az előző pontban létrehozott adatbázisban a Receipts és Ingredients táblát
        (3 pont)

              b. Ingredients oszlopai az alábbiak:
                i. Id (int) – elsődleges kulcs, adatbázis által növelt (auto increment) érték legyen;
                ii. Name (string) – alapanyag megnevezése. Legfeljebb 50 hosszú, kötelező mező;
                iii. Amount (int) – alapanyag mennyisége;
                iv. ReceiptId (int) – recept azonosító.
     */


    [Table("Ingredients")]
    public class Ingredients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Amount { get; set; }

        /*
        c) Állítsa be a szükséges paramétereket az adatbázis kapcsolathoz, és a táblák 
           között is definiálja a külsőkulcs függőségeket. 
           Adjon lehetőséget a LazyLoad módszer alkalmazására. (4 pont) 
        */
        [Required]
        [ForeignKey(nameof(Receipts))]
        public int ReceiptsId { get; set; }

       
        [NotMapped]
        public virtual Receipts Receipts { get; set; }

        public Ingredients()
        {

        }
    }
}
