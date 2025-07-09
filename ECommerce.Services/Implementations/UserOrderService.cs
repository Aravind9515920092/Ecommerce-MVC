using ECommerce.Data.Interfaces;
using ECommerce.DTOs.Order;
using ECommerce.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Services.Implementations
{
    public class UserOrderService : IUserOrderService
    {
        private readonly IUserOrderRepository _repo;

        public UserOrderService(IUserOrderRepository repo)
        {
            _repo = repo;
        }

        public List<UserOrderDTO> GetOrdersByUserId(int userId)
        {
            var orders = _repo.GetOrdersByUserId(userId);

            return orders.Select(o => new UserOrderDTO
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                TotalAmount = o.OrderItems.Sum(i => i.Price * i.Quantity),
                Items = o.OrderItems.Select(i => new UserOrderItemDTO
                {
                    ProductName = i.Product.Name,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            }).ToList();
        }
    }
}
