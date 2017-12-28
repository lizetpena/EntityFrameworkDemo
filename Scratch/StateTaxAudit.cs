namespace Scratch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StateTaxAudit")]
    public partial class StateTaxAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxAuditID { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [StringLength(50)]
        public string Agency { get; set; }

        public bool? SalesUseTax { get; set; }

        public virtual TaxAudit TaxAudit { get; set; }
    }
}
