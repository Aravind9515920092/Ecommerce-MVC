using System.Web.Mvc;
using ECommerce.Services;
using ECommerce.DTOs.Product;
using ECommerce.DTOs.Order;
using ECommerce.DTOs.User;
using ECommerce.Services.Interfaces;
using Microsoft.CSharp;
using System.Linq;
using ECommerce.Services.Implementations;

namespace ECommerce.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IDashboardService _dashboardService;
        private readonly ICategoryService _categoryService;

        public DashboardController(
            IOrderService orderService,
            IProductService productService, 
            IUserService userService,
            ICategoryService categoryService)
        {
            _orderService = orderService;
            _productService = productService;
            _userService = userService;
            _categoryService = categoryService;
        }

        public ActionResult AdminDashboard()
        {
            if (Session["UserRole"]?.ToString() != "Admin")
                return RedirectToAction("Login", "Account");

            var products = _productService.GetAll();
            ViewBag.TotalProducts = products.Count();
            ViewBag.TotalStockQuantity = products.Sum(p => p.Stock);

            ViewBag.TotalUsers = _userService.GetAllUsers().Count();
            ViewBag.TotalOrders = _orderService.GetAllOrders().Count();

            return View();
        }


        //public ActionResult UserDashboard()
        //{
        //    if (Session["UserId"] == null || Session["UserRole"]?.ToString() != "User")
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }

        //    ViewBag.Username = Session["Username"]?.ToString();
        //    ViewBag.Categories = _categoryService.GetAll();

        //    var products = _productService.GetAll();


        //    return View(products);
        //}

        public ActionResult UserDashboard(int? categoryId)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            var allCategories = _categoryService.GetAll(); // Assuming you have a service for this
            ViewBag.Categories = allCategories;

            var allProducts = _productService.GetAll(); // Load all products

            if (categoryId != null && categoryId > 0)
            {
                allProducts = allProducts.Where(p => p.CategoryId == categoryId).ToList();
            }

            return View(allProducts);
        }


        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public ActionResult Index()
        {
            var stats = _dashboardService.GetDashboardStats();
            return View(stats);
        }
    }
}
