using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models.Entities
{
    public class Product
    {
        [Key]
     
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
     
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int Quantity { get; set; }
      

    }

}