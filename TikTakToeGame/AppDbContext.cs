
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Reflection.Emit;

using TikTakToeGame.Entities;

namespace TikTakToeGame
{
    public class AppDbContext : DbContext
    {
        public DbSet<Field> Fields { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Turn> Turns { get; set; }
     
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
   
}
