using ECommerce.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Data.Interfaces
{
	public interface IAdminRepository
	{
        AdminProfileDTO GetAdminProfile(string username);
    }
}