using DataAccess.Data;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TestimonialService
    {
        private readonly AppDbContext _context;

        public TestimonialService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Testimonial>> GetTestimonials()
        {
            return await _context.Testimonials.ToListAsync();
        }
        public async Task<Testimonial> GetTestimonialById(int id)
        {
            return await _context.Testimonials.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
