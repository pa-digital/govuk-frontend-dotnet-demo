namespace GDSDemo.Models
{
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;

    public class DataInputsViewModel : BasePageModel
    {

        public SelectViewModel Sort { get; set; }

        [RequiredSelectType(ErrorMessage = "Location is required.")]
        public SelectViewModel Location { get; set; }

        [PastDateType(ErrorMessage = "Your date of birth must be in the past.")]
        [RequiredDateInputType(ErrorMessage = "Date of birth is required.")]
        public DateInputViewModel DOB { get; set; }

        [FutureDateType(ErrorMessage = "Passport expiry date must be in the future.")]
        [RequiredDateInputType(ErrorMessage = "Passport expiry date is required.")]
        public DateInputViewModel PassportExpiry { get; set; }

        [CustomRegExType(Pattern = @"^[A-Z]{2}[0-9]{6}[A-Z]{1}$", ErrorMessage = "The value must be in the format XX000000X.")]
        [RequiredComplexType(ErrorMessage = "National Insurance Number is required.")]
        public InputViewModel NationalInsuranceNumber { get; set; }
        public ButtonViewModel SubmitButton { get; set; }
        public ErrorSummaryViewModel ErrorSummary { get; set; }
    }
}
