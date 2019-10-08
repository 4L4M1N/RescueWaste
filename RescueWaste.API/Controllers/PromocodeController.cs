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
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RescueWaste.API.Repositories;
using System.IO;

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
        private readonly IMapper _mapper;
        private Cloudinary _cloudinary;
        private readonly IPromocodeRepository _repo;

        public PromocodeController(DataContext context, 
                UserManager<AppUser> userManager, 
                IOptions<CloudinarySettings> cloudinaryConfig,
                IMapper mapper,
                IPromocodeRepository repo)
        {
            _context = context;
            _userManager = userManager;
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
            _repo = repo;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<IActionResult> GetPromocodes([FromQuery]PromocodeParams promocodeParams)
        {
            var promocodes = await _repo.GetPromocodes(promocodeParams);
            var promocodesToReturn = _mapper.Map<IEnumerable<PromocodeForListDTO>>(promocodes);
            Response.AddPagination(promocodes.CurrentPage, promocodes.PageSize,
                                    promocodes.TotalCount, promocodes.TotalPages);
              
            return Ok(promocodesToReturn);
            
        }


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
            var file = Request.Form.Files[0];
            // string fileName = file.Name;
            // string extension = Path.GetExtension(fileName);
            if(Extentions.CheckImageFileExtention(file) == false) {
                return BadRequest("File format not supported");
            }
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

            var promocodeToAdd = new PromoCode 
            {
                AreaManagerID = promoCode.AreaManagerID,
                Name = promoCode.Name,
                ExpireDate = DateTime.Now,
                IsActive = true,
                MerchantID = promoCode.MerchantID,
                Discount = promoCode.Discount,
                CoinsRequired = promoCode.CoinsRequired
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