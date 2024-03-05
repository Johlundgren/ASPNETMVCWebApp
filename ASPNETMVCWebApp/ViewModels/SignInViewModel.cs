using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCWebApp.ViewModels;

public class SignInViewModel
{
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Your email address")]
    [Required(ErrorMessage = "An valid email address is required")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Your password")]
    [Required(ErrorMessage = "A valid password is required")]
    public string Password { get; set; } = null!;

    public bool RememberMe { get; set; }

}
