namespace GDSDemo.Models
{
    using GDS.Components.ViewModels;

    public class DataDisplayViewModel : BasePageModel
    {
        public AccordionListViewModel Accordion { get; set; }
        public TabViewModel Tab { get; set; }
        public TableViewModel Table { get; set; }
        public TableViewModel NumericTable { get; set; }
        public TableViewModel CustomWidthTable { get; set; }
        public SummaryListViewModel SummaryList { get; set; }
        public SummaryListViewModel BorderLessMissingInfoSummaryList { get; set; }
        public SummaryCardListViewModel SummaryCards { get; set; }
        public TaskListViewModel Tasks { get; set; }
    }
}
