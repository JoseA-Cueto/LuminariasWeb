using System.ComponentModel.DataAnnotations;
using static LuminariasWeb.sln.Enums.ProductCategoryEnum;

namespace LuminariasWeb.sln.ViewModels
{
    public class ProductViewModel
    {
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }
        public string Category { get; set; }
    }
}
