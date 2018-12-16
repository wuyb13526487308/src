using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult DataBinding() {
            return DemoView("DataBinding", TweetProvider.GetDevExpressTweets());
        }
        public ActionResult DataBindingPartial() {
            return PartialView("DataBindingPartial", TweetProvider.GetDevExpressTweets());
        }
    }
}
