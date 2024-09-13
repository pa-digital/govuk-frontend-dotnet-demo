namespace GDSDemo.Controllers
{
    using GDSDemo.Models;
    using GDS.Components.Enum;
    using GDS.Components.Infrastructure;
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class NavigationController : GDSController
    {
        public IActionResult Index()
        {
            var model = CreateComponentsViewModel();
            return View(model);
        }

        private int GetPageNumberFromQueryString(string queryStringKey, int defaultValue)
        {
            int pageValue;

            var queryStringValue = Request.Query[queryStringKey].ToString();

            if (string.IsNullOrWhiteSpace(queryStringValue))
            {
                return defaultValue;
            }

            if (!int.TryParse(queryStringValue, out pageValue))
            {
                return defaultValue;
            }

            return pageValue;
        }

        private NavigationViewModel CreateComponentsViewModel()
        {
            return new NavigationViewModel
            {
                Breadcrumbs = new BreadcrumbsViewModel
                {
                    Label = "Breadcrumbs",
                    Links = new List<BaseUrlModel>
                    {
                        new()
                        {
                            Url = "#",
                            Text = "Home"
                        },
                        new()
                        {
                            Url = "#",
                            Text = "Passports, travel and living abroad"
                        },
                        new()
                        {
                            Url = "#",
                            Text = "Travel abroad"
                        }
                    }
                },
                ExitPage = new()
                {
                    Text = "Exit this page",
                    Url = "https://www.bbc.co.uk/weather"
                },
                InverseBreadcrumbs = new BreadcrumbsViewModel
                {
                    Label = "Breadcrumbs",
                    BreadcrumbType = BreadcrumbType.Inverse,
                    Links = new List<BaseUrlModel>
                    {
                        new()
                        {
                            Url = "#",
                            Text = "Home"
                        },
                        new()
                        {
                            Url = "#",
                            Text = "Passports, travel and living abroad"
                        },
                        new()
                        {
                            Url = "#",
                            Text = "Travel abroad"
                        }
                    }
                },               
                StandardPagination = new PaginationViewModel
                {
                    RootUrl = "?standard=",
                    PreviousText = "Previous",
                    NextText = "Next",
                    MaxPage = 3,
                    CurrentPage = GetPageNumberFromQueryString("standard", 2)
                },
                NoPrevPagination = new PaginationViewModel
                {
                    RootUrl = "?noprev=",
                    PreviousText = "Previous",
                    NextText = "Next",
                    MaxPage = 3,
                    CurrentPage = GetPageNumberFromQueryString("noprev", 1)
                },
                NoNextPagination = new PaginationViewModel
                {
                    RootUrl = "?nonext=",
                    PreviousText = "Previous",
                    NextText = "Next",
                    MaxPage = 3,
                    CurrentPage = GetPageNumberFromQueryString("nonext", 3)
                },
                MidLargePagination = new PaginationViewModel
                {
                    RootUrl = "?midlarge=",
                    PreviousText = "Previous",
                    NextText = "Next",
                    MaxPage = 42,
                    CurrentPage = GetPageNumberFromQueryString("midlarge", 6)
                },
                ContentPagination = new PaginationViewModel
                {
                    PaginationType = PaginationType.Content,
                    PreviousLink = new()
                    {
                        Text = "Previous",
                        Label = "Applying for a provisional lorry or bus licence",
                        Url = "#"
                    },
                    NextLink = new()
                    {
                        Text = "Next",
                        Label = "Driver CPC part 1 test: theory",
                        Url = "#"
                    }
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
