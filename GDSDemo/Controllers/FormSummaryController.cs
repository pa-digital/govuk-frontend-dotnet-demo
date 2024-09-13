namespace GDSDemo.Controllers
{
    using GDSDemo.Models;
    using GDSDemo.RequestModels;
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.Infrastructure;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class FormSummaryController : GDSController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = CreateDefaultUserFormErrorSummaryViewModel();
            var validationScript = ClientSideValidationProvider.GenerateClientSideValidationScript(model);
            ViewBag.ValidationScript = validationScript;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserFormErrorSummaryViewModel model)
        {
            var refModel = CreateDefaultUserFormErrorSummaryViewModel();
            model.Name = InputViewModelExtension.PopulateInputViewModel(model.Name, refModel.Name);
            model.Email = InputViewModelExtension.PopulateInputViewModel(model.Email, refModel.Email);
            model.Interests = CheckBoxListViewModelExtension.PopulateCheckBoxListViewModel(model.Interests, refModel.Interests);
            model.CountryOfResidence = RadioButtonListViewModelExtension.PopulateRadioButtonListViewModel(model.CountryOfResidence, refModel.CountryOfResidence);
            model.SubmitButton = refModel.SubmitButton;
            model.BackLink = refModel.BackLink;

            ValidateModel(model);
            if (ModelState.IsValid)
            {
                var postedForm = new UserFormDataRequestModel
                {
                    Name = model.Name.GetValue(),
                    Email = model.Email.GetValue(),
                    CountryOfResidence = model.CountryOfResidence.GetDisplayValue(),
                    Interests = model.Interests.GetDisplayValues()
                };

                var serializedForm = JsonConvert.SerializeObject(postedForm);
                TempData["PostedData"] = serializedForm;

                return RedirectToAction("Success");
            } else
            {
                model.ErrorSummary = new ErrorSummaryViewModel
                {
                    Title = "There is a problem",
                    Errors = MapErrors<UserFormErrorSummaryViewModel>()
                };                
            }

            return View(model);

        }

        public ActionResult Success()
        {
            var serializedForm = TempData["PostedData"] as string;
            var model = JsonConvert.DeserializeObject<UserFormDataRequestModel>(serializedForm);
            return View(model);
        }


        private UserFormErrorSummaryViewModel CreateDefaultUserFormErrorSummaryViewModel()
        {
            return new UserFormErrorSummaryViewModel
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
                }
            };
        }
    }
}
