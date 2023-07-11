using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityConfiguration
{
    internal static class VillaNumberConfiguration
    {
        public static void VillaNumberConfig(this ModelBuilder modelBuilder)
        {
            var villaNumberEntity = modelBuilder.Entity<VillaNumber>();
            villaNumberEntity.HasKey(v => v.Id);
            villaNumberEntity.HasOne(vn => vn.Villa)
                .WithMany(v => v.VillaNumber);
        }
    }
}
