using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
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
