 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class PassengerRepository : GenericRepository<Passenger>
    {
        public PassengerRepository(UnitOfWork context) : base(context)
        {
        }

        public Company getCompany(int id)
        {
            try
            {
                return DbSet.Find(id).Company;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Passenger is not found against given ID");
            }
        }

        //public IQueryable<SharedRide> getConsumedSharedRide(int id)
        //{
        //    try
        //    {
        //        return DbSet.Find(id).SharedRides1.AsQueryable<SharedRide>();
        //    }
        //    catch (Exception)
        //    {

        //        throw new KeyNotFoundException("Passenger is not found against given ID");
        //    }
        //}

        public PassengerConnectivityDetail getPassengerConnectivityDetail(int id)
        {
            try
            {
                return DbSet.Find(id).PassengerConnectivityDetail;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Passenger is not found against given ID");
            }
        }

        public PassengerCredential getPassengerCredential(int id)
        {
            try
            {
                return DbSet.Find(id).PassengerCredential;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Passenger is not found against given ID");
            }
        }

        public PassengerCreditCardDetail getPassengerCreditCardDetail(int id)
        {
            try
            {
                return DbSet.Find(id).PassengerCreditCardDetail;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Passenger is not found against given ID");
            }
        }

        public IQueryable<RideActivity> getRideActivities(int id)
        {
            try
            {
                return DbSet.Find(id).RideActivities.AsQueryable<RideActivity>();
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Passenger is not found against given ID");
            }
        }

        //public IQueryable<RideBillingTransaction> getRideBillingTransactions(int id)
        //{
        //    try
        //    {
        //        return DbSet.Find(id).RideBillingTransactions.AsQueryable<RideBillingTransaction>();
        //    }
        //    catch (Exception e)
        //    {

        //        throw new KeyNotFoundException("Passenger is not found against given ID", e);
        //    }
        //}

        //public IQueryable<SharedRide> getDonatedSharedRides(int id)
        //{
        //    try
        //    {
        //        return DbSet.Find(id).SharedRides.AsQueryable<SharedRide>();
        //    }
        //    catch (Exception e)
        //    {

        //        throw new KeyNotFoundException("Passenger is not found against given ID",e);
        //    }
        //}
    }
}
