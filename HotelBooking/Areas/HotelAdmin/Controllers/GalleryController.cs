using DataAccess.Data;
using Entities.Concrete;
using HotelBooking.Extensions;
using HotelBooking.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class GalleryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public GalleryController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Gallery> galleries = await _context.Galleries.ToListAsync();
            return View(galleries);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Gallery gallery)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            if (!ModelState.IsValid) return View();
           
            if (gallery.Photo == null)
            {
                ModelState.AddModelError("Photo", "Please, choose image file");
                return View();
            }
            else
            {
                
                if (gallery.Photo.IsOkay(1))
                {
                    gallery.ImagePath = await gallery.Photo.FileCreate(_env.WebRootPath, @"assets\images\gallery\all");
                    await _context.Galleries.AddAsync(gallery);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Photo", "Please choose image file and max 1MB");
                    return View();
                }
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid) return View();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            Gallery existed = await _context.Galleries.FirstOrDefaultAsync(g => g.Id == id);
            if (existed == null)
            {
                return NotFound();
            }
            return View(existed);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Gallery gallery)
        {
            if (!ModelState.IsValid) return View(gallery);
            ViewBag.Categories = await _context.Categories.ToListAsync();
            Gallery existed = await _context.Galleries.FirstOrDefaultAsync(g => g.Id == id);
            if (gallery.Photo != null)
            {
                if (gallery.Photo.IsOkay(1))
                {
                    string path = _env.WebRootPath + @"\assets\images\gallery\all\" + existed.ImagePath;
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    existed.ImagePath = await gallery.Photo.FileCreate(_env.WebRootPath, @"assets\images\gallery\all");
                   
                }
                else
                {
                    ModelState.AddModelError("Photo", "Please choose supported file");
                    return View(gallery);
                }
            }
            existed.Title = gallery.Title;
            existed.Subtitle = gallery.Subtitle;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Gallery existed = await _context.Galleries.FirstOrDefaultAsync(g => g.Id == id);
            if (existed==null)
            {
                return NotFound();
            }
            return View(existed);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Gallery existed = await _context.Galleries.FirstOrDefaultAsync(g => g.Id == id);
            if (existed == null)
            {
                return NotFound();
            }
            return View(existed);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteGallery(int id)
        {
            Gallery existed = await _context.Galleries.FirstOrDefaultAsync(g => g.Id == id);
            _context.Galleries.Remove(existed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
