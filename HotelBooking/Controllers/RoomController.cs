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
                Rooms = _roomService.SearchRoomFilter(roomTypeId, minPrice, maxPrice, sortBy),
                RoomTypes = await _roomService.GetTypes(),
                RoomTypeId = roomTypeId,
                SortBy = sortBy,
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

            if (id == null || id == 0 || page <= 0) return NotFound();
            var query = _context.Comments.AsQueryable();
            ViewBag.RoomId = id;
            ViewBag.TotalPage = Math.Ceiling(((decimal)await query.CountAsync()) / 3);
            ViewBag.CurrentPage = page;
            ViewBag.Rooms = await _context.Rooms.Include(r => r.RoomPictures).Include(r => r.Comments).ToListAsync();
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


        public async Task<IActionResult> Review(int? rid, string Message, int star = 1)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(0);
            }
            if (rid == null) return View();
            Comment review = new Comment();

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);
            review.Email = appUser.Email;
            review.Name = appUser.Firstname+" "+appUser.Lastname;
            review.Message = Message;
            review.Star = star;
            RoomVM roomVM = new RoomVM()
            {
                Room = await _context.Rooms.FirstOrDefaultAsync(p => p.Id == rid),
                Comments = await _context.Comments.Where(p => p.RoomId == rid).ToListAsync()
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
                Comments = await _context.Comments.Where(p => p.RoomId == rid).ToListAsync()
            };
            return PartialView("_ReviewStarPartial", roomVM);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            Comment review = await _context.Comments
                .FirstOrDefaultAsync(r => r.Id == id);
            if (review == null) return NotFound();

            review.IsDeleted = true;
            //review.DeletedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
            RoomVM roomVM = new RoomVM()
            {
                Room = await _context.Rooms.FirstOrDefaultAsync(P => P.Id == review.RoomId),
                Comments = await _context.Comments.Where(p => p.RoomId == review.RoomId && !p.IsDeleted).ToListAsync()
            };
            return PartialView("_ReviewStarPartial", roomVM);
        }
      

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> AddRoomReview(int? id, int? star, string comment)
        //{
        //    if (User.Identity.IsAuthenticated) return RedirectToAction("login", "account");
        //    if (id is null || star is null || star <= 0 || star > 5) return NotFound();
        //    Comment review = new Comment();

        //    AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

        //    if (_context.Comments.Any(x => x.RoomId == id && x.AppUser.Id == appUser.Id))
        //        return RedirectToAction(nameof(Room), new { id });
        //    review.AppUser.Id = appUser.Id;
        //    review.Email = appUser.Email;
        //    review.Name = appUser.UserName;
        //    review.Star = (int)star;

        //    RoomVM roomVM = new RoomVM
        //    {
        //        Room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id),
        //        Comments = await _context.Comments.Where(c => c.RoomId == id).ToListAsync()
        //    };
        //    if (string.IsNullOrWhiteSpace(comment) || string.IsNullOrEmpty(comment) || comment.Length > 1000)
        //        return RedirectToAction(nameof(Room), new { id });

        //    review.Message = comment.Trim();
        //    review.RoomId = (int)id;
        //    review.CreatedDate = DateTime.UtcNow.AddHours(4);

        //    await _context.Comments.AddAsync(review);
        //    await _context.SaveChangesAsync();

        //    roomVM = new RoomVM()
        //    {
        //        Room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id),
        //        Comments = await _context.Comments.Where(r => r.RoomId == id).ToListAsync()
        //    };

        //    return RedirectToAction(nameof(Room) , new { id });


        //}

        //[HttpPost]
        //public async Task<IActionResult> AddComment(int id, Comment comment)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {

        //        comment.CreatedDate = Convert.ToDateTime(DateTime.Now);
        //        AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
        //        comment.Name = user.UserName;
        //        comment.Email = user.Email;
        //        //comment.AppUser.Id == user.Id;
        //        //ViewBag.Id = room.Id;
        //        //Room existedRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);

        //        await _context.Comments.AddAsync(comment);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));


        //    }
        //    else
        //    {
        //        return RedirectToAction("Register", "Account");
        //    }
        //}

    }
}
