namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RideInfo")]
    public partial class RideInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public DbGeometry pickupLocation { get; set; }

        public DbGeometry destinationLocation { get; set; }

        public string pickupAddress { get; set; }

        public string destinationAddress { get; set; }

        public DbGeometry route { get; set; }

        public string extraDetail { get; set; }

        public virtual RideActivity RideActivity { get; set; }
    }
}
