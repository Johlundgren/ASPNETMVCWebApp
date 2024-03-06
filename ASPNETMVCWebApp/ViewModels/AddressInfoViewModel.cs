using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCWebApp.ViewModels;

public class AddressInfoViewModel
{
    [Required(ErrorMessage = "A valid address is required")]
    [DataType(DataType.Text)]
    [Display(Name = "Address line 1", Prompt = "Enter your first address")]
    public string AddressLine_1 { get; set; } = null!;


    [DataType(DataType.Text)]
    [Display(Name = "Address line 2 (optional)", Prompt = "Enter your second address")]
    public string? AddressLine_2 { get; set; }


    [Required(ErrorMessage = "A valid postal code is required")]
    [DataType(DataType.Text)]
    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    public string PostalCode { get; set; } = null!;


    [Required(ErrorMessage = "A valid city is required")]
    [DataType(DataType.Text)]
    [Display(Name = "City", Prompt = "Enter your city")]
    public string City { get; set; } = null!;
}
