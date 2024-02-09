using Microsoft.AspNetCore.Mvc;
using vcart.Core.Entities;
using vcart.Models;
using vcart.Services.Interfaces;

namespace vcart.UI.Areas.User.Controllers
{
    public class OrderController : BaseController
    {
        IOrderService _orderService;
        IItemService _itemService;
        public OrderController(IOrderService orderService, IItemService itemService)
        {
            _orderService = orderService;
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            var orders = _orderService.GetAll().Where(o => o.UserId == CurrentUser.Id).Select(o =>
                new OrderModel()
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    Street = o.Street,
                    Locality = o.Locality,
                    City = o.City,
                    PhoneNumber = o.PhoneNumber,
                    ZipCode = o.ZipCode,
                    CreatedDate = o.CreatedDate
                });

            //OrderItems = o.OrderItems.
            //        Select(oi => new OrderItemModel()
            //        {
            //            Id = oi.Id,
            //            ItemId = oi.ItemId,
            //            Quantity = oi.Quantity,
            //            UnitPrice = oi.UnitPrice,
            //            Total = oi.Total
            //        }).ToList()

            return View(orders);
        }

        public IActionResult Details(string id)
        {
            var order = _orderService.GetOrderDetailWithItem(id);

            var orderItems = order.OrderItems.Select(oi =>
            {
                var item = _itemService.FindBy(oi.ItemId);

                var orderModelItem = new OrderItemModel()
                {
                    Id = oi.Id,
                    ItemId = oi.ItemId,
                    ItemName = item.Name,
                    ItemDescription = item.Description,
                    ItemImageUrl = item.ImageUrl,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    Total = oi.Total
                };
                return orderModelItem;
            });

            return View(orderItems);
        }
    }
}
