using DataAccess.Data;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GalleryService:IGalleryService
    {
        private readonly AppDbContext _context;

        public GalleryService(AppDbContext context)
        {
            _context = context;
        }
        public List<Gallery> GetGalleries()
        {
            return _context.Galleries.ToList();
        }
        public List<Category> GetCategories()
        {
            return _context.Categories.Include(c=>c.Galleries).ToList();
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }
        public List<Gallery> GalleryFilter(int? categoryId)
        {
            IQueryable<Gallery> galleries = _context.Galleries.AsQueryable();
            if (categoryId.HasValue)
            {
                galleries = galleries.Where(r => r.CategoryId == categoryId);
            }
            return galleries.ToList();
        }

        
    }
}
