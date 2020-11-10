using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Book> books { get; set; }
    }
}