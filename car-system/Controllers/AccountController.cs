using car_system.Models;
using car_system.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace car_system.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;

        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager, RoleManager<UserRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("/api/User/Register")]
        public async Task<IActionResult> Register(RegisterView model)
        {
            if (ModelState.IsValid)
            {
                var user = new Users
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    Phone = model.PhoneNumber,
                    Address = model.Address
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Check if the role "CUSTOMER" exists
                    var roleExists = await _roleManager.RoleExistsAsync("CUSTOMER");
                    if (!roleExists)
                    {
                        // Create the role "CUSTOMER" if it doesn't exist
                        var role = new UserRole { Name = "CUSTOMER", NormalizedName = "CUSTOMER" };
                        await _roleManager.CreateAsync(role);
                    }

                    // Assign the "CUSTOMER" role to the user
                    await _userManager.AddToRoleAsync(user, "CUSTOMER");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    // Registration successful
                    return Ok(new { Message = "Registration successful" });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    // Registration failed
                    return BadRequest(new { Message = "Registration failed", Errors = ModelState.Values.SelectMany(v => v.Errors) });
                }
            }

            // Invalid model state
            return BadRequest(new { Message = "Invalid model state", Errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginModel = new LoginView();
            return View(loginModel);
        }
        [HttpPost]
        [Route("/api/User/Login")]
        public async Task<IActionResult> Login(LoginView model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Get the user details
                    var user = await _userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        // Get the user ID
                        string userId = user.Id;

                        // Store the user ID in the session
                        HttpContext.Session.SetString("UserId", userId);

                        // Get the roles assigned to the user
                        var roles = await _userManager.GetRolesAsync(user);

                        // Check the role of the user
                        if (roles.Contains("Admin"))
                        {
                            // Redirect to the admin page
                            return RedirectToAction("AdminCar", "Home");
                        }
                        else if (roles.Contains("Staff"))
                        {
                            // Redirect to the staff page
                            return RedirectToAction("StaffPage", "Home");
                        }
                        else if (roles.Contains("Customer"))
                        {
                            // Redirect to the customer page
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            // Role not found, handle accordingly
                            return BadRequest(new { Message = "Role not found" });
                        }
                    }
                    else
                    {
                        // User not found
                        return BadRequest(new { Message = "User not found" });
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                    // Login failed
                    return BadRequest(new { Message = "Login failed", Errors = ModelState.Values.SelectMany(v => v.Errors) });
                }
            }

            // Invalid model state
            return BadRequest(new { Message = "Invalid model state", Errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("/api/User/ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordView model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return NotFound(new { Message = "User not found" });
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(user);
                    // Password change successful
                    return Ok(new { Message = "Password change successful" });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    // Password change failed
                    return BadRequest(new { Message = "Password change failed", Errors = ModelState.Values.SelectMany(v => v.Errors) });
                }
            }

            // Invalid model state
            return BadRequest(new { Message = "Invalid model state", Errors = ModelState.Values.SelectMany(v => v.Errors) });
        }
    }

}
