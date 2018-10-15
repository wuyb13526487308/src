using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Base_SysManage
{
    /// <summary>
    /// 用户部门映射表
    /// </summary>
    [Table("Base_UserDepartmentMap")]
    public class Base_UserDepartmentMap
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public String UserId { get; set; }

        /// <summary>
        /// DepartmentId
        /// </summary>
        public String DepartmentId { get; set; }

    }
}