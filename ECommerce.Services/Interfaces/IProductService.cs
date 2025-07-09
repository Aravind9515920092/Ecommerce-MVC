using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.DTOs.Product;

namespace ECommerce.Services.Interfaces
{
	public interface IProductService
	{
        IEnumerable<ProductDTO> GetAll();
        ProductDTO GetById(int id);
        void Create(ProductCreateDTO dto);
        void Update(int id, ProductCreateDTO dto);
        void UpdateProductStock(int id, int quantity);

        void Delete(int id);
        void UpdateStock(int productId, int newQty);

        IEnumerable<ProductDTO> GetByCategoryId(int categoryId);


    }
}