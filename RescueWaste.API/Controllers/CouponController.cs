using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueWaste.API.Data;
using RescueWaste.API.DTOs;
using RescueWaste.API.Models;

namespace RescueWaste.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly DataContext _context;
        public CouponController(DataContext context)
        {
            _context = context;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetMerchants()
        {
            var merchants = _context.Merchants.ToList();
            return Ok(merchants);
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create(PromoCodeDTO promoCodeDTO)
        {
            var couponToAdd = new PromoCode 
            {
                Name = promoCodeDTO.Name,
                ExpireDate = promoCodeDTO.ExpireDate,
                IsActive = true,
                MerchantID = promoCodeDTO.MerchantID
            };
             _context.PromoCodes.Add(couponToAdd);
            await _context.SaveChangesAsync();
            return Ok();
            
        }
    }
}