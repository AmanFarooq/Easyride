using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class AdminCredential
    {

        public bool isExpired()
        {
            if (status== Flags.ACTIVE)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setExpired(bool flag = true)
        {
            if (flag==true)
            {
                status = Flags.ACTIVE;
            }
            else
            {
                status = Flags.EXPIRED;
            }
        }
    }

    public partial class PassengerCredential : Flags
    {

        public bool isExpired()
        {
            if (status == Flags.ACTIVE)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setExpired(bool flag = true)
        {
            if (flag == true)
            {
                status = Flags.ACTIVE;
            }
            else
            {
                status = Flags.EXPIRED;
            }
        }
    }
    public partial class DriverCredential : Flags
    {

        public bool isExpired()
        {
            if (status == Flags.ACTIVE)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setExpired(bool flag = true)
        {
            if (flag == true)
            {
                status = Flags.ACTIVE;
            }
            else
            {
                status = Flags.EXPIRED;
            }
        }
    }
}
