using vcart.Core.Entities;
using vcart.Models;
using vcart.Services.Interfaces;
using vcart.UI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace vcart.UI.Controllers
{
    public class PaymentController : BaseController
    {
        IConfiguration _configuration;
        IPaymentService _paymentService;
        IOrderService _orderService;
        IOrderItemService _orderItemService;
        public PaymentController(IConfiguration configuration,
            IPaymentService paymentService, IOrderService orderService, IOrderItemService orderItemService)
        {
            _configuration = configuration;
            _paymentService = paymentService;
            _orderService = orderService;
            _orderItemService = orderItemService;
        }
        public IActionResult Index()
        {
            CartModel cart = TempData.Peek<CartModel>("Cart");
            PaymentModel payment = new PaymentModel();
            if (cart != null)
            {
                payment.Cart = cart;
                payment.GrandTotal = cart.GrandTotal;
                payment.Currency = "INR";
                payment.Description = string.Join(",", cart.Items.Select(x => x.Name));
                payment.RazorpayKey = _configuration["Razorpay:Key"];
                payment.Receipt = Guid.NewGuid().ToString(); //merchant transaction id
                payment.OrderId = _paymentService.CreateOrder(payment.GrandTotal * 100, payment.Currency, payment.Receipt);

            }

            return View(payment);
        }

        [HttpPost]
        public IActionResult Status(IFormCollection form)
        {
            try
            {
                if (form.Keys.Count > 0 && !string.IsNullOrWhiteSpace(form["rzp_paymentid"]))
                {
                    string paymentId = form["rzp_paymentid"];
                    string orderId = form["rzp_orderid"];
                    string signature = form["rzp_signature"];
                    string transactionId = form["Receipt"];
                    string currency = form["Currency"];

                    var payment = _paymentService.GetPaymentDetails(paymentId);
                    bool IsSignVerified = _paymentService.VerifySignature(signature, orderId, paymentId);

                    if (IsSignVerified && payment != null)
                    {
                        // TO DO

                        PaymentDetail model = new PaymentDetail();
                        CartModel cart = TempData.Get<CartModel>("Cart");

                        model.CartId = cart.Id;
                        model.Total = cart.Total;
                        model.Tax = cart.Tax;
                        model.GrandTotal = cart.GrandTotal;
                        model.CreatedDate = DateTime.Now;

                        model.Status = payment.Attributes["status"]; //captured
                        model.TransactionId = transactionId;
                        model.Currency = payment.Attributes["currency"];
                        model.Email = payment.Attributes["email"];
                        model.Id = paymentId;
                        model.UserId = CurrentUser.Id;

                        int status = _paymentService.SavePaymentDetails(model);
                        if (status > 0)
                        {
                            Response.Cookies.Append("CId", "");
                            AddressModel address = TempData.Get<AddressModel>("Address");

                            TempData.Set("PaymentDetails", model);

                            // save order to database

                            Order order = new Order()
                            {
                                Id = orderId,
                                UserId = CurrentUser.Id,
                                PaymentId = paymentId,
                                Street = address.Street,
                                ZipCode = address.ZipCode,
                                City = address.City,
                                Locality = address.Locality,
                                PhoneNumber = CurrentUser.PhoneNumber,
                                CreatedDate = DateTime.Now
                            };
                            _orderService.Add(order);

                            // save all corresponding order items to db

                            List<OrderItem> orderItems =
                                cart.Items.Select(i => new OrderItem()
                                {
                                    OrderId = orderId,
                                    ItemId = i.ItemId,
                                    Quantity = i.Quantity,
                                    UnitPrice = i.UnitPrice,
                                    Total = i.Total
                                }).ToList();

                            orderItems?.ForEach(oi =>
                            _orderItemService.Add(oi));

                            return RedirectToAction("Receipt");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            ViewBag.Message = "Your payment has failed. You can contact us at email.";
            return View();
        }

        public IActionResult Receipt()
        {
            PaymentDetail model = TempData.Peek<PaymentDetail>("PaymentDetails");
            return View(model);
        }
    }
}
