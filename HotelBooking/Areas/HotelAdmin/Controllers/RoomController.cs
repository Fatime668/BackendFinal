using DataAccess.Data;
using Entities.Concrete;
using HotelBooking.Extensions;
using HotelBooking.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using X.PagedList;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public RoomController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            List<Room> rooms = await _context.Rooms.Include(r => r.RoomPictures)
                .ToListAsync();
            return View(rooms);
            //.ToPagedList(page, 5)
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.RoomTypes = await _context.RoomTypes.ToListAsync();
            ViewBag.Amenities = await _context.Amenities.ToListAsync();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Room room)
        {
            ViewBag.RoomTypes = await _context.RoomTypes.ToListAsync();
            ViewBag.Amenities = await _context.Amenities.ToListAsync();
            if (!ModelState.IsValid) return View();
            if (room.MainImage == null || room.AnotherImages == null)
            {
                ModelState.AddModelError("", "Please choose main image or another image");
                return View();
            }
            if ((room.NoOfBed > 8 || room.NoOfBed < 0))
            {
                ModelState.AddModelError("", "You can enter a number between 1 and 8");
                return View();
            }
            if ((room.NoOfBath > 8 || room.NoOfBath < 0))
            {
                ModelState.AddModelError("", "You can enter a number between 1 and 8");
                return View();
            }
            if (!room.MainImage.IsOkay(1))
            {
                ModelState.AddModelError("MainImage", "Please choose image file and max 1MB");
                return View();
            }
            foreach (var image in room.AnotherImages)
            {
                if (!image.IsOkay(1))
                {
                    ModelState.AddModelError("AnotherImages", "Please choose image file and max 1MB");
                    return View();
                }
            }
            room.RoomPictures = new List<RoomPicture>();

            RoomPicture mainImage = new RoomPicture
            {
                ImagePath = await room.MainImage.FileCreate(_env.WebRootPath, @"assets\images\rooms"),
                IsMain = true,
                Room = room
            };
            room.RoomPictures.Add(mainImage);

            foreach (var image in room.AnotherImages)
            {
                RoomPicture another = new RoomPicture
                {
                    ImagePath = await image.FileCreate(_env.WebRootPath, @"assets\images\rooms"),
                    IsMain = false,
                    Room = room
                };
                room.RoomPictures.Add(another);

            }
            room.RoomAmentiys = new List<RoomAmentiy>();
            foreach (var id in room.AmenityIds)
            {
                RoomAmentiy roomAmentiy = new RoomAmentiy
                {
                    Room = room,
                    AmenityId = id
                };
                room.RoomAmentiys.Add(roomAmentiy);

            }
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Edit(int id)
        {

            ViewBag.RoomTypes = await _context.RoomTypes.ToListAsync();
            ViewBag.Amenities = await _context.Amenities.ToListAsync();
            Room room = await _context.Rooms.Include(r => r.RoomPictures).Include(r => r.RoomAmentiys).FirstOrDefaultAsync(r => r.Id == id);
            if (room == null) return NotFound();
            return View(room);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Room room)
        {
            ViewBag.RoomTypes = await _context.RoomTypes.ToListAsync();
            ViewBag.Amenities = await _context.Amenities.ToListAsync();
            ViewBag.RoomPictures = await _context.RoomPictures.ToListAsync();
            Room existed = await _context.Rooms.Include(r => r.RoomPictures).Include(r => r.RoomAmentiys).FirstOrDefaultAsync(r => r.Id == id);
            if (existed == null) return NotFound();

            if (room.ImageIds == null && room.AnotherImages == null)
            {
                ModelState.AddModelError("", "You can not delete all images without adding another image");
                return View(existed);
            }
            if ((room.NoOfBed >8 || room.NoOfBed<0) )
            {
                ModelState.AddModelError("", "You can enter a number between 1 and 8");
                return View(existed);
            }
            if ((room.NoOfBath > 8 || room.NoOfBath < 0))
            {
                ModelState.AddModelError("", "You can enter a number between 1 and 8");
                return View(existed);
            }
            List<RoomPicture> removableImages = existed.RoomPictures.Where(r => r.IsMain == false && !room.ImageIds.Contains(r.Id)).ToList();
            existed.RoomPictures.RemoveAll(r => removableImages.Any(ri => ri.Id == r.Id));

            List<RoomAmentiy> removableAmenities = existed.RoomAmentiys.Where(r => !room.AmenityIds.Contains(r.AmenityId)).ToList();
            existed.RoomAmentiys.RemoveAll(ra => removableAmenities.Any(rm => rm.Id == ra.Id));

            foreach (var item in room.AmenityIds)
            {
                RoomAmentiy existedAmenity = existed.RoomAmentiys.FirstOrDefault(ra => ra.AmenityId == item);
                if (existedAmenity == null)
                {
                    RoomAmentiy roomAmentiy = new RoomAmentiy
                    {
                        RoomId = existed.Id,
                        AmenityId = item,
                    };
                    existed.RoomAmentiys.Add(roomAmentiy);
                }
            }
            foreach (var image in removableImages)
            {
                FileUtilities.FileDelete(_env.WebRootPath, @"assets\images\rooms", image.ImagePath);
            }
            if (room.AnotherImages != null)
            {
                foreach (var image in room.AnotherImages)
                {
                    RoomPicture roomPicture = new RoomPicture
                    {
                        ImagePath = await image.FileCreate(_env.WebRootPath, @"assets\images\rooms"),
                        IsMain=false,
                        RoomId = existed.Id
                    };
                    existed.RoomPictures.Add(roomPicture);
                }
            }
            _context.Entry(existed).CurrentValues.SetValues(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Room room = await _context.Rooms.Include(p => p.RoomPictures).FirstOrDefaultAsync(p => p.Id == id);
            if (room == null) return NotFound();
            return View(room);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Room room = await _context.Rooms.Include(p => p.RoomPictures).FirstOrDefaultAsync(p => p.Id == id);
            if (room == null) return NotFound();
            return View(room);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            Room room = await _context.Rooms.FirstOrDefaultAsync(p => p.Id == id);
            if (room == null) return NotFound();
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
