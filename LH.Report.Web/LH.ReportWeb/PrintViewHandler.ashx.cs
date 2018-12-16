using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AJWebAPI.Report;
using Coldairarrow.Util;
using DevExpress.XtraReports.UI;
using RX.Gas.ReportLib;

namespace LH.ReportWeb
{
    /// <summary>
    /// PrintViewHandler 的摘要说明
    /// </summary>
    public class PrintViewHandler : IHttpHandler
    {
        private const string OUT_Ticket = "OUT_TICKET";
        private const string IN_Ticket = "IN_TICKET";



        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            CacheReportData data = new CacheReportData();


            //获取打印的类型
            string printType = context.Request.QueryString["ptype"];
            switch (printType.ToUpper())
            {
                case OUT_Ticket:

                    break;
                case IN_Ticket:

                    break;
            }
            BaseReport report = ReadReport(1);

            data.XtraReport = XtraReport.FromStream(report.getReportStream(), true);
            data.DataSource = report.DataSource;

            string printData = context.Request.Form["Data"];
            string key = Guid.NewGuid().ToSequentialGuid();
            new SystemCache().SetCache(key, data, new TimeSpan(0, 0, 30));

            AjaxResult res = new AjaxResult
            {
                Success = true,
                Msg = "请求成功！",
                Data = $"{System.Configuration.ConfigurationManager.AppSettings["rootUrl"]}PrintReportView.aspx?key={key}"
            };

            context.Response.Write(res.ToJson());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private BaseReport ReadReport(int rid)
        {
            return  new BaseReport(Convert.ToInt32(rid));
        }
    }


}