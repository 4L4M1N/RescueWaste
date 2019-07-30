using System.ComponentModel.DataAnnotations;

namespace RescueWaste.API.DTOs
{
    public class UserForRegistrationDTO
    {
        //TODO: Use Regular Expresison to validate.
        [Required]
        public string  UserName { get; set; }
        [Required]
        //TODO: Email verification 
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }

    }
}