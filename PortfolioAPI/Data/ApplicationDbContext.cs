using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;


namespace PortfolioAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}

