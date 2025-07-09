using ECommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Data.Interfaces;
using ECommerce.DTOs.Dashboard;

using System.Web;
using ECommerce.Data.Repositories;

namespace ECommerce.Services.Implementations
{
	public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repo;

        public DashboardService(IDashboardRepository repo)
        {
            _repo = repo;
        }

        public DashboardStatsDTO GetStats()
        {
            return new DashboardStatsDTO
            {
                TotalOrders = _repo.GetTotalOrders(),
                TotalProducts = _repo.GetTotalProducts(),
                TotalRevenue = _repo.GetTotalRevenue()
            };
        }
        public DashboardStatsDTO GetDashboardStats()
        {
            return _repo.GetDashboardStats();
        }
    }
}
