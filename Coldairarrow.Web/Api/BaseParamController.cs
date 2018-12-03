using Coldairarrow.Business.Sto_BaseInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Coldairarrow.Web.Api
{
    public class BaseParamController : ApiController
    {
        /// <summary>
        /// 查询系统基本参数列表，包括：仓库、物料大类、物料规格、物料单位
        /// </summary>
        /// <param name="paramType">store 仓库 bigClass 物料大类 guiGe 物料规格 unit 物料单位</param>
        /// <returns></returns>
        [Route("base/getparam")]
        public HttpResponseMessage GetParam(string paramType)
        {
            string temp = JsonConvert.SerializeObject(new BaseParmBusiness().GetParam(paramType));
            return new HttpResponseMessage { Content = new StringContent(temp, System.Text.Encoding.UTF8, "application/json") };
        }


    }
}