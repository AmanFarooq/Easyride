namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DriverConnectivityDetail")]
    public partial class DriverConnectivityDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public string fcmToken { get; set; }

        public string SignalRConnectivityID { get; set; }

        public int isConnected { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
