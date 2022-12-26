using BlogWithDb.Models;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogWithDb.Controllers
{
    public class AuthenController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthenController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var foundUser = await _userManager.FindByNameAsync(loginModel.Username);
            if (foundUser != null && await _userManager.CheckPasswordAsync(foundUser, loginModel.Password))
            {
                var roles = await _userManager.GetRolesAsync(foundUser);
                List<Claim> claims = new List<Claim>();
                Claim claim1 = new Claim(ClaimTypes.Name, foundUser.UserName);
                Claim claim2 = new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
                claims.Add(claim1);
                claims.Add(claim2);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(_configuration["JWT:ValidIssuer"], _configuration["JWT:ValidAudience"], claims, expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));

                // Response.Cookies.Append(loginModel.Username, loginModel.Password);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
            //return View();
        }
        public IActionResult Register()
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

        }
    }
}
