using ECommerce.Data.Context;
using ECommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }
        public ActionResult CheckSeed()
        {
            using (var context = new ApplicationDbContext())
            {
                var users = context.Users.ToList();
                return Content("Users in DB: " + users.Count);
            }
        }
        public ActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            return View(product);
        }

    }
}