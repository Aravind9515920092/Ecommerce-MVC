using System;
using System.Web.Mvc;
using ECommerce.DTOs.Auth;
using ECommerce.Services.Interfaces;

namespace ECommerce.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Validation failed. Please check your inputs.";
                return View(dto);
            }

            _authService.Register(dto);

            TempData["Success"] = "Registration successful. Please login.";
            return RedirectToAction("Login");
        }

        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var user = _authService.Login(dto);
            if (user == null)
            {
                ViewBag.Error = "Invalid credentials";
                return View(dto);
            }

            // ✅ Set session immediately
            Session["UserId"] = user.UserId;
            Session["Username"] = user.Username;
            Session["UserRole"] = user.Role;

            // Issue the Forms Auth cookie
            System.Web.Security.FormsAuthentication.SetAuthCookie(user.Username, false);


            // ✅ Redirect to ReturnUrl if exists
            string returnUrl = Request.QueryString["ReturnUrl"];
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return (user.Role == "Admin")
                ? RedirectToAction("AdminDashboard", "Dashboard")
                : RedirectToAction("UserDashboard", "Dashboard");
        }


        [HttpGet]
        public ActionResult MyProfile()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var user = _authService.GetUserById(userId);

            var dto = new UserProfileDTO
            {
                FullName = user.FullName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                CardNumber = user.CardNumber,
                PaymentMethod = user.PaymentMethod
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyProfile(UserProfileDTO dto)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            _authService.UpdateProfile(userId, dto);

            TempData["Success"] = "Profile updated successfully!";
            return RedirectToAction("MyProfile");
        }


        // GET: /Account/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
