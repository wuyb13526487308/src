using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_BaseInfo
{
    /// <summary>
    /// Sto_Supplier
    /// </summary>
    [Table("Sto_Supplier")]
    public class Sto_Supplier
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// SupNumber
        /// </summary>
        public String SupNumber { get; set; }

        /// <summary>
        /// SupName
        /// </summary>
        public String SupName { get; set; }

        /// <summary>
        /// SupType
        /// </summary>
        public Int32? SupType { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public String Phone { get; set; }

        /// <summary>
        /// Fax
        /// </summary>
        public String Fax { get; set; }

        /// <summary>
        /// Mail
        /// </summary>
        public String Mail { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        /// PostCode
        /// </summary>
        public String PostCode { get; set; }

        /// <summary>
        /// ContactName
        /// </summary>
        public String ContactName { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Creater
        /// </summary>
        public String Creater { get; set; }

    }
}