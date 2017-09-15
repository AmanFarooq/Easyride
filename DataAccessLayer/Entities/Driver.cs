namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Driver")]
    public partial class Driver
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Driver()
        {
            VehicleDetails = new HashSet<VehicleDetail>();
            VehicleDriverMemberships = new HashSet<VehicleDriverMembership>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(22)]
        public string name { get; set; }

        [Required]
        [StringLength(13)]
        public string phoneNo { get; set; }

        [Required]
        [StringLength(13)]
        public string cnic { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [StringLength(50)]
        public string photo { get; set; }

        public int companyID { get; set; }

        [Required]
        [StringLength(20)]
        public string status { get; set; }

        [Required]
        [StringLength(20)]
        public string availabilityStatus { get; set; }

        public int? referenceAdminID { get; set; }

        public int? currentVehicleMembership { get; set; }

        public virtual Company Company { get; set; }

        public virtual DriverCreditCardDetail DriverCreditCardDetail { get; set; }

        public virtual VehicleDriverMembership VehicleDriverMembership { get; set; }

        public virtual DriverBalanceSheet DriverBalanceSheet { get; set; }

        public virtual DriverConnectivityDetail DriverConnectivityDetail { get; set; }

        public virtual DriverCredential DriverCredential { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleDetail> VehicleDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleDriverMembership> VehicleDriverMemberships { get; set; }
    }
}
