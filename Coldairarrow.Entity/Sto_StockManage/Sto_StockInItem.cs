using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_StockManage
{
    /// <summary>
    /// Sto_StockInItem
    /// </summary>
    [Table("Sto_StockInItem")]
    public class Sto_StockInItem
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
        /// MatNo
        /// </summary>
        public String MatNo { get; set; }

        /// <summary>
        /// MatName
        /// </summary>
        public String MatName { get; set; }

        /// <summary>
        /// GuiGe
        /// </summary>
        public String GuiGe { get; set; }

        /// <summary>
        /// UnitNo
        /// </summary>
        public String UnitNo { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public Decimal? Price { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public Decimal Quantity { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

        /// <summary>
        /// BigClass
        /// </summary>
        public String BigClass { get; set; }

    }
}