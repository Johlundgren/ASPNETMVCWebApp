using ASPNETMVCWebApp.Models.Components;

namespace ASPNETMVCWebApp.Models.Sections;

public class LightDarkViewModel
{
    public string? Id { get; set; }
    public string? WhiteText { get; set; }
    public string? BlackText { get; set; }
    public ImageViewModel? Image { get; set; }
    public IconViewModel? Icon { get; set; }
}
