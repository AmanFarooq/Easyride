namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleDetail")]
    public partial class VehicleDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleDetail()
        {
            RideActivities = new HashSet<RideActivity>();
            VehicleCategoryMemberShips = new HashSet<VehicleCategoryMemberShip>();
            VehicleDriverMemberships = new HashSet<VehicleDriverMembership>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string VIN { get; set; }

        [StringLength(20)]
        public string model { get; set; }

        [Required]
        [StringLength(20)]
        public string color { get; set; }

        public int? conditionScore { get; set; }

        public int vehicleCategoryMembershipID { get; set; }

        public DbGeometry lastKnownLocation { get; set; }

        public DateTime? timeStamp { get; set; }

        public int? category { get; set; }

        public int? currentDriver { get; set; }

        public virtual Driver Driver { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RideActivity> RideActivities { get; set; }

        public virtual VehicleCategory VehicleCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleCategoryMemberShip> VehicleCategoryMemberShips { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleDriverMembership> VehicleDriverMemberships { get; set; }

        public virtual Company Company { get; set; }
    }
}
