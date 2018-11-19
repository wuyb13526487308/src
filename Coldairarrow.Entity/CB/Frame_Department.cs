using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.CB
{
    /// <summary>
    /// Frame_Department
    /// </summary>
    [Table("Frame_Department")]
    public class Frame_Department
    {

        /// <summary>
        /// DepartmentID
        /// </summary>
        [Key]
        public Int32 DepartmentID { get; set; }

        /// <summary>
        /// RootID
        /// </summary>
        public Int32? RootID { get; set; }

        /// <summary>
        /// DepartmentName
        /// </summary>
        public String DepartmentName { get; set; }

        /// <summary>
        /// Telephone
        /// </summary>
        public String Telephone { get; set; }

        /// <summary>
        /// bm_id
        /// </summary>
        public String bm_id { get; set; }

    }
}