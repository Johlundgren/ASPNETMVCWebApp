using ASPNETMVCWebApp.Models.Components;

namespace ASPNETMVCWebApp.Models.Sections;

public class AppDevicesViewModel
{
    public string? Id { get; set; }
    public ImageViewModel? Image { get; set; }
    public string Title { get; set; } = null!;
    public List<StoreRatingViewModel>? StoreRatings { get; set; }
    public List<AppAwardViewModel>? AppAwards { get; set; }
}

public class StoreRatingViewModel
{
    public string StoreName { get; set; } = null!;
    public List<IconViewModel>? Stars { get; set; }
}

public class AppAwardViewModel
{
    public string AwardTitle { get; set; } = null!;
    public string RatingInfo { get; set; } = null!;
    public ImageViewModel? StoreLogo { get; set; }
}
