using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RescueWaste.API.Models;

namespace RescueWaste.API.DTOs
{
    public class PromoCodeDTO
    {
       //TODO: Required attribute need to add 
        [Required]
        public string  Name { get; set; }
        
        [Required]
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
    
        public byte MerchantID { get; set; }
        public string Url { get; set; }
        [Required]
        public IFormFile File { get; set; }
        public string PublicId { get; set; }
        public string AreaManagerID { get; set; }
        
        [Required]
        public double Discount { get; set; }
        
        [Required]
        public int CoinsRequired { get; set; }
        
    }
}