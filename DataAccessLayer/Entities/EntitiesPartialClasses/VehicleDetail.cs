using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class VehicleDetail
    {
        public bool isCurrentlyAvailable()
        {
            if (timeStamp >= (DateTime.Now - TimeSpan.FromSeconds(15)) && CurrentDriver.availabilityStatus == Flags.ACCEPTING)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setCurrentLocation(DbGeometry location)
        {
            if (location != null)
            {

                lastKnownLocation = location;
                timeStamp = DateTime.Now;
            }
        }



       

        public Driver CurrentDriver
        {
            get
            {
                return CurrentDriver;
            }

        }
        public IQueryable<Driver> Drivers
        {
            get
            {
                return VehicleDriverMemberships.Select(d => d.Driver1).AsQueryable<Driver>();
            }

        }


        /// <summary>  
        ///  Eager Fetch The company . Do not use in queries  
        /// </summary>  
       

        public IQueryable<VehicleCategory> VehicleCategories
        {
            get
            {
                return VehicleCategoryMemberShips.Select(d=>d.VehicleCategory).AsQueryable<VehicleCategory>();
            }

        }


    }
}
