using ECommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class AdminOrderController : Controller
    {
        private readonly IOrderService _orderService;

        public AdminOrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public ActionResult Index()
        {
            if (Session["UserRole"]?.ToString() != "Admin")
                return RedirectToAction("Login", "Account");

            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var details = _orderService.GetOrderDetails(id);
            return View(details);
        }
    }

}