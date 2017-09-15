using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class DriverCompensationStrategy
    {

        public bool isExpired()
        {
            if (validTo==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isCurrentStrategy()
        {
            if (DateTime.Today>=validFrom &&( DateTime.Today<=validTo || validTo==null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
