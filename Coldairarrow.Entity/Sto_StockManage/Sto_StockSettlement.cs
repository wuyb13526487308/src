using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_StockManage
{
    /// <summary>
    /// Sto_StockSettlement
    /// </summary>
    [Table("Sto_StockSettlement")]
    public class Sto_StockSettlement
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// SettNo
        /// </summary>
        public String SettNo { get; set; }

        /// <summary>
        /// SettleDate
        /// </summary>
        public DateTime SettleDate { get; set; }

        /// <summary>
        /// OperName
        /// </summary>
        public String OperName { get; set; }

        /// <summary>
        /// SettType
        /// </summary>
        public Boolean? SettType { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

    }
}