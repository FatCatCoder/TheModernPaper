using ModernPaper.Data;
using ModernPaper.Models;
using ModernPaper.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace ModernPaper.Services
{
    public class ArticleService
    {
        private readonly ApplicationDbContext _context;

        public ArticleService(ApplicationDbContext context)
        {
            _context = context;
        }

        // CRUD Operations

        public IEnumerable<Article> GetAll()
        {
            //IQueryable<Article> allArticles = _context.Articles.Select(x => x);

            return _context.Articles!
                .AsNoTracking()
                .ToList();
        }
    }
}