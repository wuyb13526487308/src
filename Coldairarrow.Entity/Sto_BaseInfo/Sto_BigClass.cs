using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_BaseInfo
{
    /// <summary>
    /// Sto_BigClass
    /// </summary>
    [Table("Sto_BigClass")]
    public class Sto_BigClass
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// BigClassCode
        /// </summary>
        public String BigClassCode { get; set; }

        /// <summary>
        /// BigClassName
        /// </summary>
        public String BigClassName { get; set; }

        /// <summary>
        /// LastTime
        /// </summary>
        public DateTime? LastTime { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

    }
}