using vcart.Core.Entities;
using vcart.Models;
using vcart.Services.Interfaces;
using vcart.UI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace vcart.UI.Controllers
{
    public class CartController : BaseController
    {
        ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        Guid CartId
        {
            get
            {
                Guid Id;
                string CId = Request.Cookies["CId"];
                if (string.IsNullOrEmpty(CId))
                {
                    Id = Guid.NewGuid();
                    //newly added
                    Response.Cookies.Append("CId", Id.ToString(), new CookieOptions { Expires = DateTime.Now.AddDays(1) });
                }
                else
                {
                    Id = Guid.Parse(CId);
                }
                return Id;
            }
        }

        public IActionResult Index()
        {
            CartModel cart = _cartService.GetCartDetails(CartId);    
            return View(cart);
        }

        [Route("Cart/AddToCart/{ItemId}/{UnitPrice}/{Quantity}")]
        public IActionResult AddToCart(int ItemId, decimal UnitPrice, int Quantity)
        {
            try
            {
                int UserId = 0;
                Cart cart = _cartService.AddItem(UserId, CartId, ItemId, UnitPrice, Quantity);

                var data = JsonSerializer.Serialize(cart,new JsonSerializerOptions { ReferenceHandler= ReferenceHandler.IgnoreCycles});
                return Json(data);
            }
            catch (Exception ex)
            {

            }
            return Json("");
        }

        [Route("Cart/UpdateQuantity/{Id}/{Quantity}")]
        public IActionResult UpdateQuantity(int Id, int Quantity)
        {
            int count = _cartService.UpdateQuantity(CartId, Id, Quantity);
            return Json(count);
        }

        public IActionResult DeleteItem(int Id)
        {
            int count = _cartService.DeleteItem(CartId, Id);
            return Json(count);
        }
        public IActionResult GetCartCount()
        {
            int count = _cartService.GetCartCount(CartId);
            return Json(count);
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(AddressModel model)
        {
            if(ModelState.IsValid && CurrentUser!=null)
            {
                CartModel cart = _cartService.GetCartDetails(CartId);
                _cartService.UpdateCart(cart.Id, CurrentUser.Id);

                TempData.Set("Cart", cart);
                TempData.Set("Address", model);
                return RedirectToAction("Index","Payment");
            }
            return View();
        }
    }
}
