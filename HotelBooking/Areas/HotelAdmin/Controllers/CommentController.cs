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
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;

        public CommentController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            List<Comment> comments = await _context.Comments.ToListAsync();
            return View(comments.ToPagedList(page, 5));
        }
        public async Task<IActionResult> LikeComment(int id)
        {
            Comment existed = await _context.Comments.FirstOrDefaultAsync(s => s.Id == id);
            if (existed == null) return NotFound();
            if (existed.Status == false)
            {
                existed.Status = true;
            }
            else
            {
                existed.Status = false;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteComment(int id)
        {
            Comment comment = await _context.Comments.FirstOrDefaultAsync(s => s.Id == id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
