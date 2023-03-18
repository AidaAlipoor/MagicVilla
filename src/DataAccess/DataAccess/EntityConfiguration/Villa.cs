using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configuration
{
    public static class Villa
    {
        public static void VillaConfiguration(this ModelBuilder modelBuilder)
        {
                var villaEntity = modelBuilder.Entity<Entities.Villa>();
                villaEntity.HasKey(v => v.Id);
                villaEntity.Property(v => v.Name).HasMaxLength(128).IsRequired();    
        }
    }
}
