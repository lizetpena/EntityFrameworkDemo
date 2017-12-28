namespace Scratch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupplierType")]
    public partial class SupplierType
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
