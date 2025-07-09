using AutoMapper;
using ECommerce.Web.Mapping;
using Unity;
using Unity.Mvc5;
using System.Web.Mvc;
using ECommerce.Services.Interfaces;
using ECommerce.Services.Implementations;
using ECommerce.Data.Interfaces;
using ECommerce.Data.Repositories;


namespace ECommerce.Web
{
    public static class DIContainer
    {
        public static void Register()
        {
            var container = new UnityContainer();

            // ✅ AutoMapper Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            // Register AutoMapper
            IMapper mapper = config.CreateMapper();
            container.RegisterInstance(mapper);

            // Repositories
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IAuthRepository, AuthRepository>();
            container.RegisterType<IDashboardRepository, DashboardRepository>();
            container.RegisterType<IUserOrderRepository, UserOrderRepository>();
            container.RegisterType<IAdminRepository, AdminRepository>();
            // Services
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<IDashboardService, DashboardService>();
            container.RegisterType<IUserOrderService, UserOrderService>();
            container.RegisterType<IAdminService, AdminService>();

            // Set MVC Dependency Resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
