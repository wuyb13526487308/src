using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Collections;
using System.Linq;
using DevExpress.Web.Demos.Models;
using DevExpress.Data;

namespace DevExpress.Web.Demos {
    public partial class GridViewController: DemoController {
        public ActionResult AdvancedCustomBinding() {
            return DemoView("AdvancedCustomBinding");
        }

        public ActionResult AdvancedCustomBindingPartial() {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if(viewModel == null)
                viewModel = CreateGridViewModelWithSummary();
            return AdvancedCustomBindingCore(viewModel);
        }
        // Paging
        public ActionResult AdvancedCustomBindingPagingAction(GridViewPagerState pager) {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.Pager.Assign(pager);
            return AdvancedCustomBindingCore(viewModel);

        }
        // Filtering
        public ActionResult AdvancedCustomBindingFilteringAction(GridViewColumnState column) {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.Columns[column.FieldName].Assign(column);
            return AdvancedCustomBindingCore(viewModel);
        }
        // Sorting
        public ActionResult AdvancedCustomBindingSortingAction(GridViewColumnState column, bool reset) {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.SortBy(column, reset);
            return AdvancedCustomBindingCore(viewModel);
        }
        // Grouping
        public ActionResult AdvancedCustomBindingGroupingAction(GridViewColumnState column) {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.Columns[column.FieldName].Assign(column);
            return AdvancedCustomBindingCore(viewModel);
        }

        PartialViewResult AdvancedCustomBindingCore(GridViewModel viewModel) {
            viewModel.ProcessCustomBinding(
                GridViewCustomBindingHandlers.GetDataRowCountAdvanced,
                GridViewCustomBindingHandlers.GetDataAdvanced,
                GridViewCustomBindingHandlers.GetSummaryValuesAdvanced,
                GridViewCustomBindingHandlers.GetGroupingInfoAdvanced,
                GridViewCustomBindingHandlers.GetUniqueHeaderFilterValuesAdvanced
            );
            return PartialView("AdvancedCustomBindingPartial", viewModel);
        }

        static GridViewModel CreateGridViewModelWithSummary() {
            var viewModel = new GridViewModel();
            viewModel.KeyFieldName = "ID";
            viewModel.Columns.Add("From");
            viewModel.Columns.Add("Subject");
            viewModel.Columns.Add("Sent");
            viewModel.Columns.Add("Size");
            viewModel.Columns.Add("HasAttachment");

            viewModel.TotalSummary.Add(new GridViewSummaryItemState() { FieldName = "Size", SummaryType = SummaryItemType.Sum });
            viewModel.TotalSummary.Add(new GridViewSummaryItemState() { FieldName = "Subject", SummaryType = SummaryItemType.Count });
            viewModel.GroupSummary.Add(new GridViewSummaryItemState() { FieldName = string.Empty, SummaryType = SummaryItemType.Count });
            return viewModel;
        }
    }
}
