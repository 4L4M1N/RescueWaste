using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueWaste.API.Data;
using RescueWaste.API.DTOs;
using RescueWaste.API.Models;
using Microsoft.AspNetCore.Identity;

namespace RescueWaste.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PromocodeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        public PromocodeController(DataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetMerchants()
        {
            var merchants = _context.Merchants.ToList();
            return Ok(merchants);
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create(PromoCode promoCode)
        {
           
            var couponToAdd = new PromoCode 
            {
                AreaManagerID = promoCode.AreaManagerID,
                Name = promoCode.Name,
                ExpireDate = promoCode.ExpireDate,
                IsActive = true,
                MerchantID = promoCode.MerchantID
            };
             _context.PromoCodes.Add(couponToAdd);
            await _context.SaveChangesAsync();
            return Ok();
            
        }
    }
}