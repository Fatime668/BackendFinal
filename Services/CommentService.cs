using DataAccess.Data;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CommentService
    {
        private readonly AppDbContext _context;

        public CommentService(AppDbContext context)
        {
            _context = context;
        }
        public  bool LeaveComment(Comment comment)
        {
            _context.Comments.Add(comment);
            return _context.SaveChanges() > 0;

        }
    }
}
