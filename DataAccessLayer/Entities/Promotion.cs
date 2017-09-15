namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Promotion")]
    public partial class Promotion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promotion()
        {
            RideBillingTransactions = new HashSet<RideBillingTransaction>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string promotionType { get; set; }

        public int? discountPercentage { get; set; }

        public int? discountDedecatedAmount { get; set; }

        public int maxDiscount { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        [StringLength(20)]
        public string promotionCode { get; set; }

        public DateTime? expiry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RideBillingTransaction> RideBillingTransactions { get; set; }
    }
}
