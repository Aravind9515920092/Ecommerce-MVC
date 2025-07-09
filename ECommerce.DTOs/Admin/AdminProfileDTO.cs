using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs.Admin
{
	public class AdminProfileDTO
	{
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}