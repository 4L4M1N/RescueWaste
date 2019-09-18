using System;

namespace RescueWaste.API.DTOs
{
    public class PromocodeForListDTO
    {
        public int Id { get; set; }
        

        public string  Name { get; set; }
        
      
        public DateTime ExpireDate { get; set; }

        
        public double Discount { get; set; }
        public bool IsActive { get; set; }

        public string AreaManagerID { get; set; }

        public byte MerchantID { get; set; }

        public string PhotoUrl { get; set; }
    }
}