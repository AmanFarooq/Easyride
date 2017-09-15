namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Passenger")]
    public partial class Passenger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Passenger()
        {
            RideActivities = new HashSet<RideActivity>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(15)]
        public string phoneNo { get; set; }

        public int? companyID { get; set; }

        [StringLength(20)]
        public string defaultPaymentMode { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        public virtual Company Company { get; set; }

        public virtual PassengerCreditCardDetail PassengerCreditCardDetail { get; set; }

        public virtual PassengerConnectivityDetail PassengerConnectivityDetail { get; set; }

        public virtual PassengerCredential PassengerCredential { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RideActivity> RideActivities { get; set; }
    }
}
