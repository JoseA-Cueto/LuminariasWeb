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

    [HttpPost("AddToCart")]
    public IActionResult AddToCart(CartItemViewModel item)
    {
        try
        {
            _cartService.AddItemToCartAsync(item);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener los elementos del carrito");
            return StatusCode(500); // Devuelve un código de estado 500 en caso de error
        }
    }

    [HttpGet("GetShoppingCart")]
    public IActionResult GetShoppingCart()
    {
        try
        {
            var shoppingCart = _cartService.GetShoppingCartAsync();
            return Ok(shoppingCart);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al agregar al carrito: {ex.Message}");
            return BadRequest(new { ErrorMessage = $"Error al agregar al carrito: {ex.Message}" });
        }
    }
    [HttpPost("ProcessPurchase")]
    public async Task<IActionResult> ProcessPurchase([FromBody] ShoppingCartViewModel cart)
    {
        try
        {
            await _cartService.ProcessPurchaseAsync(cart);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al procesar la compra");
            return StatusCode(500); // Devuelve un código de estado 500 en caso de error
        }
    }
    [HttpPost("CancelPurchase")]
    public async Task<IActionResult> CancelPurchase([FromBody] ShoppingCartViewModel cart)
    {
        try
        {
            await _cartService.CancelPurchaseAsync(cart);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al cancelar la compra");
            return StatusCode(500); // Devuelve un código de estado 500 en caso de error
        }
    }
}

