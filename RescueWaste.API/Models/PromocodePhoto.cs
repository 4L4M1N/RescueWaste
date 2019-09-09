using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RescueWaste.API.Models
{
    public class PromocodePhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PromoCodeId { get; set; }
        public PromoCode PromoCode { get; set; }
        public string PublicId { get; set; }
    }
}