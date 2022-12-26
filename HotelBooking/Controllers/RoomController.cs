using DataAccess.Data;
using Entities.Concrete;
using HotelBooking.Helper;
using HotelBooking.Utilities;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{

    public class RoomController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _env;
        private readonly RoomService _roomService;

        public RoomController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _env = env;
            _roomService = new RoomService(context);
        }
        public async Task<IActionResult> Index(int? roomTypeId, int? minPrice, int? maxPrice, int? sortBy)
        {
            
            RoomFilterVM filterVM = new RoomFilterVM
            {
                Rooms = _roomService.SearchRoomFilter(roomTypeId, minPrice, maxPrice, sortBy),
                RoomTypes = await _roomService.GetTypes(),
                RoomTypeId = roomTypeId,
                SortBy = sortBy,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                MaxAllPrice = _roomService.FindRoomMaxPrice(),
            };

            return View(filterVM);


        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id, int page = 1)
        {
            if (id == null || id == 0 || page <= 0) return NotFound();
            var query = _context.Comments.AsQueryable();
            ViewBag.RoomId = id;
            ViewBag.TotalPage = Math.Ceiling(((decimal)await query.CountAsync()) / 3);
            ViewBag.CurrentPage = page;
            ViewBag.Rooms = await _context.Rooms.Include(r => r.RoomPictures).ToListAsync();
            RoomVM model = new RoomVM
            {
                Room = await _context.Rooms.Include(x => x.RoomPictures)
                                           .Include(x => x.Comments)
                                           .Include(x => x.RoomAmentiys)
                                           .ThenInclude(x => x.Amenity)
                                           .FirstOrDefaultAsync(x => x.Id == id),

                Booking = await _context.Bookings.FirstOrDefaultAsync(),

                Comments = await query.Skip((page - 1) * 3).Take(3).Include(p=>p.AppUser).ToListAsync(),

                Comment = await _context.Comments.FirstOrDefaultAsync()

            };
            ViewBag.Username = _userManager.GetUserName(HttpContext.User);
            return View(model);
        }
        //reservation
        public async Task<bool> IsReserved(DateTime startDateTime, DateTime EndDateTime, int RoomId)
        {
            var room = await _context
                .Rooms
                .Where(p => p.Id == RoomId)
                .Include(p => p.Bookings)
                .FirstOrDefaultAsync();
           
            if (room.Bookings.Count == 0) return false;
           
            List<bool> results = new List<bool>();

            EndDateTime = EndDateTime.Date;
            startDateTime = startDateTime.Date;
            foreach (var reserv in room.Bookings)
            {
                reserv.ArrivalDate = reserv.ArrivalDate.Date;
                reserv.DepartureDate = reserv.DepartureDate.Date;
                if (reserv.ArrivalDate == startDateTime && reserv.DepartureDate == EndDateTime)
                {
                    //ust uste dusme hali
                    results.Add(true);
                    // return true;
                }
                else if (reserv.ArrivalDate < startDateTime && reserv.DepartureDate > EndDateTime)
                {
                    results.Add(true);
                    // return true;
                    // //ic de  olma hali
                }
                else if (reserv.ArrivalDate > startDateTime && reserv.DepartureDate < EndDateTime)
                {
                    // colunden ehate etme hali
                    results.Add(true);
                    // return true;
                }
                else if (reserv.ArrivalDate > startDateTime && reserv.DepartureDate >= EndDateTime &&
                         reserv.ArrivalDate < EndDateTime)
                {
                    // Soldan yanashma 
                    results.Add(true);
                    // return true;
                }
                else if (reserv.ArrivalDate <= startDateTime && reserv.DepartureDate < EndDateTime &&
                         reserv.DepartureDate > startDateTime)
                {
                    // sagdan  yanashma 
                    results.Add(true);
                    // return true;
                }
                else
                {
                    results.Add(false);

                    //  return false;
                }
            }

            if (results.Contains(true))
            {
                return true;
            }

            return false;

        }

        //reservation

        [HttpPost]
        public async Task<IActionResult> Details(int id, Booking booking)
        {
            AppUser appUser = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (appUser == null)
            {
                return RedirectToAction("login", "Account");
            }

            var isReserved = await IsReserved(booking.ArrivalDate, booking.DepartureDate, id);
            if (isReserved)
            {
                TempData["IsReserved"] = true;
                return RedirectToAction("Details","Room");
            }

            booking.BookingStatusId = 1;

            booking.AppUser = await _userManager.FindByNameAsync(User.Identity.Name);
            booking.RoomId = id;
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            TempData["Booking"] = true;
            return RedirectToAction("Details", "Room");
           
        }
        //add comment
        public async Task<IActionResult> Review(int? rid, string Message, int star = 1)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(0);
            }
            if (rid == null) return View();

            Comment review = new Comment();

            AppUser appUser = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (appUser is null) return Json(0);
            
            review.Email = appUser.Email;
            review.Name = appUser.Firstname + " " + appUser.Lastname;
            review.Message = Message;
            review.Star = star;
            RoomVM roomVM = new RoomVM()
            {
                Room = await _context.Rooms
                .FirstOrDefaultAsync(p => p.Id == rid),

                Comments = await _context.Comments.
                Where(p => p.RoomId == rid)
                .ToListAsync()
            };
            if (review.Message == null || review.Email == null || review.Name == null) return PartialView("_ReviewStarPartial", roomVM);

            if (review.Star == null || review.Star < 0 || review.Star > 5)
            {
                review.Star = 1;
            }
            review.RoomId = (int)rid;
            review.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _context.Comments.AddAsync(review);
            await _context.SaveChangesAsync();
            roomVM = new RoomVM()
            {
                Room = await _context.Rooms.FirstOrDefaultAsync(p => p.Id == rid),

                Comments = await _context.Comments
                .Where(p => p.RoomId == rid)
                .ToListAsync()
            };
            return PartialView("_ReviewStarPartial", roomVM);
        }

        //delete comment
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null) return BadRequest();

        //    Comment review = await _context.Comments.FirstOrDefaultAsync(r => r.Id == id);
        //    if (review == null) return NotFound();

        //    review.IsDeleted = true;
        //     RoomVM roomVM = new RoomVM()
        //    {
        //        Room = await _context.Rooms.FirstOrDefaultAsync(P => P.Id == review.RoomId),

        //        Comments = await _context.Comments
        //        .Where(p => p.RoomId == review.RoomId && !p.IsDeleted)
        //        .ToListAsync()
        //    };
        //    _context.Comments.Remove(review);
        //    await _context.SaveChangesAsync();
           
        //    return PartialView("_ReviewStarPartial", roomVM);
        //}
    }
}
