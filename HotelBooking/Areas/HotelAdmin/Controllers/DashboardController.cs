using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("HotelAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
