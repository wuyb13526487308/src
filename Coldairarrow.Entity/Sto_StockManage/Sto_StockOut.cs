using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_StockManage
{
    /// <summary>
    /// Sto_StockOut
    /// </summary>
    [Table("Sto_StockOut")]
    public class Sto_StockOut
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// OutNo
        /// </summary>
        public String OutNo { get; set; }

        /// <summary>
        /// OutDate
        /// </summary>
        public DateTime OutDate { get; set; }

        /// <summary>
        /// OutOperID
        /// </summary>
        public String OutOperID { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

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

    }
}