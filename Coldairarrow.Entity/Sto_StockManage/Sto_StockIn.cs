using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_StockManage
{
    /// <summary>
    /// Sto_StockIn
    /// </summary>
    [Table("Sto_StockIn")]
    public class Sto_StockIn
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// InNo
        /// </summary>
        public String InNo { get; set; }

        /// <summary>
        /// InDate
        /// </summary>
        public DateTime InDate { get; set; }

        /// <summary>
        /// InOperID
        /// </summary>
        public String InOperID { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public Int16? State { get; set; } = 0;

        /// <summary>
        /// Auditor
        /// </summary>
        public String Auditor { get; set; }

        /// <summary>
        /// AuditDate
        /// </summary>
        public DateTime? AuditDate { get; set; }

        /// <summary>
        /// StoreId
        /// </summary>
        public String StoreId { get; set; }

        /// <summary>
        /// 入库类型，0 采购 1 退料 2 期初
        /// </summary>
        public Int16? InType { get; set; } = 0;

    }
}