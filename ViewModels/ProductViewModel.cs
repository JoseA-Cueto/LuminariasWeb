using System.ComponentModel.DataAnnotations;
using static LuminariasWeb.sln.Enums.ProductCategoryEnum;

namespace LuminariasWeb.sln.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Descripcion { get; set; }

        [EnumDataType(typeof(ProductCategory))]
        public ProductCategory Category { get; set; }
    }
}
