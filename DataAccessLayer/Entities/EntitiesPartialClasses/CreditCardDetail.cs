using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class PassengerCreditCardDetail
    {
        public bool isExpired()
        {
            if (expiryDate<=DateTime.Today)
            {
                return false;
            }
            else
            {
                return false;
            }

        }
    }
    public partial class DriverCreditCardDetail
    {
        public bool isExpired()
        {
            if (expiryDate <= DateTime.Today)
            {
                return false;
            }
            else
            {
                return false;
            }

        }
    }

    public partial class CompanyCreditCardDetail
    {
        public bool isExpired()
        {
            if (expiryDate <= DateTime.Today)
            {
                return false;
            }
            else
            {
                return false;
            }

        }
    }
}
