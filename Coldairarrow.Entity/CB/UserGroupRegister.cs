using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.CB
{
    /// <summary>
    /// 用户编册表,
    /// </summary>
    [Table("UserGroupRegister")]
    public class UserGroupRegister
    {

        /// <summary>
        /// 索引号 8位序号（由0~9的数字组成）
        /// </summary>
        [Key]
        public String UGR_ID { get; set; }

        /// <summary>
        /// 表册编号
        /// </summary>
        public String BookNo { get; set; }

        /// <summary>
        /// 表册名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 抄表册类型 0 双月抄表 1 单月抄表 2 按月抄表
        /// </summary>
        public Int16? TypeID { get; set; }

        /// <summary>
        /// 抄表员ID
        /// </summary>
        public String EmployeeID { get; set; }

        /// <summary>
        /// 所属部门ID
        /// </summary>
        public Int32? DepartmentID { get; set; }

        /// <summary>
        /// 创建抄表册日期
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 抄表册状态：0 正常 1 停用 2 计划
        /// </summary>
        public Int16? Status { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public String Context { get; set; }

        /// <summary>
        /// 上一次执行时间
        /// </summary>
        public DateTime? LastExecuteDate { get; set; }

        /// <summary>
        /// 下一次执行月份
        /// </summary>
        public DateTime? NextExecuteMonth { get; set; }

        /// <summary>
        /// 执行日期
        /// </summary>
        public String ExecuteDay { get; set; }

        /// <summary>
        /// 表册类型，0 民用 1 工商业 
        /// </summary>
        public String BookType { get; set; }

    }
}