using System.Web.Mvc;
using ECommerce.Services.Interfaces;
using ECommerce.DTOs.Order;

namespace ECommerce.AdminPanel.Controllers
{
  //  [Authorize(Roles = "Admin")]
    public class AdminOrderController : Controller
    {
        private readonly IOrderService _orderService;

        public AdminOrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public ActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }
    }
}
