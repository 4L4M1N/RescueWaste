using Microsoft.AspNetCore.Http;

namespace RescueWaste.API.DTOs
{
    public class photoUploadPromoCodeDTO
    {
         public string Url { get; set; }
        public IFormFile File { get; set; }
        public string PublicId { get; set; }
        
    }
}