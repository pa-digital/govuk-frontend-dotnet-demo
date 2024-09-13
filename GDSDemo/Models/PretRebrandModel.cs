namespace GDSDemo.Models
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModels;
    using GDS.Components.Validators;

    public class PretRebrandModel : BasePageModel
    {
        [RegexFromEnum(Regex.Name)]
        [RequiredComplexType(ErrorMessage = "Enter your first name")]
        public InputViewModel FirstName { get; set; }

        [RegexFromEnum(Regex.Name)]
        [RequiredComplexType(ErrorMessage = "Enter your last name")]
        public InputViewModel LastName { get; set; }

        [CustomRegExType(Pattern = @"^[0-9-]{1,15}$", ErrorMessage = "Your phone number can only contain + and digits")]
        [RequiredComplexType(ErrorMessage = "Enter your phone number")]
        public InputViewModel PhoneNumber { get; set; }

        [RegexFromEnum(Regex.Email)]
        [RequiredComplexType(ErrorMessage = "Enter your email address")]
        public InputViewModel Email { get; set; }

        [RequiredComplexType(ErrorMessage = "Enter a password to continue")]
        public PasswordViewModel Password { get; set; }

        [RequiredSelectType(ErrorMessage = "Please choose a location")]
        public SelectViewModel Location { get; set; }

        public CheckBoxListViewModel MarketingChoices { get; set; }

        public ButtonViewModel SubmitButton { get; set; }
        public ErrorSummaryViewModel ErrorSummary { get; set; }
    }
}
