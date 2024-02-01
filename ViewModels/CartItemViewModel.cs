using LuminariasWeb.sln.Models;

public class CartViewModel
{
    public int CartItemId { get; set; }  // Identificador �nico para los elementos del carrito
    public Product Product { get; set; }  // Objeto Product asociado al �tem del carrito
    public int Quantity { get; set; }
    public decimal Price { get; set; }
   
}
