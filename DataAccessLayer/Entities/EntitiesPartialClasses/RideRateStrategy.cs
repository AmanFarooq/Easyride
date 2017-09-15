using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class RideRateStrategy
    {
        public bool isCurrentStrategy()
        {
            if (validFrom<=DateTime.Today && (validTo>=DateTime.Today || validTo ==null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isHavingTimeThreshold()
        {
            if (perMinuteChargesTimeThreshold==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isHavingSpeedThreshold()
        {
            if (perMinuteChargesSpeedthreshold==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isSurgeApplied()
        {
            if (strategyType== Flags.SURG)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void setSurgeTypeStrategy(bool flag = true)
        {
            if (flag==true)
            {
                strategyType = Flags.SURG;
            }
            else
            {
                strategyType = Flags.NOSURG;
            }
        }

        

    }
}
