using ASPNETMVCWebApp.Models.Components;
using ASPNETMVCWebApp.Models.Sections;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace ASPNETMVCWebApp.Models.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Ultimate Task Management Assistant";

    #region Showcase
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
    #endregion

    #region Features
    public FeaturesViewModel Features { get; set; } = new FeaturesViewModel
    {
        Id = "features",
        Title = "What Do You Get with Our Tool?",
        Text = "Make sure all of your tasks are organized so you can set the priorities and focus on important.",
        Items =
        [
     new() {
                Icon = new IconViewModel { IconName = "fa-sharp fa-light fa-comments", IconText = "" },
                Title = "Comments on Tasks",
                Text = "Id mollis consectetur congue egestas egestas suspendisse blandit justo."
                },
     new() {
                Icon = new IconViewModel { IconName = "fa-regular fa-desktop", IconText = "" },
                Title = "Task Analytics",
                Text = "Non imperdiet facilisis nulla tellus Morbi scelerisque eget adipiscing vulputate."
            },
     new() {
                Icon = new IconViewModel { IconName = "fa-light fa-users-medical", IconText = "" },
                Title = "Multiple Assignees",
                Text = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris."
            },
     new() {
                Icon = new IconViewModel { IconName = "fa-regular fa-bell-on", IconText = "" },
                Title = "Notifications",
                Text = "Diam, suspendisse velit cras ac. Lobortis diam volutpat, eget pellentesque viverra."
            },
     new() {
                Icon = new IconViewModel { IconName = "fa-light fa-memo", IconText = "" },
                Title = "Sections & Subtasks",
                Text = "Mi feugiat hac id in. Sit elit placerat lacus nibh lorem ridiculus lectus."
            },
    new() {
                Icon = new IconViewModel { IconName = "fa-sharp fa-light fa-shield-check", IconText = "" },
                Title = "Data Security",
                Text = "Aliquam malesuada neque eget elit nulla vestibulum nunc cras."
            },

        ]

    };
    #endregion

    #region Dark & Light

    public LightDarkViewModel LightDark { get; set; } = new LightDarkViewModel
    {
        WhiteText = "Switch Between",
        BlackText = "Light & Dark Mode",
        Image = new ImageViewModel
        {
            ImageUrl ="images/light-dark.svg",
            AltText = "PC with Light & Dark mode"
        },
        Icon = new IconViewModel
        {
            IconName = "fa-sharp fa-light fa-right-left",
            IconText = ""
        }
    };

    #endregion

    #region Manage Your Work

    public ManageWorkViewModel ManageWork { get; set; } = new ManageWorkViewModel

    {
        Image = new ImageViewModel
        {
                ImageUrl = "images/dashboard-image.svg",
                AltText = "Picture of a Dashboard"
        },
        Title = "Manage Your Work",
        Icon = [
                new () { Icon = new IconViewModel { IconName = "fa-sharp fa-regular fa-circle-check", IconText = "Powerful project management"} },
                new () { Icon = new IconViewModel { IconName = "fa-sharp fa-regular fa-circle-check", IconText = "Transparent work management"} },
                new () { Icon = new IconViewModel { IconName = "fa-sharp fa-regular fa-circle-check", IconText = "Manage work & focus on the most important tasks"} },
                new () { Icon = new IconViewModel { IconName = "fa-sharp fa-regular fa-circle-check", IconText = "Track your progress with interactive charts"} },
                new () { Icon = new IconViewModel { IconName = "fa-sharp fa-regular fa-circle-check", IconText = "Easiest way to track time spent on tasks"} }
               ],
        Link = new LinkViewModel
        {
            ControllerName = "Default",
            ActionName = "LearnMore",
            Text = "Learn More"
        }
    };

    #endregion

    #region App Devices

    public AppDevicesViewModel AppDevices { get; set; } = new AppDevicesViewModel
    {
        Image = new ImageViewModel
        {
            ImageUrl = "/images/mobile-screens.svg",
            AltText = "Picture of two cellphones"
        },
        Title = "Download Our App for Any Devices:",
        StoreRatings =
        [
            new() {
                StoreName = "App Store",
                Stars = Enumerable.Repeat(new IconViewModel { IconName = "fa-sharp fa-solid fa-star" }, 5).ToList()
            },
            new() {
                StoreName = "Google Play",
                Stars = Enumerable.Repeat(new IconViewModel { IconName = "fa-sharp fa-solid fa-star" }, 5).ToList()
            }
        ],
        AppAwards =
        [
            new() {
                AwardTitle = "Editor's Choice",
                RatingInfo = "rating 4.7, 187k+ reviews",
                StoreLogo = new ImageViewModel
                {
                    ImageUrl = "images/appstore.svg",
                    AltText = "Picture of Appstore Logo"
                }
            },
            new() {
                AwardTitle = "App of the Day",
                RatingInfo = "rating 4.8, 30k+ reviews",
                StoreLogo = new ImageViewModel
                {
                    ImageUrl = "images/googleplay.svg",
                    AltText = "Picture of Googleplay"
                }
            }
        ]
    };

    #endregion

    #region Work Tools
    public WorkToolsViewModel WorkTools { get; set; } = new WorkToolsViewModel
    {
        Title = "Integrate Top Work Tools",
        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin volutpat mollis egestas. Nam luctus facilisis ultrices. Pellentesque volutpat ligula est. Mattis fermentum, at nec lacus.",
        ToolItems =
        [
            new ToolItemViewModel { Image = new ImageViewModel { ImageUrl = "images/logos/google.svg", AltText = "image of google" }, Description = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis." },
            new ToolItemViewModel { Image = new ImageViewModel { ImageUrl = "images/logos/zoom.svg", AltText = "image of zoom" }, Description = "In eget a mauris quis. Tortor dui tempus quis integer est sit natoque placerat dolor." },
            new ToolItemViewModel { Image = new ImageViewModel { ImageUrl = "images/logos/slack.svg", AltText = "image of slack" }, Description = "Id mollis consectetur congue egestas egestas suspendisse blandit justo." },
            new ToolItemViewModel { Image = new ImageViewModel { ImageUrl = "images/logos/gmail.svg", AltText = "image of gmail" }, Description = "Rutrum interdum tortor, sed at nulla. A cursus bibendum elit purus cras praesent." },
            new ToolItemViewModel { Image = new ImageViewModel { ImageUrl = "images/logos/trello.svg", AltText = "image of trello" }, Description = "Congue pellentesque amet, viverra curabitur quam diam scelerisque fermentum urna." },
            new ToolItemViewModel { Image = new ImageViewModel { ImageUrl = "images/logos/mailchimp.svg", AltText = "image of mailchimp" }, Description = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris." },
            new ToolItemViewModel { Image = new ImageViewModel { ImageUrl = "images/logos/dropbox.svg", AltText = "image of dropbox" }, Description = "Ut in turpis consequat odio diam lectus elementum. Est faucibus blandit platea." },
            new ToolItemViewModel { Image = new ImageViewModel { ImageUrl = "images/logos/evernote.svg", AltText = "image of evernote" }, Description = "Faucibus cursus maecenas lorem cursus nibh. Sociis sit risus id. Sit facilisis dolor arcu." },

        ]
    };

    #endregion

    #region Subscribe Section

    public SubscribeViewModel Subscribe { get; set; } = new SubscribeViewModel()
    {
        Title = "Don't Want To Miss Anything?",
        Image = new ImageViewModel
        {
            ImageUrl = "images/vectorgroup.svg",
            AltText = "Squiggly line"
        },
        NewsletterHeadline = "Sign up for Newsletters",
        NewsletterOptions = new List<NewsletterOptionViewModel>
        {
            new NewsletterOptionViewModel { Text = "Daily Newsletter", IsChecked = false },
            new NewsletterOptionViewModel { Text = "Advertising Updates", IsChecked = false },
            new NewsletterOptionViewModel { Text = "Week in Review", IsChecked = false },
            new NewsletterOptionViewModel { Text = "Event Updates", IsChecked = false },
            new NewsletterOptionViewModel { Text = "Startups Weekly", IsChecked = false },
            new NewsletterOptionViewModel { Text = "Podcasts", IsChecked = false },
        },
        EmailPlaceholder = "Your Email",
        Button = new LinkViewModel
        {
            ControllerName = "Default",
            ActionName = "Subscribe",
            Text = "Subscribe *"
        },
        TermsText = "* Yes, I agree to the terms and privacy policy",
        TermsLink = new LinkViewModel { ControllerName = "Default", ActionName = "Terms", Text = "terms" },
        PrivacyLink = new LinkViewModel { ControllerName = "Default", ActionName = "Privacy", Text = "privacy" }
    };

    #endregion
}
