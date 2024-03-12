using ASPNETMVCWebApp.Models.Components;

namespace ASPNETMVCWebApp.Models.Sections;

public class WorkToolsViewModel
{
    public string? Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<ToolItemViewModel>? ToolItems { get; set; }
}

public class ToolItemViewModel
{
    public ImageViewModel? Image { get; set; }
    public string Description { get; set; } = null!;
}
