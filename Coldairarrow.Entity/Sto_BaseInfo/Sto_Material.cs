using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_BaseInfo
{
    /// <summary>
    /// Sto_Material
    /// </summary>
    [Table("Sto_Material")]
    public class Sto_Material
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// MatNo
        /// </summary>
        public String MatNo { get; set; }

        /// <summary>
        /// BarCode
        /// </summary>
        public String BarCode { get; set; }

        /// <summary>
        /// MatName
        /// </summary>
        public String MatName { get; set; }

        /// <summary>
        /// JianPin
        /// </summary>
        public String JianPin { get; set; }

        /// <summary>
        /// BigClass
        /// </summary>
        public String BigClass { get; set; }

        /// <summary>
        /// GuiGe
        /// </summary>
        public String GuiGe { get; set; }

        /// <summary>
        /// MaxStoreQuantity
        /// </summary>
        public Int32 MaxStoreQuantity { get; set; }

        /// <summary>
        /// WarnStoreQuantity
        /// </summary>
        public Int32 WarnStoreQuantity { get; set; }

        /// <summary>
        /// UnitNo
        /// </summary>
        public String UnitNo { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

    }
}