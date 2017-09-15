 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class DriverCompensationStrategyRepository : GenericRepository<DriverCompensationStrategy>
    {
        public DriverCompensationStrategyRepository(UnitOfWork context) : base(context)
        {
        }

        public void changeDriverCompensationPercentage(float percantage, int id)
        {
            if (percantage < 0)
            {
                throw new ArgumentNullException("DriverComensationPercantage cannot be negative");
            }

            try
            {
                DbSet.Find(id).driverPercentage = percantage;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("DriverComensationPercantage is not found against given ID");
            }

        }
    }
}
