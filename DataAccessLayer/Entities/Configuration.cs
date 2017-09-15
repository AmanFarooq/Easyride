namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Configuration")]
    public partial class Configuration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int RideSearchBuffer { get; set; }

        public int SurgeBuffer { get; set; }

        public int SurgeMinCount { get; set; }

        public double SurgeIncrementalRatio { get; set; }

        public int SurgeTimespan { get; set; }

        public virtual Company Company { get; set; }
    }
}
