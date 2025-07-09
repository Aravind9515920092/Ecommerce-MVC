using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ECommerce.Models.Entities;

namespace ECommerce.Data.Context
{
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            System.Diagnostics.Debug.WriteLine("=== SEEDING STARTED ===");

            // Categories
            var categories = new List<Category>
            {
                new Category { Name = "Men" },
                new Category { Name = "Women" },
                new Category { Name = "Electronics" },
                new Category { Name = "Home & Kitchen" },
                new Category { Name = "Books" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            var menId = context.Categories.Single(c => c.Name == "Men").CategoryId;
            var womenId = context.Categories.Single(c => c.Name == "Women").CategoryId;
            var electronicsId = context.Categories.Single(c => c.Name == "Electronics").CategoryId;
            var kitchenId = context.Categories.Single(c => c.Name == "Home & Kitchen").CategoryId;
            var booksId = context.Categories.Single(c => c.Name == "Books").CategoryId;

            // Products (5 per category)
            var products = new List<Product>();

            for (int i = 1; i <= 5; i++)
            {
                products.Add(new Product
                {
                    Name = $"Men's Casual Shirt {i}",
                    Price = 799 + i * 50,
                    Stock = 40 + i * 5,
                    Description = $"Comfortable cotton shirt model {i}.",
                    ImageUrl = $"/images/products/shirt{i}.jpg",
                    CategoryId = menId,
                    Quantity = 0
                });

                products.Add(new Product
                {
                    Name = $"Women's Maxi Dress {i}",
                    Price = 1599 + i * 60,
                    Stock = 30 + i * 3,
                    Description = $"Elegant floral print dress {i}.",
                    ImageUrl = $"/images/products/dress{i}.jpg",
                    CategoryId = womenId,
                    Quantity = 0
                });

                products.Add(new Product
                {
                    Name = $"Wireless Gadget {i}",
                    Price = 2499 + i * 100,
                    Stock = 50 + i * 10,
                    Description = $"Latest wireless electronic device {i}.",
                    ImageUrl = $"/images/products/earbuds{i}.jpg",
                    CategoryId = electronicsId,
                    Quantity = 0
                });

                products.Add(new Product
                {
                    Name = $"Kitchen Utility Item {i}",
                    Price = 899 + i * 75,
                    Stock = 60 + i * 10,
                    Description = $"Durable kitchen item {i}.",
                    ImageUrl = $"/images/products/kitchen{i}.jpg",
                    CategoryId = kitchenId,
                    Quantity = 0
                });

                products.Add(new Product
                {
                    Name = $"Bestselling Book {i}",
                    Price = 499 + i * 40,
                    Stock = 100 + i * 15,
                    Description = $"Popular book edition {i}.",
                    ImageUrl = $"/images/products/book{i}.jpg",
                    CategoryId = booksId,
                    Quantity = 0
                });
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            // Users
            var users = new List<User>
            {
                new User
                {
                    Username = "admin",
                    Email = "admin@example.com",
                    PasswordHash = "admin@123",
                    Role = "Admin",
                    FullName = "Admin User",
                    Address = "Admin Address",
                    PhoneNumber = "9999999999",
                    City = "Admin City",
                    State = "Admin State",
                    PostalCode = "000000",
                    CardNumber = "1111222233334444",
                    PaymentMethod = "Visa",
                    IsActive = true
                },
                new User
                {
                    Username = "aravind",
                    Email = "aravind@example.com",
                    PasswordHash = "user@123",
                    Role = "User",
                    FullName = "Aravind Kumar",
                    Address = "12 First Street",
                    PhoneNumber = "9000000001",
                    City = "Hyderabad",
                    State = "Telangana",
                    PostalCode = "500001",
                    CardNumber = "4111111111111111",
                    PaymentMethod = "Visa",
                    IsActive = true
                },
                new User
                {
                    Username = "ravi",
                    Email = "ravi@example.com",
                    PasswordHash = "user@123",
                    Role = "User",
                    FullName = "Ravi Shankar",
                    Address = "45 Second Road",
                    PhoneNumber = "9000000002",
                    City = "Chennai",
                    State = "Tamil Nadu",
                    PostalCode = "600001",
                    CardNumber = "4222222222222222",
                    PaymentMethod = "MasterCard",
                    IsActive = true
                },
                new User
                {
                    Username = "user3",
                    Email = "user3@example.com",
                    PasswordHash = "user@123",
                    Role = "User",
                    FullName = "User Three",
                    Address = "Address 3",
                    PhoneNumber = "9000000003",
                    City = "Mumbai",
                    State = "MH",
                    PostalCode = "400001",
                    CardNumber = "4333333333333333",
                    PaymentMethod = "UPI",
                    IsActive = true
                },
                new User
                {
                    Username = "user4",
                    Email = "user4@example.com",
                    PasswordHash = "user@123",
                    Role = "User",
                    FullName = "User Four",
                    Address = "Address 4",
                    PhoneNumber = "9000000004",
                    City = "Delhi",
                    State = "DL",
                    PostalCode = "110001",
                    CardNumber = "4444444444444444",
                    PaymentMethod = "Visa",
                    IsActive = true
                },
                new User
                {
                    Username = "user5",
                    Email = "user5@example.com",
                    PasswordHash = "user@123",
                    Role = "User",
                    FullName = "User Five",
                    Address = "Address 5",
                    PhoneNumber = "9000000005",
                    City = "Bangalore",
                    State = "KA",
                    PostalCode = "560001",
                    CardNumber = "4555555555555555",
                    PaymentMethod = "MasterCard",
                    IsActive = true
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            // Orders
            var orders = new List<Order>
            {
                new Order
                {
                    OrderDate = DateTime.Now.AddDays(-5),
                    Status = "Delivered",
                    UserId = 2,
                    CustomerName = "Aravind Kumar",
                    Address = "12 First Street",
                    Contact = "9000000001"
                },
                new Order
                {
                    OrderDate = DateTime.Now.AddDays(-3),
                    Status = "Shipped",
                    UserId = 3,
                    CustomerName = "Ravi Shankar",
                    Address = "45 Second Road",
                    Contact = "9000000002"
                }
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();

            // OrderItems
            var orderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    OrderId = 1,
                    ProductId = context.Products.First(p => p.Name.Contains("Shirt 1")).ProductId,
                    Quantity = 2,
                    Price = 849
                },
                new OrderItem
                {
                    OrderId = 2,
                    ProductId = context.Products.First(p => p.Name.Contains("Gadget 1")).ProductId,
                    Quantity = 1,
                    Price = 2599
                }
            };
            context.OrderItems.AddRange(orderItems);
            context.SaveChanges();

            System.Diagnostics.Debug.WriteLine("=== SEEDING COMPLETED ===");
        }
    }
}
