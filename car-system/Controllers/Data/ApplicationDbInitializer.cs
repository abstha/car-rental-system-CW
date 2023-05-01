using car_system.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace car_system.Controllers.Data
{
    public class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Cars
                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(new List<Cars>()
                    {
                        new Cars()
                        {
                            Model = "Camaro",
                            Picture = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.dreamstime.com%2Fphotos-images%2Fchevrolet-camaro.html&psig=AOvVaw3cJdVUpoaSXyrAMzovtFuB&ust=1682572959752000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCKD7uO7mxv4CFQAAAAAdAAAAABAE",
                            Condition = "good",
                            Availability = true,
                            RentPrice = 12000
                        },
                        new Cars()
                        {
                            Model = "Mustang",
                            Picture = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FFord_Mustang&psig=AOvVaw2lT1FZEUvXdTqXj54A5bC-&ust=1682573075410000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCMifxqXnxv4CFQAAAAAdAAAAABAE",
                            Condition = "good",
                            Availability = true,
                            RentPrice = 15000
                        },
                        new Cars()
                        {
                            Model = "Gt-R",
                            Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCF6I7qJ2l75x1MG9z5oDIc6qV5wrUEIvAZWNsoSCROQ&s",
                            Condition = "good",
                            Availability = true,
                            RentPrice = 200000
                        },
                    });
                    context.SaveChanges();
                }
                // Admin User
                var adminUser = new Users()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Name = "Admin Abhinav",
                    Phone = "1234567890",
                    Address = "Patan"
                };

                // Use a password hasher to create a hashed password for the admin user
                var passwordHasher = new PasswordHasher<Users>();
                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin1!");

                // Add the admin user to the context
                context.Users.Add(adminUser);

                // Save the changes to the database
                context.SaveChanges();

                // Find the admin role by its name ("Admin" in this case)
                var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Admin");

                // If the admin role exists, assign it to the admin user
                if (adminRole != null)
                {
                    adminUser.Roles = new List<IdentityUserRole<string>>()
                    {
                        new IdentityUserRole<string>()
                        {
                            RoleId = adminRole.Id,
                            UserId = adminUser.Id
                        }
                    };
                }

                // Save the changes to the database
                context.SaveChanges();

            }

            
        }
    }
}
