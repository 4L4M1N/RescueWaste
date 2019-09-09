using System;
using System.ComponentModel.DataAnnotations;

namespace RescueWaste.API.Models
{
    public class PromoCode
    {
        public int Id { get; set; }
        
        [Required]
        public string  Name { get; set; }
        
      
        public DateTime ExpireDate { get; set; }

        
        public double Discount { get; set; }
        public bool IsActive { get; set; }

        public AppUser AreaManager { get; set; }

        [Required]
        public string AreaManagerID { get; set; }
        public Merchant Merchant { get; set; }
        
        [Required]
        public byte MerchantID { get; set; }

        public PromocodePhoto PromocodePhoto { get; set; }
 
    }
}