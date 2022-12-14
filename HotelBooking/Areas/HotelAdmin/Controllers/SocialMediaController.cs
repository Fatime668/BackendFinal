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
    public class SocialMediaController : Controller
    {
        private readonly AppDbContext _context;

        public SocialMediaController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            List<SocialMedia> socialMedia = await _context.SocialMedias.ToListAsync();
            return View(socialMedia.ToPagedList(page, 5));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid) return View();

            await _context.SocialMedias.AddAsync(socialMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            SocialMedia socialMedia = await _context.SocialMedias.FirstOrDefaultAsync(s => s.Id == id);
            return View(socialMedia);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, SocialMedia socialMedia)
        {
            if (!ModelState.IsValid) return View();
            SocialMedia existedSocial = await _context.SocialMedias.FirstOrDefaultAsync(s => s.Id == id);
            existedSocial.Key = socialMedia.Key;
            existedSocial.Value = socialMedia.Value;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            SocialMedia socialMedia = await _context.SocialMedias.FirstOrDefaultAsync(s => s.Id == id);
            return View(socialMedia);
        }
        public async Task<IActionResult> Delete(int id)
        {
            SocialMedia socialMedia = await _context.SocialMedias.FirstOrDefaultAsync(s => s.Id == id);
            return View(socialMedia);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSocial(int id)
        {
            SocialMedia socialMedia = await _context.SocialMedias.FirstOrDefaultAsync(s => s.Id == id);
            _context.SocialMedias.Remove(socialMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
