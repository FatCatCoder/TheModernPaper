using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using ModernPaper.Models;

namespace ModernPaper.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Article>? Articles { get; set; }
    }
}