namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleDriverMembership")]
    public partial class VehicleDriverMembership
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleDriverMembership()
        {
            Drivers = new HashSet<Driver>();
        }

        public int Id { get; set; }

        public int? Driver { get; set; }

        public int? vehicle { get; set; }

        public DateTime validFrom { get; set; }

        public DateTime? validTo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Driver> Drivers { get; set; }

        public virtual Driver Driver1 { get; set; }

        public virtual VehicleDetail VehicleDetail { get; set; }
    }
}
