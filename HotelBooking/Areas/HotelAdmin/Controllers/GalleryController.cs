using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
