using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class Driver
    {

        public bool isActive()
        {
            if (status == Flags.ACTIVE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void setActive(bool Flag = true)
        {
            if (Flag == true)
            {
                status = Flags.ACTIVE;
            }
            else
            {
                status = Flags.SUSPENDED;
            }
        }

        public bool isPublic()
        {
            if (Company.mode == Flags.PUBLIC)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public IQueryable<RideActivity> RideActivities
        {
            get
            {
                return VehicleDriverMembership.VehicleDetail.RideActivities.AsQueryable<RideActivity>();
            }

        }
        

        public VehicleDetail CurrentVehicleDetail
        {
            get
            {
                return VehicleDriverMembership.VehicleDetail;
            }

        }

    }
}
