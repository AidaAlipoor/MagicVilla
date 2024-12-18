﻿using DataAccess.Entities;
using DataAccess.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.VillaConfig();
            modelBuilder.VillaNumberConfig();
            modelBuilder.LocalUserConfig();
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id= 1,
                    Name ="Villa",
                    Detail = "",
                    Price = 30000000,
                    Rate = 0,
                    Occupancy = 10,
                    Amenity ="",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                },
                new Villa 
                { 
                    Id = 2,
                    Name = "Villa2",
                    Detail = "...",
                    Price = 400000000,
                    Rate = 0,
                    Occupancy = 10,
                    Amenity = "",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                }
                );
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
    }
}
