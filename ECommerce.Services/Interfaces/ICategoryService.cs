using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.DTOs.Category;
using ECommerce.Models.Entities;


namespace ECommerce.Services.Interfaces
{
    public interface ICategoryService
    {
       
        List<CategoryDTO> GetAll();
        CategoryDTO GetById(int id);
        void Create(CategoryDTO dto);
        void Update(int id, CategoryDTO dto);
        void Delete(int id);
    }
}

