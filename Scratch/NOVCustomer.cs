namespace Scratch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOVCustomer")]
    public partial class NOVCustomer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(10)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Zip1 { get; set; }

        [StringLength(10)]
        public string State { get; set; }
    }
}
