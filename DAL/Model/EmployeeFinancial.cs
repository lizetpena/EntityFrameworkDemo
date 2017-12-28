using DAL.Model;

namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeFinancial")]
    public partial class EmployeeFinancial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        public int? CreditScore { get; set; }

        public int? CorporateRiskScore { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
