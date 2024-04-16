using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCWebApp.ViewModels;

public class ContactRequestViewModel
{
    [Required(ErrorMessage = "A valid first name is required")]
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string FullName { get; set; } = null!;


    [Required(ErrorMessage = "A valid email is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    public string Email { get; set; } = null!;

    [DataType(DataType.MultilineText)]
    [Display(Name = "Message", Prompt = "Enter your message here...")]
    public string? Message { get; set; }
}
