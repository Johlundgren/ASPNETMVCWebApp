using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCWebApp.ViewModels;

public class ContactRequestViewModel
{
    [Required(ErrorMessage = "A valid full name is required")]
    [DataType(DataType.Text)]
    [Display(Name = "Full name", Prompt = "Enter your full name")]
    public string FullName { get; set; } = null!;


    [Required(ErrorMessage = "A valid email is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    public string Email { get; set; } = null!;


    [Display(Name = "Service (Optional)", Prompt = "Choose the service you are intrested in")]
    public string? Service { get; set; }

    [Required(ErrorMessage = "You must enter a message")]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Message", Prompt = "Enter your message here...")]
    public string? Message { get; set; }
}
