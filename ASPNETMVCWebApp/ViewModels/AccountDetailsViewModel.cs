using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCWebApp.ViewModels;

public class AccountDetailsViewModel
{
    public ProfileInfoViewModel ProfileInfo { get; set; } = null!;
    public BasicInfoViewModel BasicInfo { get; set; } = null!;
    public AddressInfoViewModel AddressInfo { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
}
