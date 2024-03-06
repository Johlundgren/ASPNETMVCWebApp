using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCWebApp.ViewModels;

public class BasicInfoViewModel
{
    public string UserId { get; set; } = null!;


    [Required(ErrorMessage = "A valid first name is required")]
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;


    [Required(ErrorMessage = "A valid last name is required")]
    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    public string LastName { get; set;} = null!;


    [Required(ErrorMessage = "A valid email is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    public string Email { get; set; } = null!;


    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone (optional)", Prompt = "Enter your phone number")]
    public string? Phone { get; set; }


    [DataType(DataType.MultilineText)]
    [Display(Name = "Bio (optional)", Prompt = "Add a short bio...")]
    public string? Bio { get; set; }
}
