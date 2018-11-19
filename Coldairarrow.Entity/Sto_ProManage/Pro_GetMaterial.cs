using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_ProManage
{
    /// <summary>
    /// Pro_GetMaterial
    /// </summary>
    [Table("Pro_GetMaterial")]
    public class Pro_GetMaterial
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
        /// GetDate
        /// </summary>
        public DateTime? GetDate { get; set; }

        /// <summary>
        /// PMR_No
        /// </summary>
        public String PMR_No { get; set; }

        /// <summary>
        /// Picker
        /// </summary>
        public String Picker { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

    }
}