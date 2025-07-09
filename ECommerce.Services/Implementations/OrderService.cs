using AutoMapper;
using ECommerce.Data.Interfaces;
using ECommerce.Data.Repositories;
using ECommerce.DTOs.Cart;
using ECommerce.DTOs.Dashboard;
using ECommerce.DTOs.Order;
using ECommerce.Models.Entities;
using ECommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using ECommerce.Web.Models;

namespace ECommerce.Services.Implementations
{
	public class OrderService : IOrderService
	{

        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<OrderDTO> GetAllOrders()
        {
            var orders = _repo.GetAllOrders();
            return orders.Select(o => new OrderDTO
            {
                OrderId = o.OrderId,
                CustomerName = o.CustomerName,
                OrderDate = o.OrderDate,
                TotalAmount = o.OrderItems.Sum(i => i.Quantity * i.Price)
            }).ToList();
        }

        public List<OrderDetailDTO> GetOrderDetails(int orderId)
        {
            var order = _repo.GetOrderById(orderId);
            return order.OrderItems.Select(i => new OrderDetailDTO
            {
                ProductName = i.Product.Name,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToList();

        }
        public List<SalesChartDTO> GetSalesChartData()
        {
            return _repo.GetSalesSummary();
        }
        public IEnumerable<OrderDTO> GetOrdersByUserId(int userId)
        {
            var orders = _repo.GetOrdersByUserId(userId);
            return orders.Select(o => new OrderDTO
            {
                OrderId = o.OrderId,
                CustomerName = o.CustomerName,
                OrderDate = o.OrderDate,
                TotalAmount = o.OrderItems.Sum(i => i.Quantity * i.Price),
                OrderItems = o.OrderItems.Select(i => new OrderDetailDTO
                {
                    ProductName = i.Product?.Name,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            }).ToList();

        }


        public void CreateOrder(OrderCreateDTO dto, List<CartItemDTO> cartItems)
        {
            var order = new Order
            {
                UserId = dto.UserId,
                CustomerName = dto.CustomerName,
                Address = dto.Address,
                Contact = dto.Contact,
                OrderDate = DateTime.Now,
                OrderItems = cartItems.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            _repo.Add(order);
            _repo.Save();
        }

    }


}
	