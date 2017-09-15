 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class RideRateStrategyRepository : GenericRepository<RideRateStrategy>
    {
        public RideRateStrategyRepository(UnitOfWork context) : base(context)
        {
        }

        //public Company getCompany(int id)
        //{
        //    try
        //    {
        //        return DbSet.Find(id).Company;
        //    }
        //    catch (Exception e)
        //    {

        //        throw new KeyNotFoundException("RideRateStrategy is not found against given id",e);
        //    }
        //}

        public IQueryable<RideActivity> getRideActivities(int id)
        {
            try
            {
                return DbSet.Find(id).RideActivities.AsQueryable<RideActivity>();
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("RideRateStrategy is not found against given id", e);
            }
        }

        public VehicleCategory getVehicleCategory(int id)
        {
            try
            {
                return DbSet.Find(id).VehicleCategory;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("RideRateStrategy is not found against given id", e);
            }
        }
    }
}
