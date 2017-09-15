namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminConnectivityDetail")]
    public partial class AdminConnectivityDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public string fcmToken { get; set; }

        public string signalRConnectivityID { get; set; }

        public int isConnected { get; set; }

        public virtual Admin Admin { get; set; }
    }
}
