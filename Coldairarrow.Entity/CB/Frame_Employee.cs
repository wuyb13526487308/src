using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.CB
{
    /// <summary>
    /// Frame_Employee
    /// </summary>
    [Table("Frame_Employee")]
    public class Frame_Employee
    {

        /// <summary>
        /// EmployeeID
        /// </summary>
        [Key]
        public String EmployeeID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Pwd
        /// </summary>
        public String Pwd { get; set; }

        /// <summary>
        /// DepartmentID
        /// </summary>
        public Int32? DepartmentID { get; set; }

        /// <summary>
        /// Telephone
        /// </summary>
        public String Telephone { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        /// RoleID
        /// </summary>
        public Int32? RoleID { get; set; }

    }
}