namespace Scratch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FederalTaxAudit")]
    public partial class FederalTaxAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxAuditID { get; set; }

        [StringLength(50)]
        public string IRSDistrict { get; set; }

        public int? DIFScore { get; set; }

        public bool? Appeal { get; set; }

        [StringLength(2)]
        public string TaxYear { get; set; }

        public virtual TaxAudit TaxAudit { get; set; }
    }
}
