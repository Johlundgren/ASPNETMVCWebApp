using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCWebApp.ViewModels;

public class AccountDetailsViewModel
{
    public ProfileInfoViewModel? ProfileInfo { get; set; }
    public BasicInfoViewModel? BasicInfo { get; set; }
    public AddressInfoViewModel? AddressInfo { get; set; }
}
