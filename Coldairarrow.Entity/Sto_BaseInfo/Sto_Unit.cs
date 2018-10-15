using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_BaseInfo
{
    /// <summary>
    /// Sto_Unit
    /// </summary>
    [Table("Sto_Unit")]
    public class Sto_Unit
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

    }
}