using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configuration
{
    public class ApplicationDbContext: DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.VillaConfiguration();
        }

        public DbSet<Entities.Villa> Villas { get; set; }
    }
}
