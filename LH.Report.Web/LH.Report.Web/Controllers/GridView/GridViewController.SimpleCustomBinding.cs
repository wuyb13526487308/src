using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Collections;
using System.Linq;
using DevExpress.Web.Demos.Models;

namespace DevExpress.Web.Demos {
    public partial class GridViewController: DemoController {
        public ActionResult SimpleCustomBinding() {
            return DemoView("SimpleCustomBinding");
        }
        public ActionResult SimpleCustomBindingPartial() {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if(viewModel == null)
                viewModel = CreateGridViewModel();
            return SimpleCustomBindingCore(viewModel);
        }
        //Paging
        public ActionResult SimpleCustomBindingPagingAction(GridViewPagerState pager) {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.Pager.Assign(pager);
            return SimpleCustomBindingCore(viewModel);
        }
        //Sorting
        public ActionResult SimpleCustomBindingSortingAction(GridViewColumnState column, bool reset) {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.SortBy(column, reset);
            return SimpleCustomBindingCore(viewModel);
        }

        PartialViewResult SimpleCustomBindingCore(GridViewModel gridViewModel) {
            gridViewModel.ProcessCustomBinding(
                GridViewCustomBindingHandlers.GetDataRowCountSimple,
                GridViewCustomBindingHandlers.GetDataSimple
            );
            return PartialView("SimpleCustomBindingPartial", gridViewModel);
        }

        static GridViewModel CreateGridViewModel() {
            var viewModel = new GridViewModel();
            viewModel.KeyFieldName = "ID";
            viewModel.Columns.Add("From");
            viewModel.Columns.Add("Subject");
            viewModel.Columns.Add("Sent");
            viewModel.Columns.Add("Size");
            viewModel.Columns.Add("HasAttachment");
            return viewModel;
        }
    }
}
