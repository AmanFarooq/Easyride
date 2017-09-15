namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DriverCredential")]
    public partial class DriverCredential
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(20)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string accessToken { get; set; }

        public DateTime? accessTokenExpiry { get; set; }

        [Required]
        [StringLength(20)]
        public string status { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
