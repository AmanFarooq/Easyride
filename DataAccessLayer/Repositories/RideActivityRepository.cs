 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using System.Data.Entity.Spatial;

namespace DataAccessLayer.Repositories
{
    public class RideActivityRepository : GenericRepository<RideActivity>
    {
        public RideActivityRepository(UnitOfWork context) : base(context)
        {
        }

        

        public Entities.Passenger getPassenger(int id)
        {
            try
            {
                return DbSet.Find(id).Passenger;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("RideActivity not found against Provided ID", e);
            }
        }

        public RideBillingTransaction getRideBillingTransaction(int id)
        {
            try
            {
                return DbSet.Find(id).RideBillingTransaction;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("RideActivity not found against Provided ID", e);
            }
        }

      

        public RideInfo getRideInfo(int id)
        {
            try
            {
                return DbSet.Find(id).RideInfo;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("RideActivity not found against Provided ID", e);
            }
        }

        public RideRateStrategy getRideRateStrategy(int id)
        {
            try
            {
                return DbSet.Find(id).RideRateStrategy;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("RideActivity not found against Provided ID", e);
            }
        }



        public IQueryable<RideActivity> WherePickUpPointInBuffer(int distance,DbGeometry pickupPoint)
        {
            return getAll().Where(d => d.RideInfo.pickupLocation.Distance(pickupPoint) <= distance).AsQueryable();
        }


        public IQueryable<RideActivity> WhereCompanyID(int distance, DbGeometry pickupPoint)
        {
            return getAll().Where(d => d.RideInfo.pickupLocation.Distance(pickupPoint) <= distance).AsQueryable();
        }




    }
}
