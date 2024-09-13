namespace GDSDemo.Controllers
{
    using GDSDemo.Models;
    using GDS.Components.Enum;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc;

    public class ComponentsController : Controller
    {
        public IActionResult Index()
        {
            var model = CreateComponentsViewModel();
            return View(model);
        }

        private ComponentsViewModel CreateComponentsViewModel()
        {
            return new ComponentsViewModel
            {
                Buttons = new List<ButtonViewModel>
                {
                    new() {
                        Text = "Save and continue",
                        ButtonAction = ButtonAction.Submit
                    },
                    new() {
                        Text = "Find address",
                        ButtonType = ButtonType.Secondary,
                        ButtonAction = ButtonAction.Button
                    },
                    new() {
                        Text = "Delete account",
                        ButtonType = ButtonType.Warning,
                        ButtonAction = ButtonAction.Button
                    }
                },
                DetailsView = new()
                {
                    Header = "Help with nationality",
                    ContentHtml = new HtmlString("We need to know your nationality so we can work out which elections you’re entitled to vote in. If you cannot provide your nationality, you’ll have to send copies of identity documents through the post.")
                },
                InsetText = new()
                {
                    Content = new HtmlString("It can take up to 8 weeks to register a lasting power of attorney if there are no mistakes in the application.")
                },
                Tags = new List<TagViewModel>
                {
                    new() {
                        TagType = TagType.Default,
                        Text = "Default"
                    },
                    new() {
                        TagType = TagType.Grey,
                        Text = "Inactive"
                    }, new() {
                        TagType = TagType.Green,
                        Text = "New"
                    },
                    new() {
                        TagType = TagType.Turquoise,
                        Text = "Active"
                    },
                    new() {
                        TagType = TagType.Blue,
                        Text = "Pending"
                    },
                    new() {
                        TagType = TagType.LightBlue,
                        Text = "In progress"
                    },
                    new() {
                        TagType = TagType.Purple,
                        Text = "Received"
                    },
                    new() {
                        TagType = TagType.Pink,
                        Text = "Sent"
                    },
                    new() {
                        TagType = TagType.Red,
                        Text = "Rejected"
                    },
                    new() {
                        TagType = TagType.Orange,
                        Text = "Declined"
                    }, new() {
                        TagType = TagType.Yellow,
                        Text = "Delayed"
                    }
                },
                Panel = new()
                {
                    Header = new HtmlString("Application complete"),
                    Content = new HtmlString("Your reference number<br><strong>HDJ2123F</strong>")
                },
                Warning = new()
                {
                    Content = new HtmlString("You can be fined up to £5,000 if you do not register.")
                },
                PhaseBanner = new()
                {
                    Phase = "Alpha",
                    BannerContent = new()
                    {
                        ContextText = new HtmlString("This is a new service. Help us improve it and"),
                        Url = "#",
                        Text = "give your feedback by email"
                    }
                },
                AlertBanner = new()
                {
                    Header = "Important",
                    PreLinkContent = new HtmlString("You have 7 days left to send your application."),
                    Link = new()
                    {
                        Text = "View application",
                        Url = "#"
                    }
                },
                SuccessBanner = new()
                {
                    Outcome = NotificationOutcomeType.Success,
                    Header = "Success",
                    SubHeader = "Training outcome recorded and trainee withdrawn",
                    PreLinkContent = new HtmlString("Contact"),
                    Link = new() { 
                        Text = "example@department.gov.uk",
                        Url = "#",
                    },
                    PostLinkContent = new HtmlString("if you think there is a problem."),
                },
                BackLink = new()
                {
                    Text = "Back",
                    Url = "/"
                }
            };
        }
    }
}
