namespace GDSDemo.Models
{
    using GDS.Components.ViewModels;

    public class ComponentsViewModel : BasePageModel
    {
        public IList<ButtonViewModel> Buttons { get; set; }
        public DetailsViewModel DetailsView { get; set; }
        public InsetTextViewModel InsetText { get; set; }
        public IList<TagViewModel> Tags { get; set; }
        public PanelViewModel Panel { get; set; }
        public WarningViewModel Warning { get; set; }
        public PhaseBannerViewModel PhaseBanner { get; set; }
        public NotificationBannerViewModel AlertBanner { get; set; }
        public NotificationBannerViewModel SuccessBanner { get; set; }

        public ComponentsViewModel()
        {
            Buttons = new List<ButtonViewModel>();
            Tags = new List<TagViewModel>();
        }
    }
}
