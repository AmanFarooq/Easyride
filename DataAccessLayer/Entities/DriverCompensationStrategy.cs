namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DriverCompensationStrategy")]
    public partial class DriverCompensationStrategy
    {
        public int id { get; set; }

        public double driverPercentage { get; set; }

        public DateTime validFrom { get; set; }

        public DateTime? validTo { get; set; }

        public int companyID { get; set; }

        public virtual Company Company { get; set; }
    }
}
