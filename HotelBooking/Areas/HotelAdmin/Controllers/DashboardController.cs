using DataAccess.Data;
using Entities.Concrete;
using HotelBooking.Areas.HotelAdmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ChartVM model = new ChartVM
            {
                AppUsers = await _context.AppUser.ToListAsync(),
                Bookings = await _context.Bookings.ToListAsync(),
                Rooms = await _context.Rooms.ToListAsync()
            };
            return View(model);
        }


    }
}
