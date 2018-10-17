using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Sto_ProManage
{
    /// <summary>
    /// Pro_Template
    /// </summary>
    [Table("Pro_Template")]
    public class Pro_Template
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public String Id { get; set; } 

        /// <summary>
        /// TemplateId
        /// </summary>
        public String TemplateId { get; set; }

        /// <summary>
        /// TemplateType
        /// </summary>
        public Int32 TemplateType { get; set; }

        /// <summary>
        /// TemplateName
        /// </summary>
        public String TemplateName { get; set; }

        /// <summary>
        /// LastTime
        /// </summary>
        public DateTime? LastTime { get; set; }

        /// <summary>
        /// LastOperator
        /// </summary>
        public String LastOperator { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        public String Context { get; set; }

    }
}