namespace GDSDemo.Models
{
    using GDS.Components.ViewModels;

    public class NavigationViewModel : BasePageModel
    {
        public BreadcrumbsViewModel Breadcrumbs { get; set; }
        public ExitPageViewModel ExitPage { get; set; }
        public BreadcrumbsViewModel InverseBreadcrumbs { get; set; }
        public PaginationViewModel StandardPagination { get; set; }
        public PaginationViewModel NoPrevPagination { get; set; }
        public PaginationViewModel NoNextPagination { get; set; }
        public PaginationViewModel MidLargePagination { get; set; }
        public PaginationViewModel ContentPagination { get; set; }
    }
}
