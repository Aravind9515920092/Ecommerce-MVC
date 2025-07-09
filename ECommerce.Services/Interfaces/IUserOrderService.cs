using ECommerce.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Services.Interfaces
{
	public interface IUserOrderService
	{
        List<UserOrderDTO> GetOrdersByUserId(int userId);

    }
}