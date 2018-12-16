using AJWebAPI.Report;
using DevExpress.XtraReports.UI;
using RX.Gas.ReportLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using WC.AJ.Common;

namespace ReportWebApp.Report
{
    public partial class ReportView : System.Web.UI.Page
    {
        List<FiledItem> list;
        BaseReport report;
        string ird;
        //CompanyOperator loginOperator;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    string rid = Request.QueryString["id"];
            //    BaseReport report = new BaseReport(Convert.ToInt32(rid));
            //    this.Session["ReportID"] = rid;


            //    if (report != null)
            //    {
            //        report.DataSource.Fill();
            //        OpenReport(report);
            //    }
            //}
            //if (Session["LoginCompanyOperator"] != null)
            //{                        
            //    //向数据中心记录登录信息
            //    loginOperator = (CompanyOperator)Session["LoginCompanyOperator"];
            //}
            //else
            //{
            //    Response.Write("<script> window.top.location.href = '../Login.html';</script>");
            //}

            LoadReportHeader();
        }

        private void LoadReportHeader(/*CompanyOperator Operator*/)
        {
            string rid = Request.QueryString["id"];
            if (this.Session["ReportID"] != null)
                ird = this.Session["ReportID"].ToString();
            if (ird == null || ird.Trim() == "") ird = "1";// return;
            if (!this.IsPostBack || rid != ird)
            {
                list = new List<FiledItem>();
                report = new BaseReport(Convert.ToInt32(rid));
                this.Session["ReportID"] = rid;

                bool isHaveCompany = false;
                bool isHaveOper = false;

                foreach (DefineSqlParameter par in report.DataSource.DbParameterCollection)
                {
                    if (!par.ParameterName.StartsWith("_"))
                    {
                        //创建输入
                        FiledItem item = new FiledItem(par);
                        list.Add(item);
                    }
                    else
                    {
                        switch (par.ParameterName)
                        {
                            case "_CompanyID":
                                par.Value = "";// loginOperator == null ? "" : loginOperator.CompanyID;
                                break;
                            case "_OperatorID":
                                par.Value = "";// loginOperator == null ? "" : loginOperator.OperID;
                                break;
                            default:
                                par.Value = string.Empty;
                                break;
                        }
                    }

                    if (par.ParameterName == "_CompanyID")
                    {
                        isHaveCompany = true;
                    }
                    if (par.ParameterName == "_OperatorID")
                    {
                        isHaveOper = true;
                    }
                }


                if (!isHaveCompany)
                {
                    DefineSqlParameter parCompanyId = new DefineSqlParameter("_CompanyID", SqlDbType.VarChar, 50, "");
                    parCompanyId.Value = "";// Operator.CompanyID;
                    report.DataSource.DbParameterCollection.Add(parCompanyId);


                }
                if (!isHaveOper)
                {
                    DefineSqlParameter parOperatorId = new DefineSqlParameter("_OperatorID", SqlDbType.VarChar, 50, "");
                    parOperatorId.Value = "";// Operator.OperID;
                    report.DataSource.DbParameterCollection.Add(parOperatorId);
                }


                this.Session["Rlist"] = list;
                this.Session.Add("Report", report);
            }
            else
            {
                list = (List<FiledItem>)this.Session["Rlist"];
                report = (BaseReport)this.Session["Report"];
            }
            if (list == null)
                return;

            LoadCondition(list);
            btnQuery_Click(null, null);

        }
        private void LoadCondition(List<FiledItem> items)
        {
            if (items == null)
                return;
            int iColumn = 0;
            TableRow dRow = null;
            TableCell tCell = null;
            foreach (FiledItem par in items)
            {
                if (!par.FiledName.StartsWith("_"))
                {
                    dRow = new TableRow();
                    this.tabCondition.Rows.Add(dRow);
                    tCell = new TableCell();
                    tCell.Text = par.FiledName;
                    tCell.Width = 60;
                    //tCell.HorizontalAlign = HorizontalAlign.Left;
                    dRow.Cells.Add(tCell);

                    dRow = new TableRow();
                    this.tabCondition.Rows.Add(dRow);
                    tCell = new TableCell();
                    tCell.Controls.Add(par.getFiled());
                    dRow.Cells.Add(tCell);
                }

            }

            if (this.tabCondition.Rows.Count > 0)
            {
                //tCell = new TableCell();
                //tCell.Controls.Add(this.btnQuery);
                //this.tabCondition.Rows[0].Cells.Add(tCell);
            }
            else
            {
                this.btnQuery.Text = "刷新";
            }
        }

        private void OpenReport(BaseReport report)
        {
            if (report == null) return;
            XtraReport xtraReport = XtraReport.FromStream(report.getReportStream(), true);
            xtraReport.DataSource = report.DataSource;
            this.ReportViewer1.Report = xtraReport;
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            list = (List<FiledItem>)this.Session["Rlist"];
            report = (BaseReport)this.Session["Report"];
            if (list != null)
            {
                foreach (FiledItem item in list)
                {
                    item.CheckValue();
                }
            }
            this.Session["Rlist"] = list;
            this.Session["Report"] = report;
            if (report != null)
            {
                report.DataSource.Fill();
                OpenReport(report);
            }
        }

    }
}