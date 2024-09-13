namespace GDSDemo.Models
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;
    using GDS.Components.Validators;
    public class NIHRRebrandViewModel : BasePageModel
    {
        [RegexFromEnum(Regex.Name)]
        [RequiredComplexType(ErrorMessage = "Name is required.")]
        public InputViewModel Name { get; set; }

        [RegexFromEnum(Regex.Email)]
        [RequiredComplexType(ErrorMessage = "Email is required.")]
        public InputViewModel Email { get; set; }

        [RegexFromEnum(Regex.Password)]
        [RequiredComplexType(ErrorMessage = "Password is required.")]
        public PasswordViewModel Password { get; set; }

        [ListControl]
        [RequiredCheckBoxType(ErrorMessage = "At least one interest is required.")]
        public CheckBoxListViewModel Interests { get; set; }

        [ListControl]
        [RequiredRadioButtonType(ErrorMessage = "You must select your country of origin.")]
        public RadioButtonListViewModel CountryOfResidence { get; set; }

        public ButtonViewModel SubmitButton { get; set; }
        public ErrorSummaryViewModel ErrorSummary { get; set; }

        public BreadcrumbsViewModel Breadcrumbs { get; set; }
        public IList<ButtonViewModel> Buttons { get; set; }
        public DetailsViewModel DetailsView { get; set; }
        public InsetTextViewModel InsetText { get; set; }
        public IList<TagViewModel> Tags { get; set; }
        public PanelViewModel Panel { get; set; }
        public WarningViewModel Warning { get; set; }
    }
}
