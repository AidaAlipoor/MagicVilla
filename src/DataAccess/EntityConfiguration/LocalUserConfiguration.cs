using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityConfiguration
{
    public static class LocalUserConfiguration
    {
        public static void LocalUserConfig(this ModelBuilder modelBuilder)
        {
            var localUsser = modelBuilder.Entity<Entities.LocalUser>();
            localUsser.HasKey(u => u.Id);
            localUsser.Property(l => l.Name).HasMaxLength(128).IsRequired();
            localUsser.Property(l => l.UserName).HasMaxLength(128).IsRequired();
            localUsser.Property(l => l.password).HasMaxLength(8).IsRequired();
        }
    }
}
