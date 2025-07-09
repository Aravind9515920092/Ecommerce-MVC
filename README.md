
# 🛒 E-Commerce Website (ASP.NET MVC)

A fully functional, real-world **E-Commerce Web Application** built using **ASP.NET MVC 5**, **Entity Framework 6**, **SQL Server**, and **Bootstrap 5**. The project supports **Admin** and **User** roles, **cart**, **checkout**, **order tracking**, **profile management**, and more.

---

## 🔧 Technologies Used

- ASP.NET MVC 5
- Entity Framework 6.5.1 (Code First)
- SQL Server LocalDB
- C#
- Bootstrap 5
- HTML5, CSS3, Razor Views
- AutoMapper
- Unity (for Dependency Injection)

---

## 🚀 Features

### 👤 Authentication & Authorization
- User & Admin login/register with role-based access
- Session-based authentication
- Password hashing and validation

### 🛍️ E-Commerce Functionality
- View products by category
- Add to cart, remove from cart, update quantity
- Place orders
- Checkout with sample payment details
- View order history (My Orders)

### 📊 Admin Features
- Admin dashboard with:
  - Total Users
  - Total Products
  - Total Orders
- View all users and their details
- Track placed orders
- View stock levels and manage products (optional)
- Admin-only product quantity access

### 🧑 User Features
- User dashboard with:
  - Profile
  - All products
  - Add to Cart
- View and edit personal profile
- Filter products by category (in progress)
- Toast notifications (optional)
- Profile with address, phone, and payment info

---

## 📁 Project Structure

ECommerce.Web # ASP.NET MVC frontend (views, controllers)
ECommerce.Data # Entity Framework DbContext and entity classes
ECommerce.DTOs # DTOs for transferring data
ECommerce.Services # Business logic and service layer

---

## ⚙️ How to Run Locally

1. **Clone the repo**  
   ```bash
   git clone https://github.com/Aravind9515920092/Ecommerce-MVC
2.	Open in Visual Studio
Open ECommerce.Web.sln.
3.	Set Startup Project
Right-click ECommerce.Web → Set as Startup Project.
4.	Check Connection String
In Web.config, confirm:
5.	<connectionStrings>
6.	  <add name="DefaultConnection" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=ECommerceDB;Integrated Security=True" />
7.	</connectionStrings>
8.	Run App
Press F5 or Ctrl + F5.
________________________________________
🧪 Sample Credentials
Admin:
  Username: admin
  Password: admin@123

User:
  Username aravind
  Password: user@123
________________________________________
📌 To-Do (Next Phases)
•	Product filters (category + price)
•	Profile image upload
•	Payment gateway integration
•	Email confirmation on order
•	Product stock management (Admin)
________________________________________
👨‍💻 Author
Aravind Reddy
📧 aravindadavelly@gmail.com
🌐 GitHub: github.com/ Aravind9515920092/Ecommerce-MVC  
________________________________________
📃 License
This project is licensed under the MIT License.

