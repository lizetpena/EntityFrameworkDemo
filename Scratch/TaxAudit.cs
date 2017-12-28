namespace Scratch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaxAudit")]
    public partial class TaxAudit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public DateTime? AuditDate { get; set; }

        [StringLength(50)]
        public string AuditReason { get; set; }

        public decimal? Adjustment { get; set; }

        [StringLength(50)]
        public string Audtor { get; set; }

        public virtual FederalTaxAudit FederalTaxAudit { get; set; }

        public virtual StateTaxAudit StateTaxAudit { get; set; }
    }
}
