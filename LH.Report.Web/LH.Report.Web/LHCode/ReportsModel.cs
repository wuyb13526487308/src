using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.UI;


namespace LH.StoReports
{
    public class ReportsModel
    {
        public string ReportID { get; set; }
        public XtraReport Report { get; set; }
        public string ParametersView { get; set; }
    }
}
