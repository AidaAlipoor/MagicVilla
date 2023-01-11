using MagicVilla.WebAPI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.WebAPI.DataAccess.Configuration
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }


        public DbSet<Entities.Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.VillaConfiguration();
        }
    }
}
