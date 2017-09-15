using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{


    public partial class AdminConnectivityDetail
    {

        public bool IsSignalRConnected()
        {
            
            if (isConnected == Flags.CONNECTED)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool isFCMEnabeled()
        {
            if (fcmToken == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setSignalRConnected(bool flag)
        {
            if (flag == true)
            {
                isConnected = Flags.CONNECTED;
            }
            else
            {
                isConnected = Flags.DISCONNECTED;
            }
        }



    }

    public partial class DriverConnectivityDetail
    {

        public bool IsSignalRConnected()
        {
            if (isConnected == Flags.CONNECTED)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool isFCMEnabeled()
        {
            if (fcmToken == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setSignalRConnected(bool flag)
        {
            if (flag == true)
            {
                isConnected = Flags.CONNECTED;
            }
            else
            {
                isConnected = Flags.DISCONNECTED;
            }
        }



    }

    public partial class PassengerConnectivityDetail 
    {

        public bool IsSignalRConnected()
        {
            if (isConnected == Flags.CONNECTED)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool isFCMEnabeled()
        {
            if (fcmToken == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setSignalRConnected(bool flag)
        {
            if (flag == true)
            {
                isConnected = Flags.CONNECTED;
            }
            else
            {
                isConnected = Flags.DISCONNECTED;
            }
        }



    }




}
