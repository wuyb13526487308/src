using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_BaseInfo
{
    /// <summary>
    /// Sto_StoreUnit
    /// </summary>
    [Table("Sto_StoreUnit")]
    public class Sto_StoreUnit
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
        /// UnitNo
        /// </summary>
        public String UnitNo { get; set; }

        /// <summary>
        /// UnitName
        /// </summary>
        public String UnitName { get; set; }

        /// <summary>
        /// UnitClass
        /// </summary>
        public String UnitClass { get; set; }

        /// <summary>
        /// UsedState
        /// </summary>
        public Boolean? UsedState { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

    }
}