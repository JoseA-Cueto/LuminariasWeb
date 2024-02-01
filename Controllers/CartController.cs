using Microsoft.AspNetCore.Mvc;
using LuminariasWeb.sln.ViewModels;
using LuminariasWeb.sln.Interface;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("items")]
    public IActionResult GetCartItems()
    {
        var cartItems = _cartService.GetCartItems();
        return Ok(cartItems);
    }

    [HttpPost("add")]
    public IActionResult AddToCart([FromBody] CartViewModel cartItem)
    {
        try
        {
            _cartService.AddToCart(cartItem);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = $"Error al agregar al carrito: {ex.Message}" });
        }
    }

    
}
