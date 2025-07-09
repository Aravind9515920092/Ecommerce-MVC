using ECommerce.Services.Interfaces;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
   
    public class UserDashboardController : Controller
    {
        private readonly IUserOrderService _orderService;

        public UserDashboardController(IUserOrderService orderService)
        {
            _orderService = orderService;
        }
     
        public ActionResult MyOrders()
        {
            // ensure user is logged in and has “User” role
            if (Session["UserId"] == null ||
                Session["UserRole"]?.ToString() != "User")
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = (int)Session["UserId"];
            var orders = _orderService.GetOrdersByUserId(userId);
            return View(orders);
        }

    }
}
