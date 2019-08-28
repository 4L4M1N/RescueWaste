using System.ComponentModel.DataAnnotations;

namespace RescueWaste.API.Models
{
    public class Merchant
    {
        public byte Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}