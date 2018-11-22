using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_StockManage
{
    /// <summary>
    /// Sto_Stock
    /// </summary>
    [Table("Sto_Stock")]
    public class Sto_Stock
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// StoreId
        /// </summary>
        public String StoreId { get; set; }

        /// <summary>
        /// StoreUnitId
        /// </summary>
        public String StoreUnitId { get; set; }

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
        /// Quantity
        /// </summary>
        public Decimal? Quantity { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public String Price { get; set; }

        /// <summary>
        /// UpToTime
        /// </summary>
        public DateTime? UpToTime { get; set; }

    }
}