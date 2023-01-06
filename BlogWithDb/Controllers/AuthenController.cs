using BlogWithDb.Models;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
//using Microsoft.VisualBasic;
//using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogWithDb.Controllers
{
    public class AuthenController : Controller
    {
       // private readonly UserManager<AppUser> _userManager;
        //private readonly IConfiguration _configuration;
        public AuthenController()
        {
            //_userManager = userManager;
           // _configuration = configuration;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (loginModel.Username == "Admin" && loginModel.Password == "123")
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, loginModel.Username),
                    new Claim("Other properties", "Exampe: roles"),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = false,

                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index", "Home");
            }
                return Unauthorized();
            //return View();
        }
        /*public IActionResult Register()
        {
            return View();
        }
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var foundUser = await _userManager.FindByNameAsync(registerModel.Username);

            if (foundUser != null)
            {
                return Ok("User already exist!");
            }
            var user = new AppUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                return Ok("User creation faild!");
            }
            return RedirectToAction("login");

        }*/
    }
}