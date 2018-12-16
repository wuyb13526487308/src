<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintReportView.aspx.cs" Inherits="LH.ReportWeb.PrintReportView" %>


<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="lib/themes/default/easyui.css">
    <link rel="stylesheet" type="text/css" href="lib/themes/icon.css">
    <link rel="stylesheet" type="text/css" href="lib/themes/color.css">
    <link rel="stylesheet" type="text/css" href="lib/demo/demo.css">

    <script type="text/javascript" src="lib/jquery.min.js"></script>
    <script type="text/javascript" src="lib/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="lib/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="lib/plugins/jquery.validatebox.js"></script>


    <link rel="stylesheet" type="text/css" href="../css/index.css" />
    <script type="text/javascript" src="../js/Base.js"></script>
    <style type="text/css">
        #divQuery{
            position :absolute ;

        }
    </style>
    <script>
        //SH.MainGridHeight = $(window).height() * 0.99+10;
        function boxheight() { //函数：获取尺寸
            $('#layout').layout({
                height: $(window).height() * 0.99-40
            }); 
        }

        $(function () {

            boxheight(); //执行函数 
            window.onresize = boxheight; //窗口或框架被调整大小时执行

        });
      
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div id="layout" class="easyui-layout" style="width:100%;height:520px;">
            <div data-options="region:'center',iconCls:'icon-ok'" title="">
                <dx:ReportToolbar ID="ReportToolbar1" runat="server" ShowDefaultButtons="False" ReportViewerID="ReportViewer1">
                <Items>
                    <dx:ReportToolbarButton ItemKind="Search" />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind="PrintReport" />
                    <dx:ReportToolbarButton ItemKind="PrintPage" />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton Enabled="False" ItemKind="FirstPage" />
                    <dx:ReportToolbarButton Enabled="False" ItemKind="PreviousPage" />
                    <dx:ReportToolbarLabel ItemKind="PageLabel" />
                    <dx:ReportToolbarComboBox ItemKind="PageNumber" Width="65px">
                    </dx:ReportToolbarComboBox>
                    <dx:ReportToolbarLabel ItemKind="OfLabel" />
                    <dx:ReportToolbarTextBox ItemKind="PageCount" />
                    <dx:ReportToolbarButton ItemKind="NextPage" />
                    <dx:ReportToolbarButton ItemKind="LastPage" />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind="SaveToDisk" />
                    <dx:ReportToolbarButton ItemKind="SaveToWindow" />
                    <dx:ReportToolbarComboBox ItemKind="SaveFormat" Width="70px">
                        <Elements>
                            <dx:ListElement Value="xls" />
                            <dx:ListElement Value="xlsx" />
                            <dx:ListElement Value="pdf" />
                            <dx:ListElement Value="png" />
                        </Elements>
                    </dx:ReportToolbarComboBox>
                </Items>
                <Styles>
                    <LabelStyle>
                        <Margins MarginLeft='2px' MarginRight='2px' />
                    </LabelStyle>
                </Styles>
            </dx:ReportToolbar>
            <dx:ReportViewer ID="ReportViewer1" runat="server">
                </dx:ReportViewer>

            </div>
        </div>
    </form>
</body>
</html>
