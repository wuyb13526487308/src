using AJWebAPI.Report;
using Coldairarrow.Util;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LH.ReportWeb
{
    public partial class PrintReportView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            string key = Request.QueryString["key"];

            CacheReportData data = new SystemCache().GetCache(key) as CacheReportData;
            if (data == null)
            {
                //加载一个默认的报表，提示当前报表打开失败
            }
            else
            {
                XtraReport xtraReport = data.XtraReport;
                xtraReport.DataSource = data.DataSource;
                this.ReportViewer1.Report = xtraReport;
            }
        }
    }
}