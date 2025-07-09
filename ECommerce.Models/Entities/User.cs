using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;



namespace ECommerce.Models.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } // "Admin" or "User"

        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string State { get; set; }

        [MaxLength(6)]
        public string PostalCode { get; set; }

        // Payment Info (last 4 digits)
        [MaxLength(16)]
        public string CardNumber { get; set; }

      //  [MaxLength(5)]
      //  public string CardExpiry { get; set; } // MM/YY

        [MaxLength(50)]
        public string PaymentMethod { get; set; } // Visa, MasterCard, UPI, etc.

        // Optional fields
      //  public string ProfileImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

       
        public ICollection<Order> Orders { get; set; }
    }
}
