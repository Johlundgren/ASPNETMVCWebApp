using ASPNETMVCWebApp.Models.Components;

namespace ASPNETMVCWebApp.Models.Sections;

public class ManageWorkViewModel
{
    public string? Id { get; set; }
    public ImageViewModel? Image { get; set; }
    public string? Title { get; set; }
    public List<ManageWorkItemsViewModel>? Icon { get; set; }
    public LinkViewModel? Link { get; set; }
}
public class ManageWorkItemsViewModel
{
    public IconViewModel? Icon { get; set; } = new IconViewModel();
}