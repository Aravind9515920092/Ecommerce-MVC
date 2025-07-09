using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using ECommerce.DTOs.Dashboard;

namespace ECommerce.Services.Interfaces
{
	public interface IDashboardService
	{
        DashboardStatsDTO GetDashboardStats();

        DashboardStatsDTO GetStats();
    }
}