namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleCategory")]
    public partial class VehicleCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleCategory()
        {
            RideActivities = new HashSet<RideActivity>();
            RideRateStrategies = new HashSet<RideRateStrategy>();
            VehicleCategory1 = new HashSet<VehicleCategory>();
            VehicleCategoryMemberShips = new HashSet<VehicleCategoryMemberShip>();
            VehicleDetails = new HashSet<VehicleDetail>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        public int capacity { get; set; }

        public string description { get; set; }

        public string iconPath { get; set; }

        public int companyID { get; set; }

        public DateTime? validFrom { get; set; }

        public DateTime? validTo { get; set; }

        public int? parentCategory { get; set; }

        public virtual Company Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RideActivity> RideActivities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RideRateStrategy> RideRateStrategies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleCategory> VehicleCategory1 { get; set; }

        public virtual VehicleCategory VehicleCategory2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleCategoryMemberShip> VehicleCategoryMemberShips { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleDetail> VehicleDetails { get; set; }
    }
}
