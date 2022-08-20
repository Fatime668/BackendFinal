using DataAccess.Data;
using Entities.Concrete;
using HotelBooking.Extensions;
using HotelBooking.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            if (slider.Photo != null)
            {
                if (slider.Photo.IsOkay(1))
                {
                    slider.ImageUrl = await slider.Photo.FileCreate(_env.WebRootPath, @"assets\images\slider");
                    await _context.Sliders.AddAsync(slider);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Photo", "Please choose image file and max 1MB");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Photo", "Please, choose image file");
                return View();
            }

        }
        public async Task<IActionResult> Edit(int id)
        {
            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            return View(existedSlider);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Slider slider)
        {
            if (!ModelState.IsValid) return View();
            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider.Photo != null)
            {
                if (slider.Photo.IsOkay(1))
                {
                    string path = _env.WebRootPath + @"\assets\images\slider\" + existedSlider.ImageUrl;
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    existedSlider.ImageUrl = await slider.Photo.FileCreate(_env.WebRootPath, @"assets\images\slider");
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Photo", "Please choose supported file");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Photo", "Please choose file");
                return View();
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            return View(existedSlider);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            return View(existedSlider);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            _context.Sliders.Remove(existedSlider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
