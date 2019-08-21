using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RescueWaste.API.DTOs;
using RescueWaste.API.Models;

namespace RescueWaste.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;

        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _config = config;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegistrationDTO userForRegistrationDTO)
        {
            if(!await _roleManager.RoleExistsAsync(Role.AdminUsr))
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.AdminUsr));
            }
            if(!await _roleManager.RoleExistsAsync(Role.AreaManagerUsr))
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.AreaManagerUsr));
            }
            if(!await _roleManager.RoleExistsAsync(Role.GeneralUsr))
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.GeneralUsr));
            }                        

            var userToCreate = new AppUser
            {
                UserName = userForRegistrationDTO.UserName,
                Email = userForRegistrationDTO.UserName,
                Name = userForRegistrationDTO.Name
                
            };
            if(await _userManager.FindByNameAsync(userForRegistrationDTO.UserName) != null)
                return BadRequest("User name already exists!");
            var createdUser = await _userManager.CreateAsync(userToCreate, userForRegistrationDTO.Password);
            if(createdUser.Succeeded)
            {
                if(userForRegistrationDTO.Role == "Rescuer"){
                await _userManager.AddToRoleAsync(userToCreate,Role.GeneralUsr);
                }
                if(userForRegistrationDTO.Role == "Manager"){
                await _userManager.AddToRoleAsync(userToCreate,Role.AreaManagerUsr);
                }
                return Ok(createdUser);
            }
            //Create User
            return BadRequest(createdUser.Errors);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO userForLoginDTO)
        {
            // throw new Exception("noooooo");
            var user = await _userManager.FindByNameAsync(userForLoginDTO.UserName);
            if(user == null)
                return Unauthorized(); 

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, userForLoginDTO.Password, false); //Please use better option
            if(result.Succeeded){
            var role = await _userManager.GetRolesAsync(user);
            string roleAssigned = role[0];
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, roleAssigned)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value)); //Set Secret value
            
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            
            //insert information to token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
            }
            return Unauthorized();
            
        }
    }
}