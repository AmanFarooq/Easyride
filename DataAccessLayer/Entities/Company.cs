namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            Admins = new HashSet<Admin>();
            Drivers = new HashSet<Driver>();
            DriverCompensationStrategies = new HashSet<DriverCompensationStrategy>();
            Passengers = new HashSet<Passenger>();
            VehicleCategories = new HashSet<VehicleCategory>();
            VehicleDetails = new HashSet<VehicleDetail>();
        }

        public int id { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        [StringLength(13)]
        public string phoneNo { get; set; }

        [StringLength(50)]
        public string identificationKey { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(20)]
        public string mode { get; set; }

        [StringLength(20)]
        public string type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin> Admins { get; set; }

        public virtual CompanyCreditCardDetail CompanyCreditCardDetail { get; set; }

        public virtual Configuration Configuration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Driver> Drivers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriverCompensationStrategy> DriverCompensationStrategies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passenger> Passengers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleCategory> VehicleCategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleDetail> VehicleDetails { get; set; }
    }
}
