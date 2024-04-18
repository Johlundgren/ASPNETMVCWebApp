using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCWebApp.ViewModels;

public class SecurityViewModel
{
    [DataType(DataType.Password)]
    [Display(Name = "Current Password", Prompt = "Your current password")]
    [Required(ErrorMessage = "Wrong password")]
    public string CurrentPassword { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "New Password", Prompt = "Enter your new password")]
    [Required(ErrorMessage = "A valid password is required")]
    public string NewPassword { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password", Prompt = "Confirm your new password")]
    [Required(ErrorMessage = "Password doesn't match")]
    public string ConfirmNewPassword { get; set; } = null!;

    public ProfileInfoViewModel? ProfileInfo { get; set; }
}