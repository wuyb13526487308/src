using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_ProManage
{
    /// <summary>
    /// Pro_Project
    /// </summary>
    [Table("Pro_Project")]
    public class Pro_Project
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// ProCode
        /// </summary>
        public String ProCode { get; set; }

        /// <summary>
        /// ProName
        /// </summary>
        public String ProName { get; set; }

        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public String Creator { get; set; }

        /// <summary>
        /// ProAddress
        /// </summary>
        public String ProAddress { get; set; }

        /// <summary>
        /// ProLeader
        /// </summary>
        public String ProLeader { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public String Status { get; set; }

    }
}