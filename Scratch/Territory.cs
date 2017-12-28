namespace Scratch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Territory
    {
        public Territory()
        {
            Employees = new HashSet<Employee>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TerritoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
