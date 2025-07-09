using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ECommerce.Data.Context;
using ECommerce.Data.Interfaces;
using ECommerce.Models.Entities;

namespace ECommerce.Data.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
        private readonly ApplicationDbContext _context;

            public CategoryRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public List<Category> GetAll() => _context.Categories.ToList();

            public Category GetById(int id) => _context.Categories.FirstOrDefault(x => x.CategoryId == id);

            public void Create(Category category) => _context.Categories.Add(category);

            public void Update(Category category) => _context.Entry(category).State = EntityState.Modified;


        public void Delete(Category category) => _context.Categories.Remove(category);

            public void Save() => _context.SaveChanges();
        
    }
}