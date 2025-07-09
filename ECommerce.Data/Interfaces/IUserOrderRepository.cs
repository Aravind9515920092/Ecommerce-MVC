using ECommerce.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Data.Interfaces
{
	public interface IUserOrderRepository
	{
        List<Order> GetOrdersByUserId(int userId);
    }
}