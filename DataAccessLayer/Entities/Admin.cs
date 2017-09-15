namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            Admin1 = new HashSet<Admin>();
        }

        public int id { get; set; }

        [StringLength(22)]
        public string name { get; set; }

        [StringLength(13)]
        public string phoneno { get; set; }

        public int? companyID { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        public int? referenceAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin> Admin1 { get; set; }

        public virtual Admin Admin2 { get; set; }

        public virtual Company Company { get; set; }

        public virtual AdminConnectivityDetail AdminConnectivityDetail { get; set; }

        public virtual AdminCredential AdminCredential { get; set; }
    }
}
