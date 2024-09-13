namespace GDSDemo.Controllers
{
    using GDSDemo.Models;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Html;
    using GDS.Components.Models;
    using GDS.Components.Enum;
    using GDS.Components.Infrastructure;

    public class DataDisplayController : GDSController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = CreateDataSeparationViewModel();
            return View(model);
        }

        private DataDisplayViewModel CreateDataSeparationViewModel()
        {
            return new DataDisplayViewModel
            {
                Accordion = new AccordionListViewModel
                {
                    Id = "Default_Accordion",
                    Elements = new List<AccordionElementViewModel>
                    {
                        new() {
                            Header = "Writing well for the web",
                            Content = "This is the content for Writing well for the web."
                        },
                        new() {
                            Header = "Writing well for specialists",
                            Content = "This is the content for Writing well for specialists."
                        },
                        new() {
                            Header = "Know your audience",
                            Content = "This is the content for Know your audience."
                        },
                        new() {
                            Header = "How people read",
                            Content = "This is the content for How people read."
                        }
                    }
                },
                Tab = new TabViewModel
                {
                    Title = "Tab Contents",
                    Tabs = new List<TabContentModel>
                    {
                        new()
                        {
                            TabHeader = "Past day",
                            TabContent = new HtmlString("<table class=\"govuk-table\">\r\n      <thead class=\"govuk-table__head\">\r\n        <tr class=\"govuk-table__row\">\r\n          <th scope=\"col\" class=\"govuk-table__header\">Case manager</th>\r\n          <th scope=\"col\" class=\"govuk-table__header\">Cases opened</th>\r\n          <th scope=\"col\" class=\"govuk-table__header\">Cases closed</th>\r\n        </tr>\r\n      </thead>\r\n      <tbody class=\"govuk-table__body\">\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">David Francis</td>\r\n          <td class=\"govuk-table__cell\">3</td>\r\n          <td class=\"govuk-table__cell\">0</td>\r\n        </tr>\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">Paul Farmer</td>\r\n          <td class=\"govuk-table__cell\">1</td>\r\n          <td class=\"govuk-table__cell\">0</td>\r\n        </tr>\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">Rita Patel</td>\r\n          <td class=\"govuk-table__cell\">2</td>\r\n          <td class=\"govuk-table__cell\">0</td>\r\n        </tr>\r\n      </tbody>\r\n    </table>")
                        },
                        new()
                        {
                            TabHeader = "Past week",
                            TabContent = new HtmlString("<table class=\"govuk-table\">\r\n      <thead class=\"govuk-table__head\">\r\n        <tr class=\"govuk-table__row\">\r\n          <th scope=\"col\" class=\"govuk-table__header\">Case manager</th>\r\n          <th scope=\"col\" class=\"govuk-table__header\">Cases opened</th>\r\n          <th scope=\"col\" class=\"govuk-table__header\">Cases closed</th>\r\n        </tr>\r\n      </thead>\r\n      <tbody class=\"govuk-table__body\">\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">David Francis</td>\r\n          <td class=\"govuk-table__cell\">24</td>\r\n          <td class=\"govuk-table__cell\">18</td>\r\n        </tr>\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">Paul Farmer</td>\r\n          <td class=\"govuk-table__cell\">16</td>\r\n          <td class=\"govuk-table__cell\">20</td>\r\n        </tr>\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">Rita Patel</td>\r\n          <td class=\"govuk-table__cell\">24</td>\r\n          <td class=\"govuk-table__cell\">27</td>\r\n        </tr>\r\n      </tbody>\r\n    </table>")
                        },
                        new()
                        {
                            TabHeader = "Past month",
                            TabContent = new HtmlString("<table class=\"govuk-table\">\r\n      <thead class=\"govuk-table__head\">\r\n        <tr class=\"govuk-table__row\">\r\n          <th scope=\"col\" class=\"govuk-table__header\">Case manager</th>\r\n          <th scope=\"col\" class=\"govuk-table__header\">Cases opened</th>\r\n          <th scope=\"col\" class=\"govuk-table__header\">Cases closed</th>\r\n        </tr>\r\n      </thead>\r\n      <tbody class=\"govuk-table__body\">\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">David Francis</td>\r\n          <td class=\"govuk-table__cell\">98</td>\r\n          <td class=\"govuk-table__cell\">95</td>\r\n        </tr>\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">Paul Farmer</td>\r\n          <td class=\"govuk-table__cell\">122</td>\r\n          <td class=\"govuk-table__cell\">131</td>\r\n        </tr>\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">Rita Patel</td>\r\n          <td class=\"govuk-table__cell\">126</td>\r\n          <td class=\"govuk-table__cell\">142</td>\r\n        </tr>\r\n      </tbody>\r\n    </table>")
                        },
                        new()
                        {
                            TabHeader = "Past year",
                            TabContent = new HtmlString("<table class=\"govuk-table\">\r\n      <thead class=\"govuk-table__head\">\r\n        <tr class=\"govuk-table__row\">\r\n          <th scope=\"col\" class=\"govuk-table__header\">Case manager</th>\r\n          <th scope=\"col\" class=\"govuk-table__header\">Cases opened</th>\r\n          <th scope=\"col\" class=\"govuk-table__header\">Cases closed</th>\r\n        </tr>\r\n      </thead>\r\n      <tbody class=\"govuk-table__body\">\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">David Francis</td>\r\n          <td class=\"govuk-table__cell\">1380</td>\r\n          <td class=\"govuk-table__cell\">1472</td>\r\n        </tr>\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">Paul Farmer</td>\r\n          <td class=\"govuk-table__cell\">1129</td>\r\n          <td class=\"govuk-table__cell\">1083</td>\r\n        </tr>\r\n        <tr class=\"govuk-table__row\">\r\n          <td class=\"govuk-table__cell\">Rita Patel</td>\r\n          <td class=\"govuk-table__cell\">1539</td>\r\n          <td class=\"govuk-table__cell\">1265</td>\r\n        </tr>\r\n      </tbody>\r\n    </table>")
                        }
                    }
                },
                Table = new TableViewModel
                {
                    Caption = "Dates and amounts",
                    Headers = new List<TableHeaderCellModel>
                    {
                        new()
                        {
                            Data = "Date"
                        },
                        new()
                        {
                            Data = "Amount"
                        }
                    },
                    Rows = new List<TableRowModel>
                    {
                        new() {
                            HeaderColumn = "First 6 weeks",
                            DataColumns = new List<TableCellModel>
                            {
                                new() {
                                    Data = "£109.80 per week"
                                }
                            }
                        },
                        new() {
                            HeaderColumn = "Next 33 weeks",
                            DataColumns = new List<TableCellModel>
                            {
                                new() {
                                    Data = "£109.80 per week"
                                }
                            }
                        },
                        new() {
                            HeaderColumn = "Total estimated pay",
                            DataColumns = new List<TableCellModel>
                            {
                                new() {
                                    Data = "£4,282.20"
                                }
                            }
                        }
                    }
                },
                NumericTable = new TableViewModel
                {
                    Caption = "Months and rates",
                    Headers = new List<TableHeaderCellModel>
                    {
                        new()
                        {
                            Data = "Month you apply"
                        },
                        new()
                        {
                            Data = "Rate for bicycles",
                            DataType = TableHeaderDataType.Numeric
                        },
                        new()
                        {
                            Data = "Rate for vehicles",
                            DataType = TableHeaderDataType.Numeric
                        }
                    },
                    Rows = new List<TableRowModel>
                    {
                        new() {
                            HeaderColumn = "January",
                            DataColumns = new List<TableCellModel>
                            {
                                new() {
                                    Data = "£85",
                                    DataType = TableCellDataType.Numeric
                                },
                                new() {
                                    Data = "£95",
                                    DataType = TableCellDataType.Numeric
                                }
                            }
                        },
                        new() {
                            HeaderColumn = "February",
                            DataColumns = new List<TableCellModel>
                            {
                                new() {
                                    Data = "£75",
                                    DataType = TableCellDataType.Numeric
                                },
                                new() {
                                    Data = "£55",
                                    DataType = TableCellDataType.Numeric
                                }
                            }
                        },
                        new() {
                            HeaderColumn = "March",
                            DataColumns = new List<TableCellModel>
                            {
                                new() {
                                    Data = "£165",
                                    DataType = TableCellDataType.Numeric
                                },
                                new() {
                                    Data = "£125",
                                    DataType = TableCellDataType.Numeric
                                }
                            }
                        }
                    }
                },
                CustomWidthTable = new TableViewModel
                {
                    Caption = "Months and rates",
                    Headers = new List<TableHeaderCellModel>
                    {
                        new()
                        {
                            Data = "Month you apply",
                            CustomWidth = TableHeaderCustomWidth.Half
                        },
                        new()
                        {
                            Data = "Rate for bicycles",
                            CustomWidth = TableHeaderCustomWidth.Quarter
                        },
                        new()
                        {
                            Data = "Rate for vehicles",
                            CustomWidth = TableHeaderCustomWidth.Quarter
                        }
                    },
                    Rows = new List<TableRowModel>
                    {
                        new() {
                            HeaderColumn = "January",
                            DataColumns = new List<TableCellModel>
                            {
                                new() {
                                    Data = "£85 per week"
                                },
                                new() {
                                    Data = "£95 per week"
                                }
                            }
                        },
                        new() {
                            HeaderColumn = "February",
                            DataColumns = new List<TableCellModel>
                            {
                                new() {
                                    Data = "£75 per week"
                                },
                                new() {
                                    Data = "£55 per week"
                                }
                            }
                        },
                        new() {
                            HeaderColumn = "March",
                            DataColumns = new List<TableCellModel>
                            {
                                new() {
                                    Data = "£165 per week"
                                },
                                new() {
                                    Data = "£125 per week"
                                }
                            }
                        }
                    }
                },
                SummaryList = new SummaryListViewModel
                {
                    Items = new List<SummaryListItemModel>
                    {
                        new()
                        {
                            Label = "Name",
                            Text = new HtmlString("Sarah Philips")
                        },
                        new()
                        {
                            Label = "Date of birth",
                            Text = new HtmlString("5 January 1978"),
                            ActionLinks = new List<SummaryListActionLinkModel>
                            {
                                new()
                                {
                                    Text = "Change",
                                    ActionContext = "date of birth",
                                    Url = "#"
                                }
                            }

                        },
                        new()
                        {
                            Label = "Address",
                            Text = new HtmlString("72 Guild Street<br>London<br>SE23 6FH"),
                            ActionLinks = new List<SummaryListActionLinkModel>
                            {
                                new()
                                {
                                    Text = "Change",
                                    ActionContext = "address",
                                    Url = "#"
                                }
                            }

                        },
                        new()
                        {
                            Label = "Contact details",
                            Text = new HtmlString("07700 900457<br>sarah.phillips@example.com"),
                            ActionLinks = new List<SummaryListActionLinkModel>
                            {
                                new()
                                {
                                    Text = "Add",
                                    ActionContext = "contact details",
                                    Url = "#"
                                },
                                new()
                                {
                                    Text = "Change",
                                    ActionContext = "contact details",
                                    Url = "#"
                                }
                            }

                        }
                    }
                },
                BorderLessMissingInfoSummaryList = new SummaryListViewModel
                {
                    HideBorders = true,
                    Items = new List<SummaryListItemModel>
                    {
                        new()
                        {
                            Label = "Name",
                            Text = new HtmlString("Sarah Philips")
                        },
                        new()
                        {
                            Label = "Date of birth",
                            Text = new HtmlString("5 January 1978"),
                            ActionLinks = new List<SummaryListActionLinkModel>
                            {
                                new()
                                {
                                    Text = "Change",
                                    ActionContext = "date of birth",
                                    Url = "#"
                                }
                            }

                        },
                        new()
                        {
                            Label = "Address",
                            MissingItem = new()
                            {
                                Text = "Enter address details",
                                Url= "#"
                            }
                        },
                        new()
                        {
                            Label = "Contact details",
                            Text = new HtmlString("07700 900457"),
                            ActionLinks = new List<SummaryListActionLinkModel>
                            {
                                new()
                                {
                                    Text = "Add",
                                    ActionContext = "contact details",
                                    Url = "#"
                                },
                                new()
                                {
                                    Text = "Change",
                                    ActionContext = "contact details",
                                    Url = "#"
                                }
                            }

                        }
                    }
                },
                SummaryCards = new SummaryCardListViewModel
                {
                    Cards = new List<SummaryCardModel> { 
                        new()
                        {
                            Header = "University of Gloucestershire",
                            ActionLinks = new List<SummaryListActionLinkModel>
                            {
                                new()
                                {
                                    Url = "#",
                                    Text = "Delete choice",
                                    ActionContext = "of University of Gloucestershire (University of Gloucestershire)"
                                },
                                new()
                                {
                                    Url = "#",
                                    Text = "Withdraw",
                                    ActionContext = "from University of Gloucestershire (University of Gloucestershire)"
                                }
                            },
                            Content = new()
                            {
                                Items = new List<SummaryListItemModel>
                                {
                                    new()
                                    {
                                        Label = "Course",
                                        Text = new HtmlString("English (3DMD)<br>PGCE with QTS full time")
                                    },
                                    new()
                                    {
                                        Label = "Location",
                                        Text = new HtmlString("School name<br>Road, City, SW1 1AA")
                                    }
                                }
                            }
                        },
                        new()
                        {
                            Header = "University of Bristol",
                            ActionLinks = new List<SummaryListActionLinkModel>
                            {
                                new()
                                {
                                    Url = "#",
                                    Text = "Delete choice",
                                    ActionContext = "of University of Bristol (University of Bristol)"
                                },
                                new()
                                {
                                    Url = "#",
                                    Text = "Withdraw",
                                    ActionContext = "from University of Bristol (University of Bristol)"
                                }
                            },
                            Content = new()
                            {
                                Items = new List<SummaryListItemModel>
                                {
                                    new()
                                    {
                                        Label = "Course",
                                        Text = new HtmlString("English (Q3X1)<br>PGCE with QTS full time")
                                    },
                                    new()
                                    {
                                        Label = "Location",
                                        Text = new HtmlString("School name<br>Road, City, SW2 1AA")
                                    }
                                }
                            }
                        }
                    }
                },
                Tasks = new TaskListViewModel()
                {
                    Tasks = new List<TaskModel>
                    {
                        new()
                        {
                            Link = new()
                            {
                                Url = "#",
                                Text = "Company Directors"
                            },
                            Status = "Completed"
                        },
                        new()
                        {
                            Link = new()
                            {
                                Url= "#",
                                Text = "Registered company details"
                            },
                            Tag = new()
                            {
                                Text = "Incomplete"
                            }
                        },
                        new()
                        {
                            Link = new()
                            {
                                Url= "#",
                                Text = "Financial history"
                            },
                            Hint = new HtmlString("Include 5 years of the company&apos;s relevant financial information."),
                            Tag = new()
                            {
                                Text = "Incomplete"
                            }
                        }
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
