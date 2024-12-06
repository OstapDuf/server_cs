using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models
{

    [Table("ShoppingList")]
    public class ShoppingList
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")] public string Name { get; set; }

        [Column("Quality")] public long Quality { get; set; }

        [Column("Price")] public decimal Price { get; set; }


    }
}