using LuminariasWeb.sln.Models;

public class CartViewModel
{
    public int CartItemId { get; set; }  // Identificador único para los elementos del carrito
    public Product Product { get; set; }  // Objeto Product asociado al ítem del carrito
    public int Quantity { get; set; }
    public decimal Price { get; set; }
   
}
