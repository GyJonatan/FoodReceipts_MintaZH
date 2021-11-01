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

            a. Receipts oszlopai az alábbiak:
                i. Id (int) – elsődleges kulcs, adatbázis által növelt (auto increment) érték legyen;
                ii. Name (string) – recept megnevezése. Legfeljebb 50 hosszú, kötelező mező;
                iii. Price (int) – a recept költsége;
                iv. IsSeductive (bool) – „csajozós”-ságát jelöli egy receptnek, ha igaz az értéke.
    */
    [Table("Receipts")]
    public class Receipts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Price { get; set; }

        public bool IsSeductive { get; set; }

        /*
        c) Állítsa be a szükséges paramétereket az adatbázis kapcsolathoz, és a táblák 
           között is definiálja a külsőkulcs függőségeket. 
           Adjon lehetőséget a LazyLoad módszer alkalmazására. (4 pont) 
        */
        [NotMapped]
        public virtual ICollection<Ingredients> Ingredients { get; set; }

        public Receipts()
        {
            Ingredients = new HashSet<Ingredients>();
        }
    }
}
