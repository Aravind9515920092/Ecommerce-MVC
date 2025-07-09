using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models.Entities;
using ECommerce.Data.Interfaces;
using ECommerce.Data.Context;
using ECommerce.DTOs.Dashboard;


namespace ECommerce.Data.Repositories
{
	public class OrderRepository : IOrderRepository
	{
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include("OrderItems.Product")  // ✅ EF6 navigation include syntax
                .ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Include("OrderItems.Product")  // ✅ EF6
                .FirstOrDefault(o => o.OrderId == id);
        }
        public List<SalesChartDTO> GetSalesSummary()
        {
            return _context.OrderItems
                .Include("Product") // <-- EF6 string-based Include
                .GroupBy(i => i.Product.Name)
                .Select(g => new SalesChartDTO
                {
                    ProductName = g.Key,
                    QuantitySold = g.Sum(x => x.Quantity)
                }).ToList();
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }
        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            return _context.Orders
                           .Include("OrderItems.Product")
                           .Where(o => o.UserId == userId)
                           .ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
