using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Coldairarrow.Business.Sto_ProManage
{
    public class Pro_TemplateBusiness : BaseBusiness<Pro_Template>
    {
        static Pro_TemplateModelCache _cache { get; } = new Pro_TemplateModelCache();
        static Pro_TemplateItemBusiness _tib { get; } = new Pro_TemplateItemBusiness();
        #region �ⲿ�ӿ�

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="keyword">�ؼ���</param>
        /// <returns></returns>
        public List<Pro_TemplateModel> GetDataList(string condition, string keyword, Pagination pagination)
        {
            var whereExpre = LinqHelper.True<Pro_TemplateModel>();
            Expression<Func<Pro_Template, object, Pro_TemplateModel>> selectExpre = (a, b) => new Pro_TemplateModel
            {
                TemplateItemList = (List<Pro_TemplateItem>)b,
            };
            selectExpre = selectExpre.BuildExtendSelectExpre();
            var db_Sto_TemplateItem = Service.GetIQueryable<Pro_TemplateItem>();

            //var db_Sto_MaterialUnit = Service.GetIQueryable<Sto_MaterialUnit>();
            var q = from a in GetIQueryable().AsExpandable()
                    let templateItems = db_Sto_TemplateItem.Where(x => x.TemplateId == a.TemplateId).ToList()
                    select selectExpre.Invoke(a, templateItems);


            //var q = GetIQueryable();

            //ģ����ѯ
            if (!condition.IsNullOrEmpty() && !keyword.IsNullOrEmpty())
                q = q.Where($@"{condition}.Contains(@0)", keyword);

            return q.GetPagination(pagination).ToList();
        }

        /// <summary>
        /// ��ȡָ���ĵ�������
        /// </summary>
        /// <param name="id">����</param>
        /// <returns></returns>
        public Pro_TemplateModel GetTheData(string id)
        {
            Pro_TemplateModel theData= _cache.GetCache(id);
            if (theData == null)
            { 
                //������û���ҵ�����ѯ���ݿ�                
                Pro_Template template = this.GetEntity(id);
                if (template == null)
                {
                    return null;
                }
                theData = new Pro_TemplateModel(template);
                List<Pro_TemplateItem> list = _tib.GetDataList("TemplateId", template.Id, new Pagination() { PageIndex = 1, PageRows = int.MaxValue });
                theData.TemplateItemList = list; 
            }
            return theData;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="newData">����</param>
        public void AddData(Pro_TemplateModel newData)
        {
            this.BeginTransaction();
            Pro_TemplateItemBusiness templateItemBus = new Pro_TemplateItemBusiness();
            Pro_Template template = new Pro_Template()
            {
                Id = newData.Id,
                TemplateId = newData.TemplateId,
                TemplateName = newData.TemplateName,
                TemplateType = newData.TemplateType,
                LastOperator = newData.LastOperator,
                LastTime = DateTime.Now,
                Context = newData.Context
            };
            Insert(template);
            templateItemBus.BeginTransaction();
            foreach (Pro_TemplateItem item in newData.TemplateItemList) {
                item.TemplateId = template.Id;
                item.Id = Guid.NewGuid().ToSequentialGuid();
                templateItemBus.Insert(item);
            };
            if (templateItemBus.EndTransaction())
            {
                this.EndTransaction();
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void UpdateData(Pro_TemplateModel theData)
        {
            this.BeginTransaction();
            Pro_Template template = new Pro_Template()
            {
                Id = theData.Id,
                TemplateId = theData.TemplateId,
                TemplateName = theData.TemplateName,
                TemplateType = theData.TemplateType,
                LastOperator = theData.LastOperator,
                LastTime = DateTime.Now,
                Context = theData.Context
            };
            _tib.BeginTransaction();
            List<Pro_TemplateItem> list = _tib.GetDataList("TemplateId", template.Id, new Pagination() { PageIndex = 1, PageRows = int.MaxValue });
            var listIds = from p in list select p.Id;
            _tib.DeleteData(listIds.ToList());
            foreach (Pro_TemplateItem item in theData.TemplateItemList)
            {
                item.TemplateId = template.Id;
                item.Id = Guid.NewGuid().ToSequentialGuid();
                _tib.Insert(item);
            };
            Update(template);
            if (_tib.EndTransaction())
            {
                this.EndTransaction();
            }
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public void DeleteData(List<string> ids)
        {
            Delete(ids);
        }

        #endregion

        #region ˽�г�Ա

        #endregion

        #region ����ģ��

        #endregion
    }

    public class Pro_TemplateModel : Pro_Template
    {

        public List<Pro_TemplateItem> TemplateItemList { get; set; } = new List<Pro_TemplateItem>();

        public Pro_TemplateModel()
        {
        }
        public Pro_TemplateModel(Pro_Template template)
        {
            this.Id = template.Id;
            this.TemplateId = template.TemplateId;
            this.TemplateName = template.TemplateName;
            this.TemplateType = template.TemplateType;
            this.LastOperator = template.LastOperator;
            this.LastTime = template.LastTime;
        }
    } 

}