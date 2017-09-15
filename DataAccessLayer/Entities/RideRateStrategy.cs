namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RideRateStrategy")]
    public partial class RideRateStrategy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RideRateStrategy()
        {
            RideActivities = new HashSet<RideActivity>();
        }

        public int id { get; set; }

        public double perKmMoving { get; set; }

        public double perMinuteMoving { get; set; }

        [Required]
        [StringLength(20)]
        public string strategyType { get; set; }

        public DateTime validFrom { get; set; }

        public DateTime? validTo { get; set; }

        public double perMinuteWaiting { get; set; }

        public int? perMinuteChargesTimeThreshold { get; set; }

        public int? perMinuteChargesSpeedthreshold { get; set; }

        public int vehicleCatagoryID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RideActivity> RideActivities { get; set; }

        public virtual VehicleCategory VehicleCategory { get; set; }
    }
}
