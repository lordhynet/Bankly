using System.ComponentModel.DataAnnotations;

namespace BANKLYFINANCIALAPP.Entities.Dto
{
    public class LoginDto
    {
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string EmailAddress { get; set; }
        public string Password { get; set; }


    }
}
