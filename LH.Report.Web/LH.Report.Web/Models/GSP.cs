using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public static class GSP {
        public static IEnumerable GetData() {
            using (AccessDataSource dataSource = new AccessDataSource("~/App_Data/gsp.mdb", "SELECT Year, Region, GSP FROM GSP"))
                return dataSource.Select(new DataSourceSelectArguments());
        }
    }
}
