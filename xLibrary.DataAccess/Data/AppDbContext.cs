using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.DataAccess
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
