using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DTOs.Dashboard
{
	public class SalesChartDTO
	{
        public string ProductName { get; set; }
        public int QuantitySold { get; set; }
    }
}