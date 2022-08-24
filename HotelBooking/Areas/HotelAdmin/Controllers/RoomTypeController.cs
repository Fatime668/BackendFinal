using DataAccess.Data;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class RoomTypeController : Controller
    {
        private readonly AppDbContext _context;

        public RoomTypeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<RoomType> roomTypes = await _context.RoomTypes.ToListAsync();
            return View(roomTypes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(RoomType roomType)
        {
            if (!ModelState.IsValid) return View();

            await _context.RoomTypes.AddAsync(roomType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            RoomType roomType = await _context.RoomTypes.FirstOrDefaultAsync(s => s.Id == id);
            return View(roomType);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, RoomType roomType)
        {
            if (!ModelState.IsValid) return View();
            RoomType existedType = await _context.RoomTypes.FirstOrDefaultAsync(s => s.Id == id);
            existedType.Name = roomType.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            RoomType roomType = await _context.RoomTypes.FirstOrDefaultAsync(s => s.Id == id);
            return View(roomType);
        }
        public async Task<IActionResult> Delete(int id)
        {
            RoomType roomType = await _context.RoomTypes.FirstOrDefaultAsync(s => s.Id == id);
            return View(roomType);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteType(int id)
        {
            RoomType roomType = await _context.RoomTypes.FirstOrDefaultAsync(s => s.Id == id);
            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
