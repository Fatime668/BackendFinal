using DataAccess.Data;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Booking> bookings = await _context.Bookings.ToListAsync();
            return View(bookings);
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null) return BadRequest();

            Booking booking = await _context.Bookings.FirstOrDefaultAsync(o => o.Id == id);

            if (booking is null) return NotFound();

            return View(booking);
        }
    }
}
