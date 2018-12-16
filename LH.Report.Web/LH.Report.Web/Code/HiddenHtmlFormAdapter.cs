using System;
using System.Web.UI;
using System.Web.UI.Adapters;

namespace DevExpress.Web.Demos {
    
    public class HiddenHtmlFormAdapter : ControlAdapter {

        protected override void OnInit(EventArgs e) {
            // do nothing
        }

        protected override void OnPreRender(EventArgs e) {
            // do nothing
        }

        protected override void Render(HtmlTextWriter writer) {
            foreach(Control child in Control.Controls) {
                child.RenderControl(writer);
            }
        }

    }

}
