using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_ProManage
{
    /// <summary>
    /// Pro_MaterialRequisitionItem
    /// </summary>
    [Table("Pro_MaterialRequisitionItem")]
    public class Pro_MaterialRequisitionItem
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
        /// PMR_No
        /// </summary>
        public String MR_Id { get; set; }

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
        public Decimal Quantity { get; set; }

    }
}