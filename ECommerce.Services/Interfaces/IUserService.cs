using AutoMapper;
using ECommerce.Data.Interfaces;
using ECommerce.DTOs.User;
using ECommerce.Models.Entities;
using ECommerce.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetAllUsers();
        UserDTO GetUserById(int id);

        void UpdateUser(UserDTO dto);
        void DeleteUser(int id);
    }

}