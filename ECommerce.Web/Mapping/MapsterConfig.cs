using ECommerce.DTOs.Product;
using ECommerce.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace ECommerce.Web.Mapping
{
	public static class MapsterConfig
	{
        public static void RegisterMappings()
        {
         //   TypeAdapterConfig<Product, ProductDTO>.NewConfig()
             //   .Map(dest => dest.CategoryName, src => src.Category.Name);
        }
    }
}