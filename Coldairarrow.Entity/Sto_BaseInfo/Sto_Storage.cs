using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_BaseInfo
{
    /// <summary>
    /// Sto_Storage
    /// </summary>
    [Table("Sto_Storage")]
    public class Sto_Storage
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// StoreNo
        /// </summary>
        public String StoreNo { get; set; }

        /// <summary>
        /// StoreName
        /// </summary>
        public String StoreName { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

    }
}