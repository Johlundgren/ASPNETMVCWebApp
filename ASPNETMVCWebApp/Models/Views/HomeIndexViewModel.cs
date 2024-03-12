using ASPNETMVCWebApp.Models.Sections;

namespace ASPNETMVCWebApp.Models.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Ultimate Task Management Assistant";
    public ShowcaseViewModel Showcase { get; set; } = new ShowcaseViewModel
    {
        Id = "overview",
        ShowcaseImage = new() { ImageUrl = "/images/showcase-image.svg", AltText = "Task Management Assistant" },
        Title = "Task Management Assistant You Gonna Love",
        Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
        Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Get started for free" },
        BrandsText = "Largest companies use our tool to work efficiently",
        Brands =
                [
                    new() { ImageUrl = "/images/brands/brand_1.svg", AltText = "Brand Name 1" },
                    new() { ImageUrl = "/images/brands/brand_2.svg", AltText = "Brand Name 2" },
                    new() { ImageUrl = "/images/brands/brand_3.svg", AltText = "Brand Name 3" },
                    new() { ImageUrl = "/images/brands/brand_4.svg", AltText = "Brand Name 4" },
                ],

    };
}
