
using System.ComponentModel.DataAnnotations;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    // Propiedad adicional para la relación con Category
    public int CategoryId { get; set; }
}

