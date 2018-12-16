using Coldairarrow.Entity.Sto_BaseInfo;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Coldairarrow.Business.Sto_ProManage
{
    public class Pro_ProjectMaterielBusiness : BaseBusiness<Pro_ProjectMateriel>
    {
        #region 外部接口

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">查询类型</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public List<ProjectMaterielModel> GetDataList(string condition, string keyword, Pagination pagination)
        {
            //var q = GetIQueryable();
            var whereExpre = LinqHelper.True<ProjectMaterielModel>();

            Expression<Func<Pro_ProjectMateriel, object, ProjectMaterielModel>> selectExpre = (a, b) => new ProjectMaterielModel
            {
                UnitNameList = (List<string>)b
            };
            selectExpre = selectExpre.BuildExtendSelectExpre();

            var db_MaterialUnitMap = Service.GetIQueryable<Sto_MaterialUnit>();

            var q = from a in GetIQueryable().AsExpandable()
                    let UnitNames = db_MaterialUnitMap.Where(x => x.UnitNum == a.UnitNo).Select(x => x.Name)
                    select selectExpre.Invoke(a, UnitNames);


            //模糊查询
            if (!condition.IsNullOrEmpty() && !keyword.IsNullOrEmpty())
                q = q.Where($@"{condition}.Contains(@0)", keyword);


            return q.GetPagination(pagination).ToList();
        }

        /// <summary>
        /// 获取指定的单条数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public Pro_ProjectMateriel GetTheData(string id)
        {
            return GetEntity(id);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="newData">数据</param>
        public void AddData(MaterielParam theData)
        {
            Pro_ProjectBusiness pb = new Pro_ProjectBusiness();
            Pro_MaterialRequisitionBusiness mReqBus = new Pro_MaterialRequisitionBusiness();
            Pro_MaterialRequisitionItemBusiness mReqItemBus = new Pro_MaterialRequisitionItemBusiness();

            //检查项目是否存在
            var projects = pb.GetDataList("ProCode", theData.ProCode, new Pagination() { PageIndex = 1, PageRows = int.MaxValue });
            Pro_Project pro = projects.Find(p => p.ProCode == theData.ProCode);
            if (pro == null)
               throw new Exception($"项目编号为:{theData.ProCode}的项目不存在");

            //直接创建领料单
            this.BeginTransaction();
            mReqBus.BeginTransaction();
            mReqItemBus.BeginTransaction();
            string sql = $"SELECT 'PMR-' + convert(varchar(10),getdate(),112) + RIGHT(1000001+ISNULL(RIGHT(MAX(rtrim(PMR_No)),4),0),4) FROM Pro_MaterialRequisition WITH(XLOCK) WHERE ProCode = '{theData.ProCode}'";
            DataTable dt = mReqBus.GetDataTableWithSql(sql);
            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("创建申请单失败");
            //创建领料单
            Pro_MaterialRequisition pro_matReq = new Pro_MaterialRequisition()
            {
                Id=Guid.NewGuid().ToSequentialGuid(),
                PMR_No=$"{dt.Rows[0][0]}",
                ProCode = pro.ProCode,
                ProName = pro.ProName,
                CreateDate = DateTime.Now,
                Creator = theData.Creator,
                Picker = ""
            };
            mReqBus.Insert(pro_matReq);
            theData.MaterielList.ForEach(item =>
            {
                //工程物料
                Pro_ProjectMateriel materiel = new Pro_ProjectMateriel()
                {
                    Id = Guid.NewGuid().ToSequentialGuid(),
                    ProCode = item.ProCode,
                    GuiGe = item.GuiGe,
                    MatNo = item.MatNo,
                    MatName = item.MatName,
                    ProName = pro.ProName,
                    UnitNo = item.UnitNo,
                    PlanQuantity = item.Quantity
                };
                this.Insert(materiel);
                //申请单物料
                Pro_MaterialRequisitionItem mReqItem = new Pro_MaterialRequisitionItem() {
                    Id = Guid.NewGuid().ToSequentialGuid(),
                    MR_Id = pro_matReq.Id,
                    ProCode = item.ProCode,
                    GuiGe = item.GuiGe,
                    MatNo = item.MatNo,
                    MatName = item.MatName,
                    UnitNo = item.UnitNo,
                    Quantity = item.Quantity.Value
                };
                mReqItemBus.Insert(mReqItem);
            });
            //submit
            if (this.EndTransaction())
            {
                if (mReqBus.EndTransaction())
                {
                    mReqItemBus.EndTransaction();
                }
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public void UpdateData(Pro_ProjectMateriel theData)
        {
            Update(theData);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public string DeleteData(List<string> ids)
        {
            //如已申请领料或已领料，则不能删除
            Delete(ids);

            return "";
        }

        #endregion

        #region 私有成员

        #endregion

        #region 数据模型
        /// <summary>
        /// 物料创建数据模型
        /// </summary>
        public class MaterielParam
        {
            public string ProCode { get; set; }
            public string Creator { get; set; }
            public List<Pro_UseMateriel> MaterielList { get; set; }
        }

        #endregion
    }


    public class ProjectMaterielModel : Pro_ProjectMateriel
    {
        public List<string> UnitNameList { get; set; }
    }
}