using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LH.StoReports
{
    public class LHReportHelper
    {
        class ReportRegistrationItem
        {
            public Func<XtraReport> ReportBuilder { get; set; }
            public string ParametersView { get; set; }
        }

        public static ReportsModel CreateModel(string reportID)
        {
            return new ReportsModel()
            {
                ReportID = reportID,
                Report = GetReport(reportID),
                ParametersView = GetParametersViewName(reportID)
            };
        }


        static XtraReport GetReport(string reportID)
        {
            //return reports[reportID].ReportBuilder();
            return new XtraReport();
        }

        static string GetParametersViewName(string reportID)
        {
            return "222222";// reports[reportID].ParametersView;
        }

        static object ConvertType(string stringValue, Type type)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(type);
            return converter.IsValid(stringValue) ? converter.ConvertFrom(stringValue) : null;
        }

    }
}
