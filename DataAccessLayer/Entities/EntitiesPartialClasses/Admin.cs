using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class Admin
    {

       
        public bool isActive()
        {
            if (status==Flags.SUSPENDED)
            {
                return false;

            }
            else
            {
                return true;
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

    }
}
