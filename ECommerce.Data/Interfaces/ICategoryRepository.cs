using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models.Entities;


namespace ECommerce.Data.Interfaces
{

    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
        void Save();
    }

}
