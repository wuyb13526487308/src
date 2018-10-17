using Coldairarrow.Business.Cache;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Sto_ProManage
{
    public class Pro_TemplateModelCache : BaseCache<Pro_TemplateModel>
    {
        public Pro_TemplateModelCache() : base("Pro_TemplateModel", templateId =>
           {
               if (templateId.IsNullOrEmpty())
               {
                   return null;
               }
               else
               {
               return new Pro_TemplateBusiness().GetDataList("TemplateId", templateId, new Util.Pagination()).SingleOrDefault();
               }
           })
        {

        }
    }
}
