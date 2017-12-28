namespace Scratch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OHCustomer")]
    public partial class OHCustomer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        [StringLength(10)]
        public string City { get; set; }

        [StringLength(10)]
        public string State { get; set; }
    }
}
