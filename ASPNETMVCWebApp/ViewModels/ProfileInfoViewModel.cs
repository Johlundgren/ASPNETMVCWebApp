namespace ASPNETMVCWebApp.ViewModels;

public class ProfileInfoViewModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string ProfileImageUrl { get; set; } = "john-doe.svg";
}
