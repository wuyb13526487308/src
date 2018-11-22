using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_StockManage
{
    /// <summary>
    /// Sto_StockSettlementItem
    /// </summary>
    [Table("Sto_StockSettlementItem")]
    public class Sto_StockSettlementItem
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
        /// StoreId
        /// </summary>
        public String StoreId { get; set; }

        /// <summary>
        /// MatNo
        /// </summary>
        public String MatNo { get; set; }

        /// <summary>
        /// GuiGe
        /// </summary>
        public String GuiGe { get; set; }

        /// <summary>
        /// UnitNo
        /// </summary>
        public String UnitNo { get; set; }

        /// <summary>
        /// B_Price
        /// </summary>
        public DateTime B_Price { get; set; }

        /// <summary>
        /// B_Quantity
        /// </summary>
        public Decimal B_Quantity { get; set; }

        /// <summary>
        /// UpToTime
        /// </summary>
        public DateTime UpToTime { get; set; }

        /// <summary>
        /// E_Quantity
        /// </summary>
        public DateTime E_Quantity { get; set; }

        /// <summary>
        /// E_Price
        /// </summary>
        public Decimal E_Price { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

    }
}