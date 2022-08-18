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
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<SocialMedia>> GetSocial()
        {
            List<SocialMedia> socialMedias = await _context.SocialMedias.ToListAsync();
            return socialMedias;
        }
        public async Task<List<Setting>> GetSetting()
        {
            List<Setting> settings = await _context.Settings.ToListAsync();
            return settings;
        }
    }
}
