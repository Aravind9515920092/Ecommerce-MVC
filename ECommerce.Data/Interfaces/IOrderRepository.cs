using ECommerce.DTOs.Dashboard;
using ECommerce.DTOs.Order;
using ECommerce.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Data.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        List<SalesChartDTO> GetSalesSummary();
        void Add(Order order);
        IEnumerable<Order> GetOrdersByUserId(int userId);

        void Save();
    }
}