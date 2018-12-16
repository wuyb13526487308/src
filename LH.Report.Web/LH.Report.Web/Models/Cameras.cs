using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public static class Cameras {
        public static IEnumerable GetData(string selectCommand = null) {
            using(AccessDataSource dataSource = new AccessDataSource("~/App_Data/Data.mdb", "SELECT * FROM Cameras" + selectCommand))
                return dataSource.Select(new DataSourceSelectArguments());
        }
    }
}
