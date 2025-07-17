using Microsoft.EntityFrameworkCore;
using AccessControlAPI.Models;

namespace AccessControlAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Device> Devices { get; set; } = null!;
    }
}
