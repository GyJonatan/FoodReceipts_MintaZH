using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
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

        [NotMapped]
        public virtual ICollection<Ingredients> Ingredients { get; set; }

        public Receipts()
        {
            Ingredients = new HashSet<Ingredients>();
        }
    }
}
