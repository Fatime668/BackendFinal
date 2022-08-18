using DataAccess.Data;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace HotelBooking.Controllers
{
    public class GalleryController : Controller
    {
        private readonly GalleryService _galleryService;
        public GalleryController(AppDbContext context)
        {
            _galleryService = new GalleryService(context);
        }
        public IActionResult Index(int? categoryId)
        {
            GalleryVM model = new GalleryVM
            {
                Galleries = _galleryService.GalleryFilter(categoryId),
                Categories = _galleryService.GetCategories(),
                CategoryId = categoryId,
            };
            return View(model);
        }
    }
}
