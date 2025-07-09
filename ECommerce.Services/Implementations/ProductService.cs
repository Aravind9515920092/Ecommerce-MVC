using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ECommerce.DTOs.Product;
using ECommerce.Models.Entities;
using ECommerce.Data.Interfaces;
using ECommerce.Services.Interfaces;
using ECommerce.Data.Repositories;
using ECommerce.Data.Context;

namespace ECommerce.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
       
        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // ✅ Get all products with category name
        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _repo.GetAllProducts(); // includes Category
            return _mapper.Map<List<ProductDTO>>(products);
        }

        // ✅ Get product by ID
        public ProductDTO GetById(int id)
        {
            var product = _repo.GetById(id);
            return product != null ? _mapper.Map<ProductDTO>(product) : null;
        }

        // ✅ Create a new product
        public void Create(ProductCreateDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            _repo.Add(product);
            _repo.Save();
        }

        // ✅ Update an existing product
        public void Update(int id, ProductCreateDTO dto)
        {
            var product = _repo.GetById(id);
            if (product == null) return;

            // Update properties using AutoMapper
            _mapper.Map(dto, product);

            _repo.Update(product);
            _repo.Save();
        }
        public void UpdateProductStock(int id, int quantity)
        {
            _repo.UpdateProductStock(id, quantity);
        }

        // ✅ Delete a product
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }

        public void UpdateStock(int productId, int newQty)
        {
            _repo.UpdateStock(productId, newQty);
        }
        public IEnumerable<ProductDTO> GetByCategoryId(int categoryId)
        {
            var products = _repo.GetByCategoryId(categoryId); // Use repo, not context
            return _mapper.Map<List<ProductDTO>>(products);
        }

    }
}
