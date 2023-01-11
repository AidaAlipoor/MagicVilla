using MagicVilla.WebAPI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.WebAPI.DataAccess.Configuration
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
