using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RescueWaste.API.Models;

namespace RescueWaste.API.DTOs
{
    public class PromoCodeDTO
    {
        public string  Name { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
    
        public byte MerchantID { get; set; }
        
    }
}