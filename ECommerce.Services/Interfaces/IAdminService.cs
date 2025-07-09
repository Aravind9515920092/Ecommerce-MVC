using ECommerce.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Services.Implementations
{
	public interface IAdminService
	{
        AdminProfileDTO GetProfile(string username);
         DashboardStatsDTO GetDashboardStats();
        IEnumerable<UserAdminDTO> GetAllUsers();
        void DeactivateUser(int userId);
        void ActivateUser(int userId);
    }
}