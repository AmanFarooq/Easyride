namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RideActivity")]
    public partial class RideActivity
    {
        public int id { get; set; }

        public int passengerID { get; set; }

        public int? vehicle { get; set; }

        [Required]
        [StringLength(20)]
        public string requestStatus { get; set; }

        public DateTime requestTime { get; set; }

        [StringLength(50)]
        public string activityStatus { get; set; }

        public DateTime? rideStartTime { get; set; }

        public DateTime? dropOffTime { get; set; }

        public DateTime? pickupArrivalTime { get; set; }

        public double? distanceTraveled { get; set; }

        public int? duration { get; set; }

        public int? rideRateStrategyID { get; set; }

        public double? surge { get; set; }

        [StringLength(20)]
        public string paymentMode { get; set; }

        public int? VehicleCatagoryID { get; set; }

        public virtual Passenger Passenger { get; set; }

        public virtual RideRateStrategy RideRateStrategy { get; set; }

        public virtual VehicleCategory VehicleCategory { get; set; }

        public virtual VehicleDetail VehicleDetail { get; set; }

        public virtual RideBillingTransaction RideBillingTransaction { get; set; }

        public virtual RideInfo RideInfo { get; set; }
    }
}
