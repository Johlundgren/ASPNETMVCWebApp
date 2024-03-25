using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCWebApp.Models.Sections;

public class SubscribeViewModel
{
    [Required]
    [Display(Name = "Email", Prompt = "Your Email")]
    public string Email { get; set; } = null!;


    [Display(Name = "Daily Newsletter")]
    public bool DailyNewsletter { get; set; }

    [Display(Name = "Advertising Updates")]
    public bool AdvertisingUpdates { get; set; }

    [Display(Name = "Week in Review")]
    public bool WeekInReview { get; set; }

    [Display(Name = "Event Updates")]
    public bool EventUpdates { get; set; }

    [Display(Name = "Startups Weekly")]
    public bool StartupsWeekly { get; set; }

    [Display(Name = "Podcasts")]
    public bool Podcasts { get; set; }
}
