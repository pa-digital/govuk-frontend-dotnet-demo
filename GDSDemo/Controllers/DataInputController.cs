namespace GDSDemo.Controllers
{
    using GDSDemo.Models;
    using GDSDemo.RequestModels;
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.Infrastructure;
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class DataInputController : GDSController
    {
        public IActionResult Index()
        {
            var model = CreateDataInputsViewModel();
            var validationScript = ClientSideValidationProvider.GenerateClientSideValidationScript(model);
            ViewBag.ValidationScript = validationScript;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DataInputsViewModel model)
        {
            var refModel = CreateDataInputsViewModel();
            model.Sort = SelectInputViewModelExtension.PopulateSelectViewModel(model.Sort, refModel.Sort);
            model.Location = SelectInputViewModelExtension.PopulateSelectViewModel(model.Location, refModel.Location);
            model.DOB = DateInputViewModelExtension.PopulateDateInputViewModel(model.DOB, refModel.DOB);
            model.PassportExpiry = DateInputViewModelExtension.PopulateDateInputViewModel(model.PassportExpiry, refModel.PassportExpiry);
            model.NationalInsuranceNumber = InputViewModelExtension.PopulateInputViewModel(model.NationalInsuranceNumber, refModel.NationalInsuranceNumber);
            model.SubmitButton = refModel.SubmitButton;
            model.BackLink = refModel.BackLink;

            ValidateModel(model);
            if (ModelState.IsValid)
            {
                var passportExpiry = model.PassportExpiry.GetValues().Date.HasValue ? model.PassportExpiry.GetValues().Date.Value.ToString("d MMMM yyyy") : "No date available";
                var postedForm = new DataInputRequestModel
                {
                    Sort = model.Sort.GetValue(),
                    Location = model.Location.GetDisplayValue(),
                    DateOfBirth = model.DOB.GetValues().Date.ToString(),
                    PassportExpiry = passportExpiry,
                    NationalInsuranceNumber = model.NationalInsuranceNumber.GetValue(),
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
                    Errors = MapErrors<DataInputsViewModel>()
                };
            }

            return View(model);

        }

        public ActionResult Success()
        {
            var serializedForm = TempData["PostedData"] as string;
            var model = JsonConvert.DeserializeObject<DataInputRequestModel>(serializedForm);
            return View(model);
        }

        private DataInputsViewModel CreateDataInputsViewModel()
        {
            return new DataInputsViewModel
            {
                Sort = new()
                {
                    Label = "Sort by",
                    Hint = "Default selection",
                    Options = new List<OptionModel>
                    {
                        new()
                        {
                            Text = "Recently published",
                            Value = "published"
                        },new()
                        {
                            Text = "Recently updated",
                            Value = "updated"
                        },new()
                        {
                            Text = "Most views",
                            Value = "views"
                        },new()
                        {
                            Text = "Most comments",
                            Value = "comments"
                        }
                    }
                },
                Location = new()
                {
                    Label = "What is your location?",
                    QuestionType = InputMultiQuestionType.Multiple,
                    Options = new List<OptionModel>
                    {
                        new()
                        {
                            Text = "Choose location",
                            Value = "",
                            Selected = true
                        },new()
                        {
                            Text = "East Midlands",
                            Value = "eastmidlands"
                        },new()
                        {
                            Text = "London",
                            Value = "london"
                        },new()
                        {
                            Text = "North East",
                            Value = "northeast"
                        },new()
                        {
                            Text = "North West",
                            Value = "northwest"
                        },new()
                        {
                            Text = "South East",
                            Value = "southeast"
                        },new()
                        {
                            Text = "South West",
                            Value = "southwest"
                        },new()
                        {
                            Text = "West Midlands",
                            Value = "westmidlands"
                        },new()
                        {
                            Text = "Yorkshire and the Humber",
                            Value = "yorkshire"
                        }
                    }
                },
                DOB = new()
                {
                    Legend = "What is your date of birth?",
                },
                PassportExpiry = new()
                {
                    Legend = "When does your passport expire?",
                    QuestionType = InputMultiQuestionType.Multiple,
                    Hint = "For example, 27 3 2007",
                },
                NationalInsuranceNumber = new()
                {
                    Label = "National Insurance Number",
                    Hint = "This is in the format AA000000A",
                    QuestionType= InputMultiQuestionType.Multiple,
                },
                SubmitButton = new()
                {
                    Text = "Register",
                    ButtonType = ButtonType.Default,
                    ButtonAction = ButtonAction.Submit
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
