using System;
using System.Collections.Generic;
using ECommerce.Data.Interfaces;
using ECommerce.Models.Entities;
using System.Linq;
using System.Web;
using ECommerce.Services.Interfaces;
using AutoMapper;
using ECommerce.DTOs.Category;

namespace ECommerce.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<CategoryDTO> GetAll() => _mapper.Map<List<CategoryDTO>>(_repo.GetAll());

        public CategoryDTO GetById(int id) => _mapper.Map<CategoryDTO>(_repo.GetById(id));

        public void Create(CategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            _repo.Create(category);
            _repo.Save();
        }

        public void Update(int id, CategoryDTO dto)
        {
            var existing = _repo.GetById(id);
            if (existing != null)
            {
                existing.Name = dto.Name;
                _repo.Update(existing);
                _repo.Save();
            }
        }

        public void Delete(int id)
        {
            var category = _repo.GetById(id);
            if (category != null)
            {
                _repo.Delete(category);
                _repo.Save();
            }
        }
    }
}