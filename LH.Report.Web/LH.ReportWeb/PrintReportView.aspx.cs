using AJWebAPI.Report;
using Coldairarrow.Util;
using DevExpress.XtraReports.UI;
using RX.Gas.ReportLib;
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
                BaseReport report = ReadReport(data.ReportID);

                XtraReport xtraReport = XtraReport.FromStream(report.getReportStream(), true);
                foreach (DefineSqlParameter par in report.DataSource.DbParameterCollection)
                {
                    if (par.ParameterName.ToUpper() == "ID".ToUpper())
                       par.Value = data.QueryKey;
                }
                report.DataSource.Fill();
                xtraReport.DataSource = report.DataSource;
                this.ReportViewer1.Report = xtraReport;
                //xtraReport.CreateDocument();
            }
        }

        private BaseReport ReadReport(int rid)
        {
            return new BaseReport(Convert.ToInt32(rid));
        }
    }
}