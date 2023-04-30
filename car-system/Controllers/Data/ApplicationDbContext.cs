﻿using car_system.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace car_system.Controllers.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Custom configurations, if any
            // Configure the relationships
            modelBuilder.Entity<RentalRequest>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<RentalRequest>()
                .HasOne(r => r.Car)
                .WithMany()
                .HasForeignKey(r => r.CarRented);
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<RentalRequest> RentalRequests { get; set; }

        // You don't need to add DbSet for Users, as it's already included in IdentityDbContext<Users>
    }

}
