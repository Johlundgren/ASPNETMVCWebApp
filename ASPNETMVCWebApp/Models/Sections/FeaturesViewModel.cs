using ASPNETMVCWebApp.Models.Components;

namespace ASPNETMVCWebApp.Models.Sections;

public class FeaturesViewModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public List<FeaturesItemViewModel>? Items { get; set; }
}

public class FeaturesItemViewModel
{
    public IconViewModel Icon { get; set; } = new IconViewModel();
    public string? Title { get; set; }
    public string? Text { get; set; }
}
