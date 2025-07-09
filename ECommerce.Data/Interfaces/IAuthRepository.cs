using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models.Entities;


namespace ECommerce.Data.Interfaces
{
	public interface IAuthRepository
	{
        User GetByUsername(string username);
        void Register(User user);
        bool ValidateUser(string username, string password);
    }
}