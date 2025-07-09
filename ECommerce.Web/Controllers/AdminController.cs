using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ECommerce.Services.Interfaces;
using ECommerce.Services.Implementations;
using ECommerce.DTOs.Product;

namespace ECommerce.Web.Controllers
{
   
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public ActionResult AdminProfile()
        {
            string username = User.Identity.Name;  // Current logged-in user
            var profile = _adminService.GetProfile(username);

            if (profile == null)
            {
                return HttpNotFound("Admin profile not found.");
            }

            return View(profile);
        }
        [HttpGet]
        public ActionResult ManageStock()
        {
            var products = _productService.GetAll()
                .Select(p => new ProductStockDTO
                {
                    Id = p.ProductId,
                    Name = p.Name,
                    CurrentStock = p.Quantity
                }).ToList();

            return View(products);
        }

        [HttpPost]
        public ActionResult UpdateStock(int id, int newStock)
        {
            _productService.UpdateStock(id, newStock);
            TempData["Success"] = "Stock updated successfully!";
            return RedirectToAction("ManageStock");
        }
        public ActionResult SalesAnalytics()
        {
            var chartData = _orderService.GetSalesChartData();
            return View(chartData);
        }

    }
}

   
