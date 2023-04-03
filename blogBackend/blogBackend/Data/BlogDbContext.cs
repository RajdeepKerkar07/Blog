using blogBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace blogBackend.Data
{
    public class BlogDbContext :DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
