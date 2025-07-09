using ECommerce.Services.Implementations;
using ECommerce.Services.Interfaces;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    
    public class AdminDashboardController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminDashboardController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public ActionResult Index()
        {
            var stats = _adminService.GetDashboardStats();
            return View(stats);
        }

        public ActionResult Users()
        {
            var users = _adminService.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        public ActionResult DeactivateUser(int id)
        {
            _adminService.DeactivateUser(id);
            return RedirectToAction("Users");
        }

        [HttpPost]
        public ActionResult ActivateUser(int id)
        {
            _adminService.ActivateUser(id);
            return RedirectToAction("Users");
        }
    }
}
