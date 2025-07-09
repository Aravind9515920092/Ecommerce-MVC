using ECommerce.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ECommerce.Data.Interfaces
{
	public interface IUserRepository
	{
        List<User> GetAllUsers();
        User GetUserById(int id);

        void UpdateUser(User user);
        void DeleteUser(int id);
        void Save();
    }
}