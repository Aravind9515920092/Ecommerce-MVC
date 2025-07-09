using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Data.Context;
using ECommerce.Data.Interfaces;
using ECommerce.DTOs.Admin;
using System.Web;

namespace ECommerce.Data.Repositories
{
	public class AdminRepository : IAdminRepository
	{

        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public AdminProfileDTO GetAdminProfile(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Role == "Admin");

            if (user == null) return null;

            return new AdminProfileDTO
            {
                Name = user.FullName,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role
            };
        }
    }
}