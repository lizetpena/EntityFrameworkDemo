namespace Scratch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Carrier
    {
        public Carrier()
        {
            CarrierContacts = new HashSet<CarrierContact>();
        }

        public int CarrierId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Abbreviation { get; set; }

        [Required]
        [StringLength(1)]
        public string Rating { get; set; }

        public int ActiveMonthAssociated { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<CarrierContact> CarrierContacts { get; set; }
    }
}
