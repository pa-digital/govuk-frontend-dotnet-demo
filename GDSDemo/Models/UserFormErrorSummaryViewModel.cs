namespace GDSDemo.Models
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;
    using GDS.Components.Validators;
    public class UserFormErrorSummaryViewModel : BasePageModel
    {
        [RegexFromEnum(Regex.Name)]
        [RequiredComplexType(ErrorMessage = "Name is required.")]
        public InputViewModel Name { get; set; }

        [RegexFromEnum(Regex.Email)]
        [RequiredComplexType(ErrorMessage = "Email is required.")]
        public InputViewModel Email { get; set; }

        [ListControl]
        [RequiredCheckBoxType(ErrorMessage = "At least one interest is required.")]
        public CheckBoxListViewModel Interests { get; set; }

        [ListControl]
        [RequiredRadioButtonType(ErrorMessage = "You must select your country of origin.")]
        public RadioButtonListViewModel CountryOfResidence { get; set; }

        public ButtonViewModel SubmitButton { get; set; }
        public ErrorSummaryViewModel ErrorSummary { get; set; }
    }
}
