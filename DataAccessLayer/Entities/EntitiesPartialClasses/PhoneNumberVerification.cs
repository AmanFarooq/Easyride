using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class PhoneNumberVerification
    {
        public bool isExpired()
        {
            if (expiryDate<DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExpireNow()
        {
            expiryDate = DateTime.Now - TimeSpan.FromSeconds(1);
        }


        public int SecondsRemainingToExpire()
        {
            if (isExpired())
            {
                return 0;
            }
            else
            {
               return Convert.ToInt32((expiryDate - DateTime.Now).TotalSeconds);
            }
        }



    }
}
