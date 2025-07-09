using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models.Entities;
using ECommerce.Data.Context;
using ECommerce.Data.Interfaces;

namespace ECommerce.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int id) =>
            _context.Products.FirstOrDefault(p => p.ProductId == id);

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null) _context.Products.Remove(product);
        }

        public void UpdateProductStock(int id, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                product.Quantity = quantity;
                _context.SaveChanges();
            }

        }
        public void Save() => _context.SaveChanges();

        public void UpdateStock(int productid, int newQty)
        {
            var product = _context.Products.Find(productid);
            if (product != null)
            {
                product.Stock = newQty;
                _context.SaveChanges();
            }
        }


        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

    }
}