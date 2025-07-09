using ECommerce.Data.Interfaces;
using ECommerce.Data.Repositories;
using ECommerce.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Services.Implementations
{
	public class AdminService :IAdminService
	{
        private readonly IUserRepository _userRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        private readonly IAdminRepository _adminRepo;
        public AdminService(IAdminRepository adminrepo,IUserRepository userRepo, IOrderRepository orderRepo, IProductRepository productRepo)
        {
            _userRepo = userRepo;
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _adminRepo = adminrepo;
        }
        public AdminProfileDTO GetProfile(string username)
        {
            return _adminRepo.GetAdminProfile(username);
        }
        public DashboardStatsDTO GetDashboardStats()
        {
            return new DashboardStatsDTO
            {
                TotalUsers = _userRepo.GetAllUsers().Count(),
                TotalOrders = _orderRepo.GetAllOrders().Count(),
                TotalRevenue = _orderRepo.GetAllOrders().Sum(o => o.OrderItems.Sum(i => i.Quantity * i.Price)),
                TotalProducts = _productRepo.GetAllProducts().Count()
            };
        }

        public IEnumerable<UserAdminDTO> GetAllUsers()
        {
            return _userRepo.GetAllUsers().Select(u => new UserAdminDTO
            {
                Id = u.UserId,
                Username = u.Username,
                Email = u.Email,
                IsActive = u.IsActive
            });
        }

        public void DeactivateUser(int userId)
        {
            var user = _userRepo.GetUserById(userId);
            if (user != null)
            {
                user.IsActive = false;
                _userRepo.UpdateUser(user);
                _userRepo.Save();
            }
        }

        public void ActivateUser(int userId)
        {
            var user = _userRepo.GetUserById(userId);
            if (user != null)
            {
                user.IsActive = true;
                _userRepo.UpdateUser(user);
                _userRepo.Save();
            }
        }
    }


}
