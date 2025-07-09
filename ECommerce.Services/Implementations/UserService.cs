using AutoMapper;
using ECommerce.Data.Interfaces;
using ECommerce.Data.Repositories;
using ECommerce.DTOs.User;
using ECommerce.Models.Entities;
using ECommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace ECommerce.Services.Implementations
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

       
       

        public List<UserDTO> GetAllUsers()
        {
            var users = _repo.GetAllUsers()
                        .Where(u => u.IsActive)
                        .Select(u => new UserDTO
                        {
                            Id = u.UserId,
                            Username = u.Username,
                            Email = u.Email,
                            Role = u.Role,
                            IsActive = u.IsActive
                        }).ToList();
            return users;
        }

        public UserDTO GetUserById(int id)
        {
            var u = _repo.GetUserById(id);
            return new UserDTO
            {
                Id = u.UserId,
                Username = u.Username,
                Email = u.Email,
                Role = u.Role,
                IsActive = u.IsActive
            };
        }

        public void UpdateUser(UserDTO dto)
        {
            var user = _repo.GetUserById(dto.Id);
            if (user != null)
            {
                user.Username = dto.Username;
                user.Email = dto.Email;
                user.Role = dto.Role;
                _repo.UpdateUser(user);
            }
        }

        public void DeleteUser(int id)
        {
            _repo.DeleteUser(id);
        }

    }

}



