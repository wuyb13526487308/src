using Coldairarrow.DataRepository;
using Coldairarrow.Entity.Sto_StockManage;
using Coldairarrow.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Coldairarrow.Business.Sto_StockManage
{
    public class Sto_StockBusiness : BaseBusiness<Sto_Stock>
    {
        #region �ⲿ�ӿ�

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="condition">��ѯ����</param>

        /// <returns></returns>
        public List<Stock> GetDataList(string condition,Pagination pagination)
        {
            //�ڳ����
            var q = GetIQueryable();
            if (condition.IsNullOrEmpty())
            {
                condition = "";
            }

            List<Stock> list = this.GetListBySql<Stock>("exec SP_Stock");

           QueryCondition obj = condition.ToObject<QueryCondition>();
           if (!condition.IsNullOrEmpty())
            {
                if (obj != null)
                {
                    if (!obj.StoreId.IsNullOrEmpty())
                    {

                        list = list.Where(p => p.StoreId == obj.StoreId).ToList();
                    }
                    if (!obj.BigClass.IsNullOrEmpty())
                    {
                        list = list.Where(p => p.BigClass == obj.BigClass).ToList();
                    }

                    if (!obj.UnitNo.IsNullOrEmpty()){
                        list = list.Where(p => p.UnitNo.Contains( obj.UnitNo)).ToList();
                    }

                    if (!obj.MatNo.IsNullOrEmpty())
                    {
                        list = list.Where(p => p.MatNo == obj.MatNo).ToList();
                    }                    
                }
            }
            //List.Skip((pagecount - 1) * pagesize).Take(pagesize)
            int pageSize = pagination.PageRows;
            int pageIndex = pagination.PageIndex;
            pagination.RecordCount = list.Count;

            return list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            //return q.GetPagination(pagination).ToList();
        }

        /// <summary>
        /// ��ȡָ���ĵ�������
        /// </summary>
        /// <param name="id">����</param>
        /// <returns></returns>
        public Sto_Stock GetTheData(string id)
        {
            return GetEntity(id);
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="newData">����</param>
        public void AddData(Sto_Stock newData)
        {
            Insert(newData);
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void UpdateData(Sto_Stock theData)
        {
            Update(theData);
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
        class QueryCondition
        {
            //{StoreId:value1,BigClass:value2,GuiGe:value3,UnitNo:value4,MatNo:value5}
            public string StoreId { get; set; }
            public string BigClass { get; set; }
            public string GuiGe { get; set; }
            public string UnitNo { get; set; }
            public string MatNo { get; set; }
        }

        public class Stock 
        {
            /// <summary>
            /// StoreId
            /// </summary>
            public String StoreId { get; set; }

            /// <summary>
            /// StoreUnitId
            /// </summary>
            public String StoreUnitId { get; set; }

            /// <summary>
            /// MatNo
            /// </summary>
            public String MatNo { get; set; }

            /// <summary>
            /// MatName
            /// </summary>
            public String MatName { get; set; }

            /// <summary>
            /// GuiGe
            /// </summary>
            public String GuiGe { get; set; }

            /// <summary>
            /// UnitNo
            /// </summary>
            public String UnitNo { get; set; }

            /// <summary>
            /// Quantity
            /// </summary>
            public Decimal? Quantity { get; set; }

            /// <summary>
            /// Price
            /// </summary>
            public Decimal? Price { get; set; }

            /// <summary>
            /// BigClass
            /// </summary>
            public String BigClass { get; set; }
        }
        #endregion
    }
}