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

    public class RegistrationController : GDSController
    {
        public IActionResult Index()
        {
            var model = CreateDefaultRegistrationViewModel();
            var validationScript = ClientSideValidationProvider.GenerateClientSideValidationScript(model);
            ViewBag.ValidationScript = validationScript;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(RegistrationViewModel model)
        {
            var refModel = CreateDefaultRegistrationViewModel();
            model.Email = InputViewModelExtension.PopulateInputViewModel(model.Email, refModel.Email);
            model.Password = PasswordViewModelExtenstion.PopulatePasswordViewModel(model.Password, refModel.Password);
            model.SubmitButton = refModel.SubmitButton;
            model.BackLink = refModel.BackLink;

            ValidateModel(model);
            if (ModelState.IsValid)
            {
                var postedForm = new RegistrationRequestModel
                {
                    Email = model.Email.GetValue(),
                    Password = model.Password.GetValue(),
                };

                var serializedForm = JsonConvert.SerializeObject(postedForm);
                TempData["PostedData"] = serializedForm;

                return RedirectToAction("Success");
            }
            else
            {
                model.ErrorSummary = new ErrorSummaryViewModel
                {
                    Title = "There is a problem",
                    Errors = MapErrors<RegistrationViewModel>()
                };
            }

            return View(model);

        }

        public ActionResult Success()
        {
            var serializedForm = TempData["PostedData"] as string;
            var model = JsonConvert.DeserializeObject<RegistrationRequestModel>(serializedForm);
            return View(model);
        }

        private RegistrationViewModel CreateDefaultRegistrationViewModel()
        {
            return new RegistrationViewModel
            {
                Email = new InputViewModel
                {
                    Label = "Enter email address:",
                    QuestionType = InputMultiQuestionType.Multiple,
                    InputType = InputType.Email,
                },
                Password = new PasswordViewModel
                {
                    Label = "Enter password:",
                    QuestionType = InputMultiQuestionType.Multiple,
                    Hint = "Please enter your password",
                },
                SubmitButton = new ButtonViewModel
                {
                    Text = "Register",
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
