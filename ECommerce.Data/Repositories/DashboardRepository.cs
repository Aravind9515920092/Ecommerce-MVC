using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Data.Context;
using ECommerce.Data.Interfaces;
using ECommerce.DTOs.Dashboard;

namespace ECommerce.Data.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetTotalOrders()
        {
            return _context.Orders.Count();
        }

        public int GetTotalProducts()
        {
            return _context.Products.Count();
        }

        public decimal GetTotalRevenue()
        {
            return _context.Orders
                .SelectMany(o => o.OrderItems)
                .Sum(i => i.Quantity * i.Price);
        }
        public DashboardStatsDTO GetDashboardStats()
        {
            return new DashboardStatsDTO
            {
                TotalUsers = _context.Users.Count(),
                TotalOrders = _context.Orders.Count(),
                TotalRevenue = _context.Orders
                                .SelectMany(o => o.OrderItems)
                                .Sum(i => i.Quantity * i.Price)
            };
        }
    }
}
