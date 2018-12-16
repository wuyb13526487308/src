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
        #region �ⲿ�ӿ�

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="keyword">�ؼ���</param>
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
        public Pro_ProjectMateriel GetTheData(string id)
        {
            return GetEntity(id);
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="newData">����</param>
        public void AddData(MaterielParam theData)
        {
            Pro_ProjectBusiness pb = new Pro_ProjectBusiness();
            Pro_MaterialRequisitionBusiness mReqBus = new Pro_MaterialRequisitionBusiness();
            Pro_MaterialRequisitionItemBusiness mReqItemBus = new Pro_MaterialRequisitionItemBusiness();

            //�����Ŀ�Ƿ����
            var projects = pb.GetDataList("ProCode", theData.ProCode, new Pagination() { PageIndex = 1, PageRows = int.MaxValue });
            Pro_Project pro = projects.Find(p => p.ProCode == theData.ProCode);
            if (pro == null)
               throw new Exception($"��Ŀ���Ϊ:{theData.ProCode}����Ŀ������");

            //ֱ�Ӵ������ϵ�
            this.BeginTransaction();
            mReqBus.BeginTransaction();
            mReqItemBus.BeginTransaction();
            string sql = $"SELECT 'PMR-' + convert(varchar(10),getdate(),112) + RIGHT(1000001+ISNULL(RIGHT(MAX(rtrim(PMR_No)),4),0),4) FROM Pro_MaterialRequisition WITH(XLOCK) WHERE ProCode = '{theData.ProCode}'";
            DataTable dt = mReqBus.GetDataTableWithSql(sql);
            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("�������뵥ʧ��");
            //�������ϵ�
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
                //��������
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
                //���뵥����
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
        /// ��������
        /// </summary>
        public void UpdateData(Pro_ProjectMateriel theData)
        {
            Update(theData);
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public string DeleteData(List<string> ids)
        {
            //�����������ϻ������ϣ�����ɾ��
            Delete(ids);

            return "";
        }

        #endregion

        #region ˽�г�Ա

        #endregion

        #region ����ģ��
        /// <summary>
        /// ���ϴ�������ģ��
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