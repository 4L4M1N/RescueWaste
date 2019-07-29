using Microsoft.AspNetCore.Identity;

namespace RescueWaste.API.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}