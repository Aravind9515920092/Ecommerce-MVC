using ECommerce.DTOs.Dashboard;
using ECommerce.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Models;
using ECommerce.DTOs.Cart;

namespace ECommerce.Services.Interfaces
{
	public interface IOrderService
	{
        void CreateOrder(OrderCreateDTO dto, List<CartItemDTO> cart);
        List<OrderDTO> GetAllOrders();
        List<OrderDetailDTO> GetOrderDetails(int orderId);
        List<SalesChartDTO> GetSalesChartData();
        IEnumerable<OrderDTO> GetOrdersByUserId(int userId);


    }
}