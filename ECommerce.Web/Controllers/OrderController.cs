using System.Web.Mvc;
using ECommerce.Services.Interfaces;
using ECommerce.DTOs.Order;
using System.Collections.Generic;
using ECommerce.Web.Models;
using System.Linq;
using ECommerce.DTOs.Cart;
using System;

namespace ECommerce.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public ActionResult Index()
        {
            List<OrderDTO> orders = _orderService.GetAllOrders();
            return View(orders);
        }

        public ActionResult Details(int id)
        {
            List<OrderDetailDTO> details = _orderService.GetOrderDetails(id);
            return View(details);
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            var cart = Session["Cart"] as List<CartItemDTO>;
            if (cart == null || !cart.Any())
                return RedirectToAction("Index", "Cart");

            return View(new OrderCreateDTO());
        }

        [HttpPost]
        public ActionResult Checkout(OrderCreateDTO dto)
        {
            var cart = Session["Cart"] as List<CartItemDTO>;
            if (cart == null || !cart.Any())
                return RedirectToAction("Index", "Cart");

            if (!ModelState.IsValid)
                return View(dto);

            _orderService.CreateOrder(dto, cart);

            Session["Cart"] = null;

            TempData["OrderSuccess"] = "Order placed successfully!";
            return RedirectToAction("ThankYou");
        }

        //[Authorize(Roles = "User")]
        public ActionResult MyOrders()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            int userId = Convert.ToInt32(Session["UserId"]);
            var orders = _orderService.GetOrdersByUserId(userId);
            return View(orders);
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}
