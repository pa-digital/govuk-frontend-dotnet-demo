namespace GDSDemo.Controllers
{
    using GDSDemo.Models;
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.Infrastructure;
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class PretRebrandController : GDSController
    {
        public IActionResult Index()
        {
            var model = CreateDefaultRebrandModelViewModel();
            var validationScript = ClientSideValidationProvider.GenerateClientSideValidationScript(model);
            ViewBag.ValidationScript = validationScript;
            return View(model);
        }

        private PretRebrandModel CreateDefaultRebrandModelViewModel()
        {
            return new PretRebrandModel
            {
                FirstName = new InputViewModel
                {
                    Label = "First name",
                    QuestionType = InputMultiQuestionType.Multiple,
                },
                LastName = new InputViewModel
                {
                    Label = "Last name",
                    QuestionType = InputMultiQuestionType.Multiple,
                },
                PhoneNumber = new InputViewModel
                {
                    Label = "Phone number",
                    QuestionType = InputMultiQuestionType.Multiple,
                    InputType = InputType.Telephone
                },
                Email = new InputViewModel
                {
                    Label = "Email address:",
                    QuestionType = InputMultiQuestionType.Multiple,
                    InputType = InputType.Email
                },
                Password = new PasswordViewModel
                {
                    Label = "Password",
                    QuestionType = InputMultiQuestionType.Multiple,
                    Hint = "Please enter your password",
                },
                Location = new()
                {
                    Label = "Where do you live?",
                    QuestionType = InputMultiQuestionType.Multiple,
                    Options = new List<OptionModel>
                    {
                        new()
                        {
                            Text = "Choose location",
                            Value = ""
                        },new()
                        {
                            Text = "United Kingdom",
                            Value = "uk"
                        },new()
                        {
                            Text = "USA",
                            Value = "usa"
                        }
                    }
                },
                MarketingChoices = new CheckBoxListViewModel
                {
                    Legend = "If you want to receive marketing messages from us, including the latest Pret news, menu launches, new recipes and a whole lot of other good stuff, tell us how you'd like to be contacted. (Leave these boxes blank if you don't want to be contacted.)",
                    QuestionType = InputMultiQuestionType.Multiple,
                    Compact = true,
                    CheckBoxes = new List<CheckBoxViewModel>
                    {
                        new() { Text = "Email", Value = "email" },
                        new() { Text = "SMS", Value = "sms" }
                    }
                },
                SubmitButton = new ButtonViewModel
                {
                    Text = "Create account",
                    ButtonAction = ButtonAction.Submit
                },
                BackLink = new BackLinkViewModel
                {
                    Url = "/",
                    Text = "Back"
                }
            };
        }
    }
}
