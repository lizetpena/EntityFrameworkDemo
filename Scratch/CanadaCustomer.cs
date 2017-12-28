namespace Scratch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CanadaCustomer")]
    public partial class CanadaCustomer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(10)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string City { get; set; }
    }
}
