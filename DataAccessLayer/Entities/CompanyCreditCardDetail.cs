namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyCreditCardDetail")]
    public partial class CompanyCreditCardDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string holderName { get; set; }

        [Required]
        [StringLength(20)]
        public string cardNo { get; set; }

        [Required]
        [StringLength(3)]
        public string ccvNo { get; set; }

        public DateTime expiryDate { get; set; }

        public virtual Company Company { get; set; }
    }
}
