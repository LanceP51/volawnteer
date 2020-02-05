using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using voLAWNteer.Models;

namespace voLAWNteer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //DB SETS
        public DbSet<Lawn> Lawn { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Building new users with Entity

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                City = "Huntington",
                State = "WV",
                ZipCode = 25705,
                Phone = "1-304-555-8987",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            //restricting delete behaviors

            modelBuilder.Entity<Lawn>().HasMany(lawn => lawn.Services).WithOne(service => service.Lawn)
             .OnDelete(DeleteBehavior.SetNull);

            
            // Create seed data with examples
            modelBuilder.Entity<Lawn>().HasData(
                new Lawn()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Phone = "1-304-949-6521",
                    StreetAddress = "409 Lower Terrace",
                    City =  "Huntington",
                    State = "WV",
                    ZipCode = 25075,
                    Size = "1/2 acre",
                    Description = "front flat, small front yard with bigger fenced-in back yard. no pets. lots of twigs in the front yard from big tree.",
                    Approved = true,
                    Photo = "https://photos.zillowstatic.com/p_f/ISe8ba6wmiq77x1000000000.jpg"
                },
                new Lawn()
                {
                    Id = 2,
                    FirstName = "Sue",
                    LastName = "Stevens",
                    Phone = "1-304-555-7846",
                    StreetAddress = "414 Lower Terrace",
                    City = "Huntington",
                    State = "WV",
                    ZipCode = 25075,
                    Size = "1/3 acre",
                    Description = "front and side flat, back on  hill, small front yard with bigger side and back yard. no pets. lots of little plants around the yard.",
                    Approved = true,
                    Photo = "https://photos.zillowstatic.com/p_f/ISah3j9f61b8w41000000000.jpg"
                },
                new Lawn()
                {
                    Id = 3,
                    FirstName = "Raven",
                    LastName = "Baxter",
                    Phone = "1-304-342-5487",
                    StreetAddress = "203 Crestview Drive",
                    City = "Charleston",
                    State = "WV",
                    ZipCode = 25302,
                    Size = "1.75 acres",
                    Description = "small flat front yard, really big side and back back yard. no pets. lots of sticks in the yard from big trees. big and fairly steep in the back.",
                    Approved = true,
                    Photo = "https://photos.zillowstatic.com/uncropped_scaled_within_1536_1152/IS7606fi40z9km1000000000.webp"
                }
            );
            modelBuilder.Entity<Service>().HasData(
                new Service()
                {
                    Id = 1,
                    CompletedDate = new DateTime (2020,01,21),
                    ListingCreated = new DateTime(2020, 01, 01),
                    LawnId = 1
                },
                new Service()
                {
                    Id = 2,
                    CompletedDate = null,
                    ListingCreated = new DateTime(2020, 01, 12),
                    LawnId = 2
                },
                new Service()
                {
                    Id = 3,
                    CompletedDate = null,
                    ListingCreated = new DateTime(2020, 01, 06),
                    LawnId = 1
                }
            );

        }
    }
}
