 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class RideBillingTransactionRepositry : GenericRepository<RideBillingTransaction>
    {
        public RideBillingTransactionRepositry(UnitOfWork context) : base(context)
        {
        }

        //public Company getCompany(int id)
        //{
        //    try
        //    {
        //        return DbSet.Find(id).Company;
        //    }
        //    catch (Exception)
        //    {

        //        throw new KeyNotFoundException("RideBillingTransection is not found in against given ID");
        //    }
        //}

        //public Driver getDriver(int id)
        //{
        //    try
        //    {
        //        return DbSet.Find(id).Driver;
        //    }
        //    catch (Exception e)
        //    {

        //        throw new KeyNotFoundException("RideBillingTransection is not found in against given ID",e);
        //    }
        //}

        //public Entities.Passenger getPassenger(int id)
        //{
        //    try
        //    {
        //        return DbSet.Find(id).Passenger;

        //    }
        //    catch (Exception e)
        //    {

        //        throw new KeyNotFoundException("RideBillingTransection is not found in against given ID", e);
        //    }
        //}

        //public PromotionCode getPromotionCode(int id)
        //{
        //    try
        //    {
        //        return DbSet.Find(id).PromotionCode;
        //    }
        //    catch (Exception e)
        //    {

        //        throw new KeyNotFoundException("RideBillingTransection is not found in against given ID", e);
        //    }
        //}

        public RideActivity getRideActivity(int id)
        {
            try
            {
                return DbSet.Find(id).RideActivity;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("RideBillingTransection is not found in against given ID", e);
            }
        }
    }
}
