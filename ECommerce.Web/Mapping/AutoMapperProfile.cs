using AutoMapper;
using ECommerce.Models.Entities;
using ECommerce.DTOs.Auth;
using ECommerce.DTOs.Product;
using ECommerce.DTOs.Category;
using ECommerce.DTOs.User;
using ECommerce.DTOs.Order;
using ECommerce.DTOs.Dashboard;
using System.Linq;
using ECommerce.DTOs.Cart;
using ECommerce.Web.Models;

namespace ECommerce.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            // User mappings
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<User, LoginDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

            // Product mappings
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();

            // Category mappings
            CreateMap<Category, CategoryDTO>().ReverseMap();

            // Order mappings
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src =>
                    src.OrderItems != null ? src.OrderItems.Sum(i => i.Quantity * i.Price) : 0));

            CreateMap<OrderItem, OrderDetailDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            // Dashboard
            CreateMap<Dashboard, DashboardStatsDTO>().ReverseMap();
            CreateMap<CartItem, CartItemDTO>().ReverseMap(); // Add this to AutoMapperProfile

        }
    }
}
