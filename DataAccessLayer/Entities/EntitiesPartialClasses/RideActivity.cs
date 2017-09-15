using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class RideActivity
    {

        public bool isRideRequested()
        {
            if (requestStatus == Flags.REQUESTED)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isRideRequestForwarded()
        {
            if (requestStatus == Flags.FORWARDED)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public bool isRideRequestCanceled()
        {
            if (requestStatus == Flags.CANCELED)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public bool isRideRequestRejected()
        {
            if (requestStatus == Flags.REJECTED)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isRideRequestAccepted()
        {
            if (requestStatus == Flags.ACCEPTED)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public bool isDriverOnWay()
        {
            if (activityStatus == Flags.DRIVERONTHEWAY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isDriverArrived()
        {
            if (activityStatus == Flags.DRIVERARRIVED)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isRideBegins()
        {
            if (activityStatus == Flags.RIDEBEGINS)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isRideCompleted()
        {
            if (activityStatus == Flags.RIDECOMPLETED)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool isRideMade()
        {
            if (isRideRequestAccepted() || isDriverOnWay() || isDriverArrived() || isRideBegins() || isRideCompleted())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setRideRequested()
        {
            requestStatus = Flags.REQUESTED;
        }

        public void setRideRequestForwarded()
        {
            requestStatus = Flags.FORWARDED;
        }

        public void setRideRequestCanceled()
        {
            requestStatus = Flags.CANCELED;
        }

        public void setRideRequestRejected()
        {
            requestStatus = Flags.REJECTED;
        }

        public void setRideRequestAccepted()
        {
            requestStatus = Flags.ACCEPTED;
        }

        public void setDriverOnWay()
        {
            activityStatus = Flags.DRIVERONTHEWAY;
        }

        public void setRideBegins()
        {
            activityStatus = Flags.RIDEBEGINS;
        }

        public void setDriverArrived()
        {
            activityStatus = Flags.DRIVERARRIVED;

        }

        public void setRideCompleted()
        {
            activityStatus = Flags.RIDECOMPLETED;
        }

        public bool isPaymentCash()
        {
            if (paymentMode == Flags.CASH)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isPaymentCreditCard()
        {
            if (paymentMode == Flags.CREDITCARD)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setPaymentModCash()
        {
            paymentMode = Flags.CASH;
        }

        public void setPaymentModCreditCard()
        {
            paymentMode = Flags.CREDITCARD;
        }

        public Company Company
        {
            get
            {
                return VehicleCategory.Company;
            }
        }
        
        public Driver Driver
        {
            get
            {
                return VehicleDetail.Driver;
            }
        }
    }
}
