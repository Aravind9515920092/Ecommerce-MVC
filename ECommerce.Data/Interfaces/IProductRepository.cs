using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ECommerce.Models.Entities;


namespace ECommerce.Data.Interfaces
{
	public interface IProductRepository
	{
        IEnumerable<Product> GetAllProducts();
        Product GetById(int Prroductid);
        void Add(Product product);
        void UpdateStock(int productid, int newQty);
        void Update(Product product);
        void UpdateProductStock(int id, int quantity);
        IEnumerable<Product> GetByCategoryId(int categoryId);

        void Delete(int id);
        void Save();
    }
}