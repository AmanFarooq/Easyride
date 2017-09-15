namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhoneNumberVerification")]
    public partial class PhoneNumberVerification
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string phoneNumber { get; set; }

        [Required]
        [StringLength(5)]
        public string verificationCode { get; set; }

        public DateTime expiryDate { get; set; }
    }
}
