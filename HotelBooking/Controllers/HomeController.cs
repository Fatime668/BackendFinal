using DataAccess.Data;
using Entities.Concrete;
using HotelBooking.Models;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly RoomService _roomService;
        private readonly TestimonialService _testimonialService;
        public HomeController(ILogger<HomeController> logger,AppDbContext context)
        {
            _logger = logger;
            _roomService = new RoomService(context);
            _testimonialService = new TestimonialService(context);
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Rooms = await _roomService.GetRooms(),
                Testimonials = await _testimonialService.GetTestimonials(),
                Galleries = await _context.Galleries.ToListAsync(),
                Comments = await _context.Comments.ToListAsync()

        };
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
