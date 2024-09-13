namespace GDSDemo.Models
{
    using GDS.Components.Enum;
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;

    public class RegistrationViewModel : BasePageModel
    {
        [RegexFromEnum(Regex.Email)]
        [RequiredComplexType(ErrorMessage = "Email is required.")]
        public InputViewModel Email { get; set; }

        [RegexFromEnum(Regex.Password)]
        [RequiredComplexType(ErrorMessage = "Password is required.")]
        public PasswordViewModel Password { get; set; }

        public ButtonViewModel SubmitButton { get; set; }
        public ErrorSummaryViewModel ErrorSummary { get; set; }
    }
}
