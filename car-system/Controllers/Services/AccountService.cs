﻿using car_system.Controllers.Data;
using car_system.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace car_system.Controllers.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public AccountService(UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Users> LoginUser(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return user; // Return the user if the login is successful
                }
            }

            throw new InvalidOperationException("Invalid login attempt.");
        }

        public async Task RegisterUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();  
        }
    }
}
