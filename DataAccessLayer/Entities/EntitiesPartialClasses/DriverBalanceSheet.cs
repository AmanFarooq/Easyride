using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class DriverBalanceSheet
    {
        public bool isHavingDebit()
        {
            if (balance<0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isHavingCredit()
        {
            if (balance>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isAdjustedBalance()
        {
            if (!isHavingCredit() && !isHavingDebit())
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
