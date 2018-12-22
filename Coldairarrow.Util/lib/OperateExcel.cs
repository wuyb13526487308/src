using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Aspose.Cells;

namespace Coldairarrow.Util.lib
{
    public class OperateExcel
    {
        /// 导出的文件保存到这里
        //private static string ExportFilesPath = System.Configuration.ConfigurationManager.AppSettings["exportFilesPath"].ToString();
        /// 将DataTable生成Excel
        public static void ExportToExcel(HttpContext context, DataTable dtList, string fileName)
        {
            string path = context.Request.MapPath("/")+@"\temp\";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            ////这里是利用Aspose.Cells.dll 生成excel文件的
            //string pathToFiles = System.Web.HttpContext.Current.Server.MapPath(ExportFilesPath);
            string etsName = $"{fileName}.xls";
            ////获取保存路径
            string pathToFiles = path + etsName;
            Workbook wb = new Workbook();
            Worksheet ws = wb.Worksheets[0];
            Cells cell = ws.Cells;
            //设置行高
            //cell.SetRowHeight(0, 20);
            //表头样式
            Style stHeadLeft = wb.Styles[wb.Styles.Add()];
            stHeadLeft.HorizontalAlignment = TextAlignmentType.Left;       //文字居中
            stHeadLeft.Font.Name = "宋体";
            stHeadLeft.Font.IsBold = true;                                 //设置粗体
            stHeadLeft.Font.Size = 14;                                     //设置字体大小
            Style stHeadRight = wb.Styles[wb.Styles.Add()];
            stHeadRight.HorizontalAlignment = TextAlignmentType.Right;       //文字居中
            stHeadRight.Font.Name = "宋体";
            stHeadRight.Font.IsBold = true;                                  //设置粗体
            stHeadRight.Font.Size = 14;                                      //设置字体大小
            //内容样式
            Style stContentLeft = wb.Styles[wb.Styles.Add()];
            stContentLeft.HorizontalAlignment = TextAlignmentType.Left;
            stContentLeft.Font.Size = 10;
            Style stContentRight = wb.Styles[wb.Styles.Add()];
            stContentRight.HorizontalAlignment = TextAlignmentType.Right;
            stContentRight.Font.Size = 10;
            //赋值给Excel内容
            for (int col = 0; col < dtList.Columns.Count; col++)
            {
                Style stHead = null;
                Style stContent = null;
                //设置表头
                string columnType = dtList.Columns[col].DataType.ToString();
                switch (columnType.ToLower())
                {
                    //如果类型是string，则靠左对齐(对齐方式看项目需求修改)
                    case "system.string":
                        stHead = stHeadLeft;
                        stContent = stContentLeft;
                        break;
                    default:
                        stHead = stHeadRight;
                        stContent = stContentRight;
                        break;
                }
                putValue(cell, dtList.Columns[col].ColumnName, 0, col, stHead);
                for (int row = 0; row < dtList.Rows.Count; row++)
                {
                    putValue(cell, dtList.Rows[row][col], row + 1, col, stContent);
                }
            }
            wb.Save(pathToFiles);
            Load(context, pathToFiles);
            File.Delete(pathToFiles);
        }

        //填充数据到excel中
        private static void putValue(Cells cell, object value, int row, int column, Style st)
        {
            cell[row, column].PutValue(value);
            cell[row, column].SetStyle(st);
        }

        public static void Load(HttpContext context, string filePath)
        {
            Encoding encoding;
            string outputFileName = System.IO.Path.GetFileName(filePath);
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            string browser = context.Request.UserAgent.ToUpper();
            if (browser.Contains("MS") == true && browser.Contains("IE") == true)
            {
                encoding = Encoding.Default;
            }
            else if (browser.Contains("FIREFOX") == true)
            {
                encoding = Encoding.GetEncoding("GB2312");
            }
            else
            {
                encoding = Encoding.Default;
            }
            context.Response.Charset = "UTF-8";
            context.Response.ContentType = "application/octet-stream";
            context.Response.ContentEncoding = encoding;
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + outputFileName);
            context.Response.BinaryWrite(bytes);
            context.Response.Flush();
            context.Response.End();
        }
    }
}
