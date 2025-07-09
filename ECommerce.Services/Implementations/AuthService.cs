using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ECommerce.Data.Context;
using ECommerce.DTOs.Auth;
using ECommerce.Models.Entities;
using ECommerce.Services.Interfaces;

namespace ECommerce.Services.Implementations
{
	public class AuthService : IAuthService
	{
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Register(RegisterDTO dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = dto.Password, // Replace with your hashing
                Role = "User", // Automatically set
                FullName = dto.FullName,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                City = dto.City,
                State = dto.State,
                PostalCode = dto.PostalCode,
                CardNumber = dto.CardNumber,
                PaymentMethod = dto.PaymentMethod,
                IsActive = true
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Login(LoginDTO dto)
        {
            var user = _context.Users
              .FirstOrDefault(u =>
                  u.Username == dto.Username &&
                  u.PasswordHash == dto.Password);

            // If nothing found, return null
            if (user == null)
                return null;

            // ✅ Return the User entity directly
            return user; 
            
        }
        public UserProfileDTO GetUserProfile(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return null;

            return new UserProfileDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                PaymentMethod = user.PaymentMethod, // e.g., "Visa"
                CardNumber = !string.IsNullOrEmpty(user.CardNumber) && user.CardNumber.Length >= 4
                ? user.CardNumber.Substring(user.CardNumber.Length - 4)
                 : ""


            };
        }
        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void UpdateProfile(int userId, UserProfileDTO dto)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                user.FullName = dto.FullName;
                user.Email = dto.Email;
                user.Address = dto.Address;
                user.PhoneNumber = dto.PhoneNumber;
                user.CardNumber = dto.CardNumber;
                user.PaymentMethod = dto.PaymentMethod;
                _context.SaveChanges();
            }
        }

    }

}