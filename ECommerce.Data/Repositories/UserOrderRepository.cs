using ECommerce.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ECommerce.Data.Context;
using ECommerce.Models.Entities;

namespace ECommerce.Data.Repositories
{
    public class UserOrderRepository : IUserOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public UserOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return _context.Orders
                .Include(o => o.OrderItems.Select(i => i.Product))
                .Where(o => o.UserId == userId)
                .ToList();
        }
    }
}
