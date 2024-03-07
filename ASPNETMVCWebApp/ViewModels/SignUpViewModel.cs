using ASPNETMVCWebApp.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCWebApp.ViewModels;

public class SignUpViewModel
{
    [DataType(DataType.Text)]
    [Display(Name ="First name", Prompt = "Your first name")]
    [Required(ErrorMessage = "A valid first name is required")]
    public string FirstName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Your last name")]
    [Required(ErrorMessage = "A valid last name is required")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Your email address")]
    [Required(ErrorMessage = "An valid email address is required")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Your email address is invalid")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Your password")]
    [Required(ErrorMessage = "A valid password is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Invalid password, must be a strong password")]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(Password), ErrorMessage = "Password must be confirmed")]
    public string ConfirmPassword { get; set; } = null!;



    [RequiredCheckbox(ErrorMessage = "Terms and coniditons must be accepted")]
    public bool TermsAndConditions { get; set; }
}
