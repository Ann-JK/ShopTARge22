using System.ComponentModel.DataAnnotations;

namespace ShopTARge22.Models.Accounts
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
