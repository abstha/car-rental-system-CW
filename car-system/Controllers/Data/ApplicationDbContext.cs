using car_system.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace car_system.Controllers.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users, UserRole, string>
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
                .WithMany(u => u.RentalRequests)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalRequest>()
                .HasOne(r => r.Car)
                .WithMany()
                .HasForeignKey(r => r.CarRented)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Damages>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserID);

            modelBuilder.Entity<Damages>()
                .HasOne(d => d.Car)
                .WithMany()
                .HasForeignKey(d => d.CarID);


            modelBuilder.Entity<Attachment>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserID);

            modelBuilder.Entity<Offers>()
                .HasOne(o => o.CreatedByUser)
                .WithMany()
                .HasForeignKey(o => o.CreatedByUserID);

            modelBuilder.Entity<Offers>()
                .Property(o => o.Value)
                .HasPrecision(18, 2);




            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            // Seed user roles
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = "1", Name = "Staff", NormalizedName = "STAFF" },
                new UserRole { Id = "2", Name = "Admin", NormalizedName = "ADMIN" },
                new UserRole { Id = "3", Name = "Customer", NormalizedName = "CUSTOMER" }
            );
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<RentalRequest> RentalRequests { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Offers> Offers { get; set; }

        public DbSet<Damages> Damages { get; set; }

    }
}

