using System.ComponentModel.DataAnnotations;

namespace ShopTARge22.Models.Accounts
{
    public class AddPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage ="The new password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
