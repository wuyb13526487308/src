using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_BaseInfo
{
    /// <summary>
    /// Sto_MaterialUnit
    /// </summary>
    [Table("Sto_MaterialUnit")]
    public class Sto_MaterialUnit
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// UnitNum
        /// </summary>
        public String UnitNum { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public String Name { get; set; }

    }
}