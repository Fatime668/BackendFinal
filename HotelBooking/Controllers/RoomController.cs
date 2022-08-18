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
        private readonly CommentService _commentService;

        public RoomController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _env = env;
            _roomService = new RoomService(context);
            _commentService = new CommentService(context);
        }
        public async Task<IActionResult> Index(int? roomTypeId, int? minPrice, int? maxPrice, int? sortBy)
        {
            //if ( page == 0) return NotFound();
            //var query = _context.Rooms.AsQueryable();
            //ViewBag.TotalPage = Math.Ceiling(((decimal)await query.CountAsync()) / 9);
            //ViewBag.CurrentPage = page;
            //ViewBag.Rooms = await _context.Rooms.Include(r => r.RoomPictures).Include(r => r.Comments).ToListAsync();
            RoomFilterVM filterVM = new RoomFilterVM
            {
                Rooms = _roomService.SearchRoomFilter(roomTypeId, minPrice, maxPrice,sortBy),
                RoomTypes = await _roomService.GetTypes(),
                RoomTypeId =roomTypeId,
                SortBy =sortBy,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                MaxAllPrice = _roomService.FindRoomMaxPrice(),
            };

            return View(filterVM);


            //ViewBag.TotalPage = Math.Ceiling(((decimal)await _roomService.Count()) / 9);
            //ViewBag.CurrentPage = page;
            //List<Room> rooms = await _Include(r => r.RoomPictures).Skip((page-1) * 9).Take(9).ToListAsync();
        }

        public async Task<IActionResult> Details(int? id, int page = 1)
        {
            if (id == null || id == 0 || page == 0) return NotFound();
            var query = _context.Comments.AsQueryable();
            ViewBag.RoomId = id;
            ViewBag.TotalPage = Math.Ceiling(((decimal)await query.CountAsync()) / 3);
            ViewBag.CurrentPage = page;
            ViewBag.Rooms = await _context.Rooms.Include(r => r.RoomPictures).Include(r=>r.Comments).ToListAsync();
            RoomVM model = new RoomVM
            {
                Room = await _context.Rooms.Include(r => r.RoomPictures).Include("Bookings").Include("Comments")
             .Include(r => r.RoomAmentiys).ThenInclude(r => r.Amenity).FirstOrDefaultAsync(r => r.Id == id),

                Booking = await _context.Bookings.FirstOrDefaultAsync(),
                Comments = await query.Skip((page - 1) * 3).Take(3).ToListAsync(),
                Comment = await _context.Comments.FirstOrDefaultAsync()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Details(int id, Booking booking)
        {

            if (User.Identity.IsAuthenticated)
            {
                if (!ModelState.IsValid) return View();
                ViewBag.Rooms = await _context.Rooms.ToListAsync();
                booking.AppUser = await _userManager.FindByNameAsync(User.Identity.Name);
                booking.RoomId = id;
                await _context.Bookings.AddAsync(booking);
                await _context.SaveChangesAsync();
                TempData["Rezerv"] = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
        }





        [HttpPost]
        public async Task<IActionResult> AddComment(int id, Comment comment)
        {
            if (User.Identity.IsAuthenticated)
            {

                comment.CreatedDate = Convert.ToDateTime(DateTime.Now);
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                comment.Name = user.UserName;
                comment.Email = user.Email;
                //comment.AppUser.Id == user.Id;
                //ViewBag.Id = room.Id;
                //Room existedRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);

                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
        }




        //[HttpPost]
        //public async Task<IActionResult> AddComment(int? id, int? star, string comment)
        //{
        //    if (!User.Identity.IsAuthenticated) return RedirectToAction("login", "account");
        //    if (id is null || star is null || star <= 0 || star > 5) return NotFound();

        //    Comment comment1 = new Comment();

        //    AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

        //    if (_context.Comments.Any(x => x.RoomId == id && x.AppUser.Id == appUser.Id))
        //        return RedirectToAction(nameof(Details), new { id });
        //    comment1.AppUser.Id = appUser.Id;
        //    comment1.Fullname = appUser.UserName;
        //    comment1.Star = (int)star;
        //    RoomVM roomVM = new RoomVM()
        //    {
        //        Room = await _context.Rooms.FirstOrDefaultAsync(p => p.Id == id ),
        //        Comments = await _context.Comments.Where(p => p.RoomId == id ).ToListAsync()
        //    };

        //    if (string.IsNullOrWhiteSpace(comment) || string.IsNullOrEmpty(comment) || comment.Length > 1000)
        //        return RedirectToAction(nameof(Details), new { id });


        //    comment1.CommentContent = comment.Trim();
        //    comment1.RoomId = (int)id;
        //    comment1.CommentDate = DateTime.UtcNow.AddHours(4);

        //    await _context.Comments.AddAsync(comment1);
        //    await _context.SaveChangesAsync();

        //    roomVM = new RoomVM()
        //    {
        //        Room = await _context.Rooms.FirstOrDefaultAsync(p => p.Id == id),
        //        Comments = await _context.Comments.Where(p => p.RoomId == id).ToListAsync()
        //    };

        //    return RedirectToAction(nameof(Details), new { id });


        //}



       
    }
}
