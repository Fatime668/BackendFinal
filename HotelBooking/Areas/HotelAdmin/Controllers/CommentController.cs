using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
