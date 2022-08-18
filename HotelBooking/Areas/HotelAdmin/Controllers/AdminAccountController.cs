using Entities.Concrete;
using HotelBooking.Areas.HotelAdmin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    public class AdminAccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new AppUser
            {
                UserName = register.Username,
                Firstname = register.Firstname,
                Lastname = register.Lastname,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber
            };
            return View(register);
        }
    }
}
