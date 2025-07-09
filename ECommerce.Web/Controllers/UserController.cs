using System.Web.Mvc;
using ECommerce.DTOs.User;
using ECommerce.Services.Interfaces;

namespace ECommerce.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        public ActionResult Edit(int id)
        {
            var user = _userService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserDTO dto)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public ActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
