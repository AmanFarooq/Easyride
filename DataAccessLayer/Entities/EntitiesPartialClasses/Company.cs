using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class Company 
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

        public bool isPublicMode()
        {
            if (mode == Flags.PUBLIC)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isClientType()
        {
            if (type == Flags.CLIENT)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public void setPublic(bool flag = true)
        {
            if (flag==true)
            {
                mode = Flags.PUBLIC;
            }
            else
            {
                mode = Flags.PRIVATE;
            }
        }


        public void setTypeClient(bool flag = true)
        {
            if (flag == true)
            {
                type = Flags.CLIENT;
            }
            else
            {
                type = Flags.OWNER;
            }
        }

        public void setActive(bool flag = true)
        {
            if (flag == true)
            {
                status = Flags.ACTIVE;
            }
            else
            {
                status = Flags.SUSPENDED;
            }
        }


        public IQueryable<VehicleDetail> VehiclDetails
        {
            get
            {
                return VehiclDetails;

            }

        }
    }
}
