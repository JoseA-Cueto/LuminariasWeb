using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;
    private readonly ILogger<CartController> _logger; // Utiliza el ILogger inyectado

    public CartController(ICartService cartService, ILogger<CartController> logger)
    {
        _cartService = cartService;
        _logger = logger;
    }

    [HttpGet("items")]
    public IActionResult GetCartItems()
    {
        try
        {
            var cartItems = _cartService.GetCartItems();
            return Ok(cartItems);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener los elementos del carrito");
            return StatusCode(500); // Devuelve un código de estado 500 en caso de error
        }
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
            _logger.LogError(ex, $"Error al agregar al carrito: {ex.Message}");
            return BadRequest(new { ErrorMessage = $"Error al agregar al carrito: {ex.Message}" });
        }
    }
}

