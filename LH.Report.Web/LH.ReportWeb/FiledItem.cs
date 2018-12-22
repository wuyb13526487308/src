﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using RX.Gas.ReportLib;
using System.Data;
using DevExpress.XtraReports.UI;
//using CY.IotM.Common.Tool;
//using CY.IotM.Common;
using DevExpress.Web.ASPxClasses;
using My.Report.ReportService;

namespace AJWebAPI.Report
{
    public class FiledItem
    {
        private DefineSqlParameter par;
        protected ASPxCheckBox _chkParameter;
        protected ASPxDateEdit _dateParameter;
        protected ASPxSpinEdit _spinParameter;
        protected ASPxTextBox _txtParameter;
        protected ASPxComboBox _lpParameter;
        protected Control _Filed;
        object _object = "";

        public FiledItem(DefineSqlParameter par)
        {
            this.par = par;
        }
        public Control getFiled()
        {
            this.CreateFiled();
            return _Filed;
        }
        private Control CreateFiled()
        {
            Control _object = null;
            switch (this.par.SqlParameter.SqlDbType)
            {
                case SqlDbType.Bit:
                    //布尔型
                    this._chkParameter = new ASPxCheckBox();
                    this._chkParameter.Text = "";
                    this._chkParameter.Visible = true;
                    this._chkParameter.Width = 175;
                    _object = this._chkParameter;
                    break;
                case SqlDbType.DateTime:
                    //日期型
                    this._dateParameter = new ASPxDateEdit();
                    this._dateParameter.HelpText = this.par.Explain;
                    this._dateParameter.HelpTextSettings.DisplayMode = HelpTextDisplayMode.Popup;
                    this._dateParameter.HelpTextSettings.PopupMargins = new Margins(0, 0, 20, 1);
                    this._dateParameter.HelpTextSettings.Position = HelpTextPosition.Top;
                    this._dateParameter.CalendarProperties.ShowWeekNumbers = false;
                    this._dateParameter.CalendarProperties.ShowDayHeaders = false;
                    this._dateParameter.Width = 175;
                    _object = this._dateParameter;
                    try
                    {
                        if (string.Format("{0}", this.par.SqlParameter.Value) == "")
                            this._dateParameter.Value = DateTime.UtcNow.AddHours(8);
                        else
                        {
                            try
                            {
                                this._dateParameter.Value = string.Format("{0:yyyy-MM-dd HH:mm:ss}", this.par.SqlParameter.Value);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    break;
                case SqlDbType.Decimal:
                    //实数
                    this._spinParameter = new ASPxSpinEdit();
                    this._spinParameter.HelpText = this.par.Explain;
                    this._spinParameter.HelpTextSettings.DisplayMode = HelpTextDisplayMode.Popup;
                    this._spinParameter.HelpTextSettings.PopupMargins = new Margins(0, 0, 20, 1);
                    this._spinParameter.HelpTextSettings.Position = HelpTextPosition.Top;
                    this._spinParameter.Text = "";
                    this._spinParameter.DecimalPlaces = 2;
                    this._spinParameter.Visible = true;
                    this._spinParameter.Width = 175;
                    _object = this._spinParameter;
                    break;
                case SqlDbType.Int:
                //整型
                case SqlDbType.SmallInt:
                    //短整型
                    this._spinParameter = new ASPxSpinEdit();
                    this._spinParameter.HelpText = this.par.Explain;
                    this._spinParameter.HelpTextSettings.DisplayMode = HelpTextDisplayMode.Popup;
                    this._spinParameter.HelpTextSettings.PopupMargins = new Margins(0, 0, 20, 1);
                    this._spinParameter.HelpTextSettings.Position = HelpTextPosition.Top;
                    this._spinParameter.Text = "";
                    this._spinParameter.DecimalPlaces = 0;
                    this._spinParameter.Visible = true;
                    this._spinParameter.Width = 175;
                    _object = this._spinParameter;
                    break;
                case SqlDbType.VarChar:
                    //字符型
                    switch (this.par.ParType)
                    {
                        case 0:
                            //手工方式录入
                            this._txtParameter = new ASPxTextBox();
                            this._txtParameter.HelpText = this.par.Explain;
                            this._txtParameter.HelpTextSettings.DisplayMode = HelpTextDisplayMode.Popup;
                            this._txtParameter.HelpTextSettings.PopupMargins = new Margins(0, 0, 20, 1);
                            this._txtParameter.HelpTextSettings.Position = HelpTextPosition.Top;
                            this._txtParameter.Text = string.Format("{0}", this.par.Value);
                            this._txtParameter.Visible = true;
                            this._txtParameter.Width = 175;
                            _object = this._txtParameter;
                            break;
                        case 1:
                            //数据源方式提供参数
                            this._lpParameter = new ASPxComboBox();
                            this._lpParameter.HelpText = this.par.Explain;
                            this._lpParameter.HelpTextSettings.DisplayMode = HelpTextDisplayMode.Popup;
                            this._lpParameter.HelpTextSettings.PopupMargins = new Margins(0, 0, 20, 1);
                            this._lpParameter.HelpTextSettings.Position = HelpTextPosition.Top;
                            this._lpParameter.DropDownButton.Visible = true;
                            this._lpParameter.Width = 175;
                            _object = this._lpParameter;
                            if (!ReadDataSource(_lpParameter, this.par.ConnectionString, this.par.CommandText, this.par.CommandType, this.par.DisplayMember, this.par.ValueMember))
                            {
                                this._txtParameter = new ASPxTextBox();
                                this._txtParameter.Text = string.Format("{0}", this.par.Value);
                                this._txtParameter.Visible = true;
                                _object = this._txtParameter;
                                this._lpParameter = null;
                            }
                            break;
                        case 2:
                            //列表方式提供参数
                            this._lpParameter = new ASPxComboBox();
                            this._lpParameter.HelpText = this.par.Explain;
                            this._lpParameter.HelpTextSettings.DisplayMode = HelpTextDisplayMode.Popup;
                            this._lpParameter.HelpTextSettings.PopupMargins = new Margins(0, 0, 20, 1);
                            this._lpParameter.HelpTextSettings.Position = HelpTextPosition.Top;
                            this._lpParameter.DropDownButton.Visible = true;
                            this._lpParameter.Width = 175;
                            _object = this._lpParameter;
                            string[] items = this.par.Items.Replace("\n", "").Split(new char[] { '\r', '|' });
                            for (int i = 0; i < items.Length; i++)
                            {
                                _lpParameter.Items.Add(new ListEditItem()
                                {
                                    Text = items[i],
                                    Value = items[i]
                                });
                            }
                            this._lpParameter.Value = par.Value;
                            break;

                    }
                    break;
                default:
                    break;
            }
            this._Filed = _object;
            return _object;

        }

        public object getValue
        {
            get
            {
                return _object;
            }
        }

        /// <summary>
        /// 获取字段的值
        /// </summary>
        public void CheckValue()
        {


            switch (this.par.SqlParameter.SqlDbType)
            {
                case SqlDbType.Bit:
                    //布尔型
                    if (this._chkParameter != null)
                        _object = this._chkParameter.Value;
                    else
                        _object = "false";
                    break;
                case SqlDbType.DateTime:
                    //日期型
                    if (this._dateParameter != null)
                    {
                        _object = this._dateParameter.Value;
                    }
                    break;
                case SqlDbType.Decimal:
                    //实数
                    if (this._spinParameter != null)
                        _object = this._spinParameter.Value;
                    break;
                case SqlDbType.Int:
                //整型
                case SqlDbType.SmallInt:
                    //短整型
                    if (this._spinParameter != null)
                        _object = this._spinParameter.Value;
                    break;
                case SqlDbType.VarChar:
                    //字符型
                    switch (this.par.ParType)
                    {
                        case 0:
                            //手工方式录入
                            if (this._txtParameter != null)
                                _object = this._txtParameter.Value;
                            break;
                        case 1:
                            //数据源方式提供参数
                            if (this._lpParameter != null)
                                _object = this._lpParameter.Value;
                            if (this._txtParameter != null)
                                _object = this._txtParameter.Value;
                            break;
                        case 2:
                            //列表方式提供参数
                            if (this._lpParameter != null)
                                _object = this._lpParameter.Value;
                            break;

                    }
                    break;
                default:
                    break;
            }
            if (_object == null)
                _object = "";
            this.par.Value = _object;

        }

        public string FiledName
        {
            get
            {
                return this.par.ParameterName;
            }
        }

        public DefineSqlParameter Iten
        {
            get
            {
                return par;
            }

            set
            {
                par = value;
            }
        }

        private bool ReadDataSource(ASPxComboBox combobox, string connectionString, string commandText, Int16 commandType, string displayMember, string valueMember)
        {
            bool isResult = false;
            Reports reports = new Reports();

            try
            {
                DataTable dt = reports.getQueryDataSource(connectionString, commandText, commandType == 0 ? CommandType.Text : CommandType.StoredProcedure);
                if (dt != null)
                {
                    // this.bindingSource1.DataSource = dt;
                    if (dt.Columns.Contains(displayMember) && dt.Columns.Contains(valueMember))
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            combobox.Items.Add(new ListEditItem()
                            {
                                Text = string.Format("{0}", row["displayMember"]),
                                Value = string.Format("{0}", row["valueMember"])
                            });
                        }
                        isResult = true;
                    }
                }
            }
            catch
            {
                // MessageBox.Show("参数列表查询条件错误。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isResult;
        }
    }

    public class ReportData
    {
        public string TaskType { get; set; }
        public object Data { get; set; }
    }


    public class CacheReportData
    {
        //public XtraReport XtraReport { get; set; }

        //public object DataSource { get; set; }
        public int ReportID { get; set; }

        public string QueryKey { get; set; }
    }
}