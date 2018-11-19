using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_ProManage
{
    /// <summary>
    /// Pro_UseMateriel
    /// </summary>
    [Table("Pro_UseMateriel")]
    public class Pro_UseMateriel
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
        /// UseDate
        /// </summary>
        public DateTime? UseDate { get; set; }

        /// <summary>
        /// RegDate
        /// </summary>
        public DateTime? RegDate { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public String Creator { get; set; }

    }
}