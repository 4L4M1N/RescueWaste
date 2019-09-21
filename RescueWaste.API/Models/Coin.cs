using System.ComponentModel.DataAnnotations;

namespace RescueWaste.API.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public AppUser Rescuer{ get; set; }

        [Required]
        public string RescuerId { get; set; }
        public int TotalCoins { get; set; }
    }
}