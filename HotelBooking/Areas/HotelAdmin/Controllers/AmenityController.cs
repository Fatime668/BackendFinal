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
    public class AmenityController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AmenityController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Amenity> amenities = await _context.Amenities.ToListAsync();
            return View(amenities);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Amenity amenity)
        {
            if (!ModelState.IsValid) return View();
            //if (amenity.Name == null) return View();
            
            if (amenity.Photo!=null )
            {
                if (!amenity.Photo.IsOkay(1))
                {
                    ModelState.AddModelError("Photo", "Please choose supported file");
                    return View();
                }
                amenity.ImageUrl = await amenity.Photo.FileCreate(_env.WebRootPath, @"assets\images\amenity");
                await _context.Amenities.AddAsync(amenity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please choose file");
                return View();
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            Amenity existedAmenity = await _context.Amenities.FirstOrDefaultAsync(a => a.Id == id);
            if (existedAmenity == null) return NotFound();
           
            return View(existedAmenity);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id,Amenity amenity)
        {
            if (!ModelState.IsValid)
            {
                return View(amenity);
            }
            Amenity existedAmenity = await _context.Amenities.FirstOrDefaultAsync(s => s.Id == id);
            if (amenity.Photo != null)
            {
                if (!amenity.Photo.IsOkay(1))
                {
                    string path = _env.WebRootPath + @"\assets\images\amenity\" + existedAmenity.ImageUrl;
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    existedAmenity.ImageUrl = await amenity.Photo.FileCreate(_env.WebRootPath, @"assets\images\amenity");

                }
                else
                {
                    ModelState.AddModelError("Photo", "Selected image is not valid!");
                    return View(amenity);
                }
            }
            
            existedAmenity.Name = amenity.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Amenity existedAmenity = await _context.Amenities.FirstOrDefaultAsync(s => s.Id == id);
            return View(existedAmenity);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Amenity amenity = await _context.Amenities.FirstOrDefaultAsync(s => s.Id == id);
            if (amenity == null) return NotFound();

            return View(amenity);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FirstOrDefaultAsync(s => s.Id == id);
            if (amenity == null) return NotFound();
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
