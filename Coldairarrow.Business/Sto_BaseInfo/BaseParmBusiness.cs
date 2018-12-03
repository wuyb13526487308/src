using Coldairarrow.DataRepository;
using Coldairarrow.Entity.Sto_BaseInfo;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Sto_BaseInfo
{
    public class BaseParmBusiness
    {
        /// <summary>
        /// 仓库
        /// </summary>
        private const string STORE_CLASS = "STORE";
        /// <summary>
        /// 物料大类
        /// </summary>
        private const string BIGCLASS_CLASS = "BIGCLASS";
        /// <summary>
        /// 物料规格
        /// </summary>
        private const string GUIGE_CALSS = "GUIGE";
        /// <summary>
        /// 物料单位
        /// </summary>
        private const string UNIT_CLASS = "UNIT";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramType">store 仓库 bigClass 物料大类 guiGe 物料规格 unit 物料单位</param>
        /// <returns></returns>
        public List<BaseParam> GetParam(string paramType)
        {
            List<BaseParam> list = new List<BaseParam>();
            switch (paramType.ToUpper())
            {
                case STORE_CLASS:
                    list = getStoreList();
                    break;
                case BIGCLASS_CLASS:
                    list = getBigClass();
                    break;
                case UNIT_CLASS:
                    list = getUnit();
                    break;
            }

            return list;             
        }

        private List<BaseParam> getStoreList()
        {
            var db = DbFactory.GetRepository();
            var query = from a in db.GetIQueryable<Sto_Storage>()
                        select new BaseParam()
                        {
                            Id = a.Id,
                            Code = a.StoreNo,
                            Name = a.StoreName
                        };

            return query.ToList();
        }

        private List<BaseParam> getBigClass()
        {
            var db = DbFactory.GetRepository();
            //var where = LinqHelper.True<BaseParam>();
            //Expression<Func<Sto_BigClass, BaseParam>> select = (a) => new BaseParam
            //{
            //    Id = a.Id,
            //    Code = a.BigClassCode,
            //    Name = a.BigClassName
            //};

            var query = from p in db.GetIQueryable<Sto_BigClass>()
                        select new BaseParam() { Id = p.Id, Code = p.BigClassCode, Name = p.BigClassName };


            return query.ToList();
        }

        private List<BaseParam> getUnit()
        {
            var db = DbFactory.GetRepository();

            var query = from a in db.GetIQueryable<Sto_MaterialUnit>()
                        select new BaseParam
                        {
                            Id = a.Id,
                            Code = a.UnitNum,
                            Name = a.Name
                        };

            return query.ToList();
        }
    }


    public class BaseParam
    {
        [Key]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
