using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class Passenger
    {
        public bool isActive()
        {
            if (status== Flags.ACTIVE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isDefaultPayementModCash()
        {
            if (defaultPaymentMode== Flags.CASH)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void setDefaultPaymentModCash()
        {
            defaultPaymentMode = Flags.CASH;

        }

        public void setDefaulPayementModCreditCard()
        {
            defaultPaymentMode = Flags.CREDITCARD;
        }


        public void setActive(bool Flag = true)
        {
            if (Flag==true)
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
            if (Company.mode== Flags.PUBLIC)
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
