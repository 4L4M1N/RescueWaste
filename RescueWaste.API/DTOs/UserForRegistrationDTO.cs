using System.ComponentModel.DataAnnotations;

namespace RescueWaste.API.DTOs
{
    public class UserForRegistrationDTO
    {
        //TODO: Use Regular Expresison to validate.
        [Required]
        public string Name { get; set; }

        [Required]
        public string  UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        //TODO: Email verification 
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }

    }
}