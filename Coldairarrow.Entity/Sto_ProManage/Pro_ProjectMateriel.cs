using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_ProManage
{
    /// <summary>
    /// Pro_ProjectMateriel
    /// </summary>
    [Table("Pro_ProjectMateriel")]
    public class Pro_ProjectMateriel
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
        /// PlanQuantity
        /// </summary>
        public Decimal? PlanQuantity { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

    }
}