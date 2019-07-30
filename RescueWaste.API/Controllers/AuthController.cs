using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
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
                Email = userForRegistrationDTO.UserName
                
            };
            if(await _userManager.FindByNameAsync(userForRegistrationDTO.UserName) != null)
                return BadRequest("User name already exists!");
            var createdUser = await _userManager.CreateAsync(userToCreate, userForRegistrationDTO.Password);
            if(createdUser.Succeeded)
            {
                if(userForRegistrationDTO.Role == "GeneralUser"){
                await _userManager.AddToRoleAsync(userToCreate,Role.GeneralUsr);
                }
                if(userForRegistrationDTO.Role == "AreaManager"){
                await _userManager.AddToRoleAsync(userToCreate,Role.AreaManagerUsr);
                }
                
            }
            //Create User
            return Ok(createdUser);
        }
    }
}