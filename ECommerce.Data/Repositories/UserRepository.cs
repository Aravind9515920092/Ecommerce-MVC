using ECommerce.Data.Context;
using ECommerce.Data.Interfaces;
using ECommerce.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerce.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == id);
            if (user != null)
            {
                user.IsActive = false; // Soft delete
                _context.SaveChanges();
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }

}