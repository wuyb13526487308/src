using System;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        [HttpGet]
        public ActionResult GanttViews() {
            ChartViewTypeDemoOptions options = new ChartViewTypeDemoOptions();
            options.View = DevExpress.XtraCharts.ViewType.Gantt;
            Session[ChartDemoHelper.OptionsKey] = options;
            Session[ChartDemoHelper.CompletedDateKey] = ProjectsProvider.DefaultCompletedDate;
            return DemoView("GanttViews", ProjectsProvider.GetProjectTasks(ProjectsProvider.DefaultCompletedDate));
        }
        [HttpPost]
        public ActionResult GanttViews([Bind] ChartViewTypeDemoOptions options) {
            Session[ChartDemoHelper.OptionsKey] = options;
            if(options.View == DevExpress.XtraCharts.ViewType.Gantt) {
                Session[ChartDemoHelper.CompletedDateKey] = ProjectsProvider.DefaultCompletedDate;
                return DemoView("GanttViews", ProjectsProvider.GetProjectTasks(ProjectsProvider.DefaultCompletedDate));
            }
            else {
                object model = ProjectsProvider.GetProjectsTasks();
                Session[ChartDemoHelper.ModelKey] = model;
                return DemoView("GanttViews", model);
            }
        }
        public ActionResult GanttViewsPartial() {
            DateTime completedDate = DateTime.Parse(Request.Params["CompletedDate"], System.Globalization.CultureInfo.InvariantCulture);
            Session[ChartDemoHelper.CompletedDateKey] = completedDate;
            return PartialView("GanttViewsPartial", ProjectsProvider.GetProjectTasks(completedDate));
        }
        public ActionResult GanttViewsSideBySidePartial() {
            return PartialView("GanttViewsSideBySidePartial", Session[ChartDemoHelper.ModelKey]);
        }
        public ActionResult CustomActionGanttViewsSideBySidePartial() {
            ViewBag.SeriesName = Request.Params["SeriesName"];
            ViewBag.Argument = Request.Params["Argument"];
            ViewBag.ValueIndex = Convert.ToInt32(Request.Params["ValueIndex"]);
            ViewBag.Date = Convert.ToDateTime(Request.Params["Date"], System.Globalization.CultureInfo.InvariantCulture);
            return PartialView("GanttViewsSideBySidePartial", Session[ChartDemoHelper.ModelKey]);
        }
    }
}
