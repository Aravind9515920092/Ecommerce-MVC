using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DTOs.Admin
{
	public class DashboardStatsDTO
	{


            public int TotalUsers { get; set; }
            public int TotalOrders { get; set; }
            public decimal TotalRevenue { get; set; }
            public int TotalProducts { get; set; }
    }
}


