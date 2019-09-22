using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using RescueWaste.API.Models;

namespace RescueWaste.API.DTOs
{
    public class PromoCodeDTO
    {
       //TODO: Required attribute need to add 
        public string  Name { get; set; }
        
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
    
        public byte MerchantID { get; set; }
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string PublicId { get; set; }
        public string AreaManagerID { get; set; }
        public double Discount { get; set; }
        public int CoinsRequired { get; set; }
        
    }
}