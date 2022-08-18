using DataAccess.Data;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            AboutVM model = new AboutVM
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Approaches = await _context.Approaches.ToListAsync(),
                Teams = await _context.Teams.ToListAsync()
            };
            return View(model);
        }
    }
}