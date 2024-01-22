// using AutoMapper;
// using LuminariasWeb.sln.BusinessInterface;
// using LuminariasWeb.sln.Interface;
// using LuminariasWeb.sln.Models;
// using LuminariasWeb.sln.ViewModels;



// public class CartService : ICartService
// {
//     private List<CartItem> _cartItems;

//     public CartService()
//     {
//         _cartItems = new List<CartItem>();
//     }

//     public void AddToCart(int productId, string productName, decimal price, int quantity)
//     {
//         var existingItem = _cartItems.FirstOrDefault(item => item.ProductId == productId);

//         if (existingItem != null)
//         {
//             existingItem.Quantity += 1;
//         }
//         else
//         {
//             _cartItems.Add(new CartItem
//             {
//                 ProductId = productId,
//                 ProductName = productName,
//                 Price = price,
//                 Quantity = quantity
//             });
//         }
//     }

//     public void RemoveFromCart(int productId)
//     {
//         _cartItems.RemoveAll(item => item.ProductId == productId);
//     }

//     public List<CartItem> GetCartItems()
//     {
//         return _cartItems;
//     }

//     public void ClearCart()
//     {
//         _cartItems.Clear();
//     }
// }
