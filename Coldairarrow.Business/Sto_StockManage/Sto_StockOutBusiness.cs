using Coldairarrow.Business.Base_SysManage;
using Coldairarrow.Business.Sto_ProManage;
using Coldairarrow.DataRepository;
using Coldairarrow.Entity.Sto_BaseInfo;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Entity.Sto_StockManage;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Coldairarrow.Business.Sto_StockManage
{
    public class Sto_StockOutBusiness : BaseBusiness<Sto_StockOut>
    {
        Sto_StockOutItemBusiness _stockOutItemBus = new Sto_StockOutItemBusiness();

        #region �ⲿ�ӿ�

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="keyword">�ؼ���</param>
        /// <returns></returns>
        public List<StockOutModel> GetDataList(string condition, string keyword, Pagination pagination)
        {
            //var q = GetIQueryable();
            var whereExpre = LinqHelper.True<StockOutModel>();

            Expression<Func<Sto_StockOut, object, StockOutModel>> selectExpre = (a, b) => new StockOutModel
            {
                StoreName = (List<string>)b
            };
            selectExpre = selectExpre.BuildExtendSelectExpre();

            var db_MaterialUnitMap = Service.GetIQueryable<Sto_Storage>();

            var q = from a in GetIQueryable().AsExpandable()
                    let UnitNames = db_MaterialUnitMap.Where(x => x.StoreNo == a.StoreId).Select(x => x.StoreName)
                    select selectExpre.Invoke(a, UnitNames);

            //ģ����ѯ
            if (!condition.IsNullOrEmpty() && !keyword.IsNullOrEmpty())
                q = q.Where($@"{condition}.Contains(@0)", keyword);

            return q.GetPagination(pagination).ToList();
        }
        /// <summary>
        /// ��ѯ������ϸ
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="keyword"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<StockOutListItem> GetStockOutList(string StoreId, string OutNo, string B_OutDate, string E_OutDate, Pagination pagination)
        {
            var q = GetIQueryable();
            var db = DbFactory.GetRepository();

            var where = LinqHelper.True<StockOutListItem>();
            Expression<Func< Sto_StockOutItem,Sto_StockOut, Sto_Storage, Sto_MaterialUnit, StockOutListItem>> select = (a, b, c,d) => new StockOutListItem
            {
                Id=a.Id,
                ApplyNo = b.ApplyNo,
                AuditDate = b.AuditDate,
                Auditor = b.Auditor,
                Context = b.Context,
                OutNo = b.OutNo,
                OutDate = b.OutDate,
                OutOperID = b.OutOperID,
                OutType = b.OutType,
                MatName = a.MatName,
                MatNo = a.MatNo,
                GuiGe = a.GuiGe,
                Price = a.Price,
                Quantity = a.Quantity,
                UnitNo = a.UnitNo,
                StoreId = c.StoreNo,
                StoreName = c.StoreName,
                UnitName = d.Name
            };
            select = select.BuildExtendSelectExpre();

            /*
               var q = from a in db.GetIQueryable<Dev_Project>().AsExpandable()
                    join b in db.GetIQueryable<Dev_ProjectType>() on a.ProjectTypeId equals b.ProjectTypeId into ab
                    from b in ab.DefaultIfEmpty()
                    join c in db.GetIQueryable<Base_User>() on a.ProjectManagerId equals c.UserId into ac
                    from c in ac.DefaultIfEmpty()
                    select @select.Invoke(a, b, c);
             */

            var db_MaterialUnitMap = Service.GetIQueryable<Sto_MaterialUnit>();

            var query = from a in db.GetIQueryable<Sto_StockOutItem>().AsExpandable()
                        join b in db.GetIQueryable<Sto_StockOut>() on a.OutNo equals b.OutNo into ab
                        from b in ab.DefaultIfEmpty()
                        join c in db.GetIQueryable<Sto_Storage>() on b.StoreId equals c.StoreNo into ac
                        from c in ac.DefaultIfEmpty()
                        join d in db.GetIQueryable<Sto_MaterialUnit>() on a.UnitNo equals d.UnitNum into ad
                        from d in ad.DefaultIfEmpty()
                        select @select.Invoke(a, b, c, d);

            //if (!projectName.IsNullOrEmpty())
            //    where = where.And(x => x.ProjectName.Contains(projectName));

            //ģ����ѯ
            if (!StoreId.IsNullOrEmpty())
            {
                query = query.Where(p => p.StoreId == StoreId);
            }
            if (!OutNo.IsNullOrEmpty())
            {
                query = query.Where(p => p.OutNo.Contains(OutNo));
            }
            if (!B_OutDate.IsNullOrEmpty())
            {
                DateTime bDate = Convert.ToDateTime(B_OutDate);
                where = where.And(x => x.OutDate >= bDate);
            }

            if (!E_OutDate.IsNullOrEmpty())
            {
                DateTime eDate = Convert.ToDateTime(E_OutDate);
                query = query.Where(p => p.OutDate <= eDate);
            }
            return query.Where(where).GetPagination(pagination).ToList();
        }
        /// <summary>
        /// ��ȡָ���ĵ�������
        /// </summary>
        /// <param name="id">����</param>
        /// <returns></returns>
        public StockOutModel GetStockOut(string id)
        {
            Sto_StockOut stockOut =  GetEntity(id);
            if (stockOut == null) return new StockOutModel ();
            StockOutModel theData = stockOut.ToJson().ToObject<StockOutModel>();
            theData.StockOutItems = this._stockOutItemBus.GetIQueryable().Where(p => p.OutNo == theData.OutNo).ToList();
            return theData;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="newData">����</param>
        public void AddData(Sto_StockOut newData)
        {
            Insert(newData);
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void UpdateData(Sto_StockOut theData)
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

        /// <summary>
        /// �������ϵ�����
        /// </summary>
        /// <param name="theData"></param>
        public void ProMaterial(StockOutModel theData,string Picker,string ProCode,string ProName)
        {
            Pro_GetMaterialBusiness _getMeterialBus = new Pro_GetMaterialBusiness();
            Pro_MaterialRequisitionBusiness _mrb = new Pro_MaterialRequisitionBusiness();
            //����Ƿ�����
            var query = _mrb.GetIQueryable().Where(p => p.PMR_No == theData.ApplyNo).SingleOrDefault();

            if (query.Status ==2)
            {
                throw new Exception("������");
            }
            //if (query.Status == 0)
            //{
            //    throw new Exception("δ����");
            //}
            if (query.Status == 3)
            {
                throw new Exception("������");
            }

            Sto_StockOut stockOut = theData.ToJson().ToObject<Sto_StockOut>();

            this.BeginTransaction();
            this._stockOutItemBus.BeginTransaction();
            _getMeterialBus.BeginTransaction();
            this.Insert(stockOut);
            foreach (Sto_StockOutItem item in theData.StockOutItems) {

                this._stockOutItemBus.Insert(item);
                Pro_GetMaterial getMaterial = new Pro_GetMaterial()
                {
                    Id = Guid.NewGuid().ToSequentialGuid(),
                    PMR_No = theData.ApplyNo,
                    GetDate = DateTime.Now,
                    GuiGe = item.GuiGe,
                    MatName = item.MatName,
                    MatNo = item.MatNo,
                    Context = stockOut.Context,
                    ProCode = ProCode,
                    ProName = ProName,
                    UnitNo = item.UnitNo,
                    Quantity = item.Quantity,
                    Picker = Picker
                };
                _getMeterialBus.Insert(getMaterial);
            }
            if (this.EndTransaction())
            {
                if (!this._stockOutItemBus.EndTransaction())
                {
                    this.Delete(stockOut.Id);
                    throw new Exception("����ʧ��");
                }
                else
                {
                    //����ɹ����������ϵ�״̬
                    _getMeterialBus.EndTransaction();
                    _mrb.UpdateWhere(p => p.PMR_No == theData.ApplyNo, item => item.Status = 2);
                    _mrb.UpdateWhere(p => p.PMR_No == theData.ApplyNo, item => item.Picker = Picker);
                }
            }
            else
            {
                throw new Exception("����ʧ��");
            }
        }

        #region ˽�г�Ա

        #endregion

        #region ����ģ��

        #endregion
    }

    public class StockOutModel : Sto_StockOut
    {
        public List<Sto_StockOutItem> StockOutItems { get; set; } = new List<Sto_StockOutItem>();
        public List<string> StoreName { get; set; }
    }


    public class StockOutListItem : Sto_StockOutItem
    {
        //[Key]
        //public String Id { get; set; }
        ///// <summary>
        ///// OutNo
        ///// </summary>
        //public String OutNo { get; set; }

        /// <summary>
        /// OutDate
        /// </summary>
        public DateTime OutDate { get; set; }

        /// <summary>
        /// OutOperID
        /// </summary>
        public String OutOperID { get; set; }

        ///// <summary>
        ///// Context
        ///// </summary>
        //public String Context { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public Int16 State { get; set; }

        /// <summary>
        /// Auditor
        /// </summary>
        public String Auditor { get; set; }

        /// <summary>
        /// AuditDate
        /// </summary>
        public DateTime? AuditDate { get; set; }

        /// <summary>
        /// OutType
        /// </summary>
        public Int16? OutType { get; set; }

        /// <summary>
        /// ApplyNo
        /// </summary>
        public String ApplyNo { get; set; }

        /// <summary>
        /// StoreId
        /// </summary>
        public String StoreId { get; set; }

        public string StoreName { get; set; }

        ///// <summary>
        ///// MatNo
        ///// </summary>
        //public String MatNo { get; set; }

        ///// <summary>
        ///// MatName
        ///// </summary>
        //public String MatName { get; set; }

        ///// <summary>
        ///// GuiGe
        ///// </summary>
        //public String GuiGe { get; set; }

        ///// <summary>
        ///// UnitNo
        ///// </summary>
        //public String UnitNo { get; set; }

        public string UnitName { get; set; }

        ///// <summary>
        ///// Price
        ///// </summary>
        //public String Price { get; set; }

        ///// <summary>
        ///// Quantity
        ///// </summary>
        //public Decimal? Quantity { get; set; }
    }

}