using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class Promotion
    {

        public bool isPercentaged()
        {
            if (promotionType == Flags.PERCENTAGE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setPercentaged(int percents)
        {
            discountPercentage = percents;
            promotionType = Flags.PERCENTAGE;
        }

        public void setDedicated(int amount)
        {
            promotionType = Flags.FIXAMOUNT;
            discountDedecatedAmount = amount;
        }




    }
}
