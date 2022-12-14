using DataAccess.Data;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ApproachController : Controller
    {
        private readonly AppDbContext _context;

        public ApproachController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            List<Approach> approaches = await _context.Approaches.ToListAsync();
            return View(approaches.ToPagedList(page, 5));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Approach approach)
        {
            if (!ModelState.IsValid) return View();
            await _context.Approaches.AddAsync(approach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            Approach existedApproach = await _context.Approaches.FirstOrDefaultAsync(a => a.Id == id);
            if (existedApproach == null) return NotFound();

            return View(existedApproach);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Approach approach)
        {
            Approach existedApproach = await _context.Approaches.FirstOrDefaultAsync(a => a.Id == id);
            if (existedApproach == null) return NotFound();
            _context.Entry(existedApproach).CurrentValues.SetValues(approach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Approach existedApproach = await _context.Approaches.FirstOrDefaultAsync(a => a.Id == id);
            if (existedApproach == null) return NotFound();

            return View(existedApproach);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Approach existedApproach = await _context.Approaches.FirstOrDefaultAsync(a => a.Id == id);
            if (existedApproach == null) return NotFound();
            return View(existedApproach);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteApproach(int id)
        {
            Approach existedApproach = await _context.Approaches.FirstOrDefaultAsync(a => a.Id == id);
            if (existedApproach == null) return NotFound();
            _context.Remove(existedApproach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
