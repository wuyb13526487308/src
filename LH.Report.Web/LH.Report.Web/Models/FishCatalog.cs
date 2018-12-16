using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public static class FishCatalog {
        public static IEnumerable GetData() {
            using(AccessDataSource dataSource = new AccessDataSource("~/App_Data/Fish.mdb", "SELECT * FROM BioLife"))
                return dataSource.Select(new DataSourceSelectArguments()); 
        }
    }
}
