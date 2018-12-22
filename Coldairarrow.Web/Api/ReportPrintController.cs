using Coldairarrow.Business.Sto_StockManage;
using Coldairarrow.Util;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Coldairarrow.Web.Api
{
    public class ReportPrintController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        [Route("base/report")]
        public HttpResponseMessage GetReport(string type,string key)
        {
            int reportID = 1;

            //Sto_StockOutBusiness stockOutBs = new Sto_StockOutBusiness();
            //StockOutModel stockData = stockOutBs.GetStockOut(key);
            //*****************************
            //这里可以设计为从数据库参数中查询
            if (type == "IN_TICKET")
            {
                reportID = 1;
            }
            else if (type == "OUT_TICKET")
            {
                reportID = 2;
            }
            else if (type == "RG_TICKET")
            {
                reportID = 3;
            }
            //*****************************

            string rootUrl = System.Configuration.ConfigurationManager.AppSettings["ReportServer"];
            var client = new RestClient(rootUrl);
            var request = new RestRequest($"printviewHandler.ashx?r={reportID}&key={key}", Method.POST);
            //request.AddParameter("data",stockData.ToJson());
            IRestResponse response = client.Execute(request);
            string temp = "";// JsonConvert.SerializeObject(new { Success = true, Msg = type, Data = "http://report.zzlihong.cn/reportview.aspx?id=1" });

            if (!response.IsSuccessful)
            {
                temp = JsonConvert.SerializeObject(new { Success = true, Msg = "支付完成接口调用失败", Data = "" }); 
            }
            else
            {
                var content = response.Content; // raw content as string
                AjaxResult _outData = JsonConvert.DeserializeObject<AjaxResult>(content);
                temp = JsonConvert.SerializeObject(new { Success = true, Msg = "", Data = $"{_outData.Data}" });
            }
            return new HttpResponseMessage { Content = new StringContent(temp, System.Text.Encoding.UTF8, "application/json") };
        }


    }
}