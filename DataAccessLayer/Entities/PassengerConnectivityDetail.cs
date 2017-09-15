namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PassengerConnectivityDetail")]
    public partial class PassengerConnectivityDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public string fcmToken { get; set; }

        public string signalRConnectionID { get; set; }

        public int isConnected { get; set; }

        public virtual Passenger Passenger { get; set; }
    }
}
