using ECommerce.Data.Context;
using ECommerce.Models.Entities;
using System;
using ECommerce.Data.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Data.Repositories
{
	public class AuthRepository : IAuthRepository
	{
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool ValidateUser(string username, string password)
        {
            return _context.Users.Any(u => u.Username == username && u.PasswordHash == password);
        }
    }
}
