using ASPNETMVCWebApp.Models.Components;

namespace ASPNETMVCWebApp.Models.Sections;

public class SubscribeViewModel
{
    public string? Id { get; set; }
    public string Title { get; set; } = null!;
    public ImageViewModel? Image { get; set; }
    public string? NewsletterHeadline { get; set; }
    public List<NewsletterOptionViewModel>? NewsletterOptions { get; set; }
    public string EmailPlaceholder { get; set; } = null!;
    public LinkViewModel? Button { get; set; }
    public string? TermsText { get; set; }
    public LinkViewModel? TermsLink { get; set; }
    public LinkViewModel? PrivacyLink { get; set; }
}

public class NewsletterOptionViewModel
{
    public string? Text { get; set; }
    public bool IsChecked { get; set; }
}
