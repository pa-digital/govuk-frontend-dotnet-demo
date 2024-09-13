namespace GDSDemo.Controllers
{
    using GDSDemo.Models;
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.Infrastructure;
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc;

    public class NIHRRebrandController : GDSController
    {
        public IActionResult Index()
        {
            var model = CreateDefaultRebrandModelViewModel();
            var validationScript = ClientSideValidationProvider.GenerateClientSideValidationScript(model);
            ViewBag.ValidationScript = validationScript;
            return View(model);
        }

        private NIHRRebrandViewModel CreateDefaultRebrandModelViewModel()
        {
            return new NIHRRebrandViewModel
            {
                Name = new InputViewModel
                {
                    Label = "Enter name:",
                    QuestionType = InputMultiQuestionType.Multiple,
                    InputType = InputType.Text,
                    Hint = "Please enter your full name",
                    Value = "",
                    Error = ""
                },
                Email = new InputViewModel
                {
                    Label = "Enter email address:",
                    QuestionType = InputMultiQuestionType.Multiple,
                    InputType = InputType.Email,
                    Value = "",
                    Error = ""
                },
                Password = new PasswordViewModel
                {
                    Label = "Enter password:",
                    QuestionType = InputMultiQuestionType.Multiple,
                    Hint = "Please enter your password",
                },
                CountryOfResidence = new RadioButtonListViewModel
                {
                    Legend = "Where do you live:",
                    QuestionType = InputMultiQuestionType.Multiple,
                    Error = "",
                    Compact = false,
                    RadioButtons = new List<RadioButtonViewModel>
                    {
                        new() { Text = "England", Value = "England", Hint = "Includes all islands" },
                        new() { Text = "Ireland", Value = "Ireland" },
                        new() { Text = "Scotland", Value = "Scotland", Hint = "Includes hebredies" },
                        new() { Text = "Wales", Value = "Wales" }
                    }
                },
                Interests = new CheckBoxListViewModel
                {
                    Legend = "Select interests:",
                    QuestionType = InputMultiQuestionType.Multiple,
                    Hint = "Please select one or more options",
                    Error = "",
                    Compact = false,
                    CheckBoxes = new List<CheckBoxViewModel>
                    {
                        new() { Text = "Option 1", Value = "One" },
                        new() { Text = "Option 2", Value = "Two" },
                        new() { Text = "Option 3", Value = "Three" },
                        new() { Text = "Option 4", Value = "Four" }
                    }
                },
                SubmitButton = new ButtonViewModel
                {
                    Text = "Save and continue",
                    ButtonType = ButtonType.Default,
                    ButtonAction = ButtonAction.Submit
                },
                BackLink = new BackLinkViewModel
                {
                    Text = "Back",
                    Url = "/"
                },
                Breadcrumbs = new BreadcrumbsViewModel
                {
                    Label = "Breadcrumbs",
                    Links = new List<BaseUrlModel>
                    {
                        new()
                        {
                            Url = "#",
                            Text = "Home"
                        },
                        new()
                        {
                            Url = "#",
                            Text = "Passports, travel and living abroad"
                        },
                        new()
                        {
                            Url = "#",
                            Text = "Travel abroad"
                        }
                    }
                },
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
                DetailsView = new DetailsViewModel
                {
                    Header = "Help with nationality",
                    ContentHtml = new HtmlString("We need to know your nationality so we can work out which elections you’re entitled to vote in. If you cannot provide your nationality, you’ll have to send copies of identity documents through the post.")
                },
                InsetText = new InsetTextViewModel
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
                Panel = new PanelViewModel
                {
                    Header = new HtmlString("Application complete"),
                    Content = new HtmlString("Your reference number<br><strong>HDJ2123F</strong>")
                },
                Warning = new WarningViewModel
                {
                    Content = new HtmlString("You can be fined up to £5,000 if you do not register.")
                },
            };
        }
    }
}
