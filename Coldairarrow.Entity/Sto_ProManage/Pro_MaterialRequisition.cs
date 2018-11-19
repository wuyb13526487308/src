using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_ProManage
{
    /// <summary>
    /// Pro_MaterialRequisition
    /// </summary>
    [Table("Pro_MaterialRequisition")]
    public class Pro_MaterialRequisition
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
        /// PMR_No
        /// </summary>
        public String PMR_No { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        public String Creator { get; set; }

        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Picker
        /// </summary>
        public String Picker { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public Int16? Status { get; set; }

    }
}