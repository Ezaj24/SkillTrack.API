using Microsoft.EntityFrameworkCore;
using SkillTrack.API.Models;

namespace SkillTrack.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Goal> Goals { get; set; }
    }
}
