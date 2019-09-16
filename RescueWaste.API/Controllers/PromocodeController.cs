using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RescueWaste.API.Data;
using RescueWaste.API.DTOs;
using RescueWaste.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RescueWaste.API.Helpers;
using CloudinaryDotNet;
using System.Security.Claims;
using CloudinaryDotNet.Actions;
using System.Text;
using System;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace RescueWaste.API.Controllers
{
    
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PromocodeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PromocodeController(DataContext context, 
                UserManager<AppUser> userManager, 
                IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _context = context;
            _userManager = userManager;
            _cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }



        [AllowAnonymous]
        [HttpGet("merchants")]
        public ActionResult Merchants()
        {
            var merchants = _context.Merchants.ToList();
            return Ok(merchants);
        }
        
        // [HttpPost("create")]
        // public async Task<IActionResult> Create(PromoCode promoCode)
        // {
           
        //     var couponToAdd = new PromoCode 
        //     {
        //         AreaManagerID = promoCode.AreaManagerID,
        //         Name = promoCode.Name,
        //         ExpireDate = promoCode.ExpireDate,
        //         IsActive = true,
        //         MerchantID = promoCode.MerchantID
        //     };
        //      _context.PromoCodes.Add(couponToAdd);
        //     await _context.SaveChangesAsync();
        //     return Ok();
            
        // }
        [HttpPost("create")]
        
        public async Task<IActionResult> Create([FromForm] PromoCodeDTO promoCode)
        {
            // if(userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
            // {
            //     return Unauthorized();
            // }
            if(promoCode == null)
            {
                return Ok(promoCode);
            }
            var file = Request.Form.Files[0];
            var uploadResult = new ImageUploadResult();
          
            if(file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(300).Height(300).Crop("fill")
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            // var image = new PromocodePhoto
            // {
            //     Url = promoCode.Url,
            //     PublicId = promoCode.PublicId,
            //     PromoCodeId
            // }
           
            promoCode.Url = uploadResult.Uri.ToString();
            promoCode.PublicId = uploadResult.PublicId;

             //promoCode.AreaManagerID = "227cb93a-5154-4caa-b93d-a6431dd29e5e";
            // string one = "1";
            // promoCode.Name = "ABCC";

            // promoCode.MerchantID = Convert.ToByte(one);
            var promocodeToAdd = new PromoCode 
            {
                AreaManagerID = promoCode.AreaManagerID,
                Name = promoCode.Name,
                ExpireDate = DateTime.Now,
                IsActive = true,
                MerchantID = promoCode.MerchantID

            };
            _context.PromoCodes.Add(promocodeToAdd);
            await _context.SaveChangesAsync();

            //For Photo

            var image = new PromocodePhoto
            {
                Url = promoCode.Url,
                PublicId = promoCode.PublicId,
                PromoCodeId = promocodeToAdd.Id
            };

            _context.PromocodePhotos.Add(image);
            if(await _context.SaveChangesAsync() > 0)
            {
                var photoToReturn = image;
                
                return Ok(photoToReturn);
            }
            return BadRequest();

        }
    }
}