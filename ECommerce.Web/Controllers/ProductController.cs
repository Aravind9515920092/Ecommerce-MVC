using ECommerce.DTOs.Product;
using ECommerce.Services.Implementations;
using ECommerce.Services.Interfaces;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }


        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _service.GetAll();
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(_categoryService.GetAll(), "Id", "Name");

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                _service.Create(dto);
                return RedirectToAction("Index");
            }
           // ViewBag.CategoryList = new SelectList(_categoryService.GetAll(), "Id", "Name");

            return View(dto);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
                return HttpNotFound();

            var dto = new ProductCreateDTO
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
                CategoryId = product.CategoryId
            };
            ViewBag.CategoryList = new SelectList(_categoryService.GetAll(), "Id", "Name");

            return View(dto);
        }

        // POST: Product/Edit/5
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                _service.Update(id, dto);
                return RedirectToAction("Index");
            }

            return View(dto);
        }
        // GET: Product/UpdateStock/5
        public ActionResult UpdateStock(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var dto = new ProductStockUpdateDTO
            {
                Id = product.ProductId,
                Quantity = product.Quantity
            };
            return View(dto);
        }

        // POST: Product/UpdateStock
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStock(ProductStockUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateProductStock(dto.Id, dto.Quantity);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
