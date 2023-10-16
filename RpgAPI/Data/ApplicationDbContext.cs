using Microsoft.EntityFrameworkCore;
using RpgAPI.Models;

namespace RpgAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<RpgClass> RpgClasses { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
    }
}
