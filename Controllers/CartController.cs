// using Microsoft.AspNetCore.Mvc;
// using LuminariasWeb.sln.Interface;
// using LuminariasWeb.sln.ViewModels;
// using LuminariasWeb.sln.BusinessInterface;

// [ApiController]
// [Route("api/cart")]
// public class CartController : ControllerBase
// {
//     private readonly ICartService _cartService;

//     public CartController(ICartService cartService)
//     {
//         _cartService = cartService;
//     }

//     [HttpPost("add")]
//     public IActionResult AddToCart([FromBody] CartItemViewModel cartItem)
//     {
//         try
//         {
//             _cartService.AddToCart(cartItem.ProductId, cartItem.ProductName, cartItem.Price, cartItem.Quantity);
//             return Ok(); // 200 OK
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Error al agregar al carrito: {ex.Message}"); // 400 Bad Request
//         }
//     }

//     [HttpDelete("remove/{productId}")]
//     public IActionResult RemoveFromCart(int productId)
//     {
//         try
//         {
//             _cartService.RemoveFromCart(productId);
//             return Ok(); // 200 OK
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Error al eliminar del carrito: {ex.Message}"); // 400 Bad Request
//         }
//     }

//     [HttpGet("items")]
//     public IActionResult GetCartItems()
//     {
//         var cartItems = _cartService.GetCartItems();
//         return Ok(cartItems); // 200 OK
//     }

//     [HttpPost("clear")]
//     public IActionResult ClearCart()
//     {
//         _cartService.ClearCart();
//         return Ok(); // 200 OK
//     }
// }
