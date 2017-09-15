namespace DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleCategoryMemberShip")]
    public partial class VehicleCategoryMemberShip
    {
        public int Id { get; set; }

        public int vehicleCategoryID { get; set; }

        public int vehicleDetailId { get; set; }

        public int isEnabeled { get; set; }

        public virtual VehicleCategory VehicleCategory { get; set; }

        public virtual VehicleDetail VehicleDetail { get; set; }
    }
}
