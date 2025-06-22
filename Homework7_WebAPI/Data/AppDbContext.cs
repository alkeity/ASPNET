using Homework7_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework7_WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserData> Storage { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }
    }
}
