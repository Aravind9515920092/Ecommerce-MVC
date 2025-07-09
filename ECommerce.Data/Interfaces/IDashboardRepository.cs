using ECommerce.DTOs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Data.Interfaces
{
	public interface IDashboardRepository
	{
        int GetTotalOrders();
        int GetTotalProducts();
        decimal GetTotalRevenue();
        DashboardStatsDTO GetDashboardStats();

    }
}