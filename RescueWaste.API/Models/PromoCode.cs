using System;

namespace RescueWaste.API.Models
{
    public class PromoCode
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
        public Merchant Merchant { get; set; }
        public byte MerchantId { get; set; }
    }
}