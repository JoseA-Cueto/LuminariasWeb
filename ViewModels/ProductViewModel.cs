using System.ComponentModel.DataAnnotations;
using static LuminariasWeb.sln.Enums.ProductCategoryEnum;

namespace LuminariasWeb.sln.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        [EnumDataType(typeof(ProductCategory))]
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
