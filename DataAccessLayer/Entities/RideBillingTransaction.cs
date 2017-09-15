namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RideBillingTransaction")]
    public partial class RideBillingTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int passengerPayable { get; set; }

        public double companyServiceCharges { get; set; }

        [Required]
        [StringLength(20)]
        public string overallStatus { get; set; }

        public int driverID { get; set; }

        public int companyID { get; set; }

        public int passengerID { get; set; }

        public double? driverPayable { get; set; }

        [StringLength(20)]
        public string driverPayableStatus { get; set; }

        [StringLength(20)]
        public string paymentMode { get; set; }

        [StringLength(20)]
        public string passengerPayableStatus { get; set; }

        public double? companyPayable { get; set; }

        [StringLength(20)]
        public string companyPayableStatus { get; set; }

        public int? promotionID { get; set; }

        public virtual Promotion Promotion { get; set; }

        public virtual RideActivity RideActivity { get; set; }
    }
}
