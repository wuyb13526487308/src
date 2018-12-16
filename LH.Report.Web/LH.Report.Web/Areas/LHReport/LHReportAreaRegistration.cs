using System.Web.Mvc;

namespace DevExpress.Web.Demos.Areas.LHReport
{
    public class LHReportAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "LHReport";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "LHReport_default",
                "LHReport/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
