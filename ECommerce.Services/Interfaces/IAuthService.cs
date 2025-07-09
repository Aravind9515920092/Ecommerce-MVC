
using ECommerce.Models.Entities;
using System;
using ECommerce.DTOs.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Services.Interfaces
{
	public interface  IAuthService
	{
		void Register(RegisterDTO dto);

		User Login(LoginDTO dto);

        UserProfileDTO GetUserProfile(int userId);
        User GetUserById(int userId);
        void UpdateProfile(int userId, UserProfileDTO dto);

    }
}