using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using nameProject.webApi.Auth;
using nameProject.webApi.Auth.Models;
using nameProject.webApi.Auth.Utils;
using Response = nameProject.webApi.Auth.Utils.Response;

namespace nameProject.webApi.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        private readonly IConfiguration _configuration;
        //private readonly ILogger<AuthController> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> PostUser([FromBody] NewUser newUser)
        {
            var p = new ApplicationUser()
            {
                Email = newUser.Email,
                UserName = newUser.Username

            };

            var user = await this.userManager.CreateAsync(p, newUser.Password);

            return Ok(user);
        }

        [HttpPost]
        [Route("Auth")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var ut = await userManager.FindByNameAsync(login.Username);
            if (ut != null)
            {
                var pV = await userManager.CheckPasswordAsync(ut, login.Password);
                if (pV)
                {
                    var UserRoles = await userManager.GetRolesAsync(ut);

                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, ut.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                    foreach (var r in UserRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, r));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"));
                    var token = new JwtSecurityToken(
                            issuer: "http://localhost:5272",
                            audience: "http://localhost:5272",
                            expires: DateTime.Now.AddHours(1),
                            claims: authClaims,
                            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                            );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("registeradmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] NewUser model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRole.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
            if (!await roleManager.RoleExistsAsync(UserRole.User))
                await roleManager.CreateAsync(new IdentityRole(UserRole.User));

            if (await roleManager.RoleExistsAsync(UserRole.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRole.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}