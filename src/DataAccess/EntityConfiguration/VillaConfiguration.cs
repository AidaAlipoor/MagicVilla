using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityConfiguration
{
    public static class VillaConfiguration
    {
        public static void VillaConfig(this ModelBuilder modelBuilder)
        {
                var villaEntity = modelBuilder.Entity<Entities.Villa>();
                villaEntity.HasKey(v => v.Id);
                villaEntity.Property(v => v.Name).HasMaxLength(128).IsRequired();    
        }
    }
}
