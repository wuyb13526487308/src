using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Base_SysManage
{
    /// <summary>
    /// Base_Department
    /// </summary>
    [Table("Base_Department")]
    public class Base_Department
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// DepartNum
        /// </summary>
        public String DepartNum { get; set; }

        /// <summary>
        /// DepartName
        /// </summary>
        public String DepartName { get; set; }

        /// <summary>
        /// ChildCount
        /// </summary>
        public Int32 ChildCount { get; set; }

        /// <summary>
        /// ParentNum
        /// </summary>
        public String ParentNum { get; set; }

        /// <summary>
        /// Depth
        /// </summary>
        public Int32 Depth { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        public Int32 IsDelete { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}