using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LuminariasWeb.sln.Enums.ProductCategoryEnum;

namespace LuminariasWeb.sln.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string? Description { get; set; }
        public int? Quantity { get; set; }  // para la cantidad en el carrito
        [EnumDataType(typeof(ProductCategory))]
        public ProductCategory Category { get; set; }
    }
}
