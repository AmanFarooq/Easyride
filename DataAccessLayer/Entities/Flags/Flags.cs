using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Flags
    {
        public static string ACTIVE = "active";

        public static string SUSPENDED = "suspended";

        public static int CONNECTED = 1;

        public static int DISCONNECTED = 0;

        public static string CASH = "cash";

        public static string CREDITCARD = "credit card";

        public static string PUBLIC = "public";

        public static string PRIVATE = "private";

        public static string EXPIRED = "expired";

        public static string ACCEPTING = "accepting";

        public static string NOTACCEPTING = "not accepting";


        public static string SHARED = "shared";

        public static string SURG = "surg";

        public static string NOSURG = "no surg";

        public static string PERCENTAGE = "percentage";

        public static string FIXAMOUNT = "fix amount";

        public static string REQUESTED = "ride requested";


        public static string FORWARDED = "request forwarded";


        public static string  CANCELED= "requested canceled";


        public static string REJECTED = "request rejected";

        public static string ACCEPTED = "request accepted";

        public static string DRIVERONTHEWAY = "driver on way";

        public static string DRIVERARRIVED = "driver arived";

        public static string RIDEBEGINS = "ride begins";

        public static string RIDECOMPLETED = "ride completed";

        public static string OWNER = "owner";

        public static string CLIENT = "client";

        
    }
}
