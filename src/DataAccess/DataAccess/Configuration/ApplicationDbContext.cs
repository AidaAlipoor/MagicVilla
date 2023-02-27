using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configuration
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }


        public DbSet<DataAccess.Entities.Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.VillaConfiguration();
        }
    }
}
