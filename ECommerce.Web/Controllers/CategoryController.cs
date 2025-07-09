using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.DTOs.Category;
using ECommerce.Services.Implementations;
using ECommerce.Services.Interfaces;

namespace ECommerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _service = categoryService;
            _productService = productService;
        }
        public ActionResult Index()
        {
            var categories =_service.GetAll();
        return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                _service.Create(dto);
                return RedirectToAction("Index");
            }

            return View(dto);
        }

        public ActionResult Edit(int id)
        {
            var category = _service.GetById(id);
            if (category == null)
                return HttpNotFound();

            var dto = new CategoryDTO { Name = category.Name };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                _service.Update(id, dto);
                return RedirectToAction("Index");
            }

            return View(dto);
        }

        public ActionResult Delete(int id)
        {
            var category = _service.GetById(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Products(int id)
        {
            var category = _service.GetById(id);
            if (category == null)
            {
                return HttpNotFound();  // 🛑 handles invalid ID
            }

            var products = _productService.GetByCategoryId(id);
            ViewBag.CategoryName = category.Name;
            return View(products);
        }

    }

}