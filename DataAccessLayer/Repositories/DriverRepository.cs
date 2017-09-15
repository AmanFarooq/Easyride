 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class DriverRepository : GenericRepository<Driver>
    {
        public DriverRepository(UnitOfWork context) : base(context)
        {
        }

        public DriverBalanceSheet getDriverBalanceSheet(int id)
        {
            try
            {
                return DbSet.Find(id).DriverBalanceSheet;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Driver not found against Given ID");
            }
        }

        public DriverConnectivityDetail getDriverConnectivityDetail(int id)
        {
            try
            {
                return DbSet.Find(id).DriverConnectivityDetail;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Driver not found against Given ID");
            }
        }

        public DriverCredential getDriverCredential(int id)
        {
            try
            {
                return DbSet.Find(id).DriverCredential;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Driver not found against Given ID");
            }
        }

        public DriverCreditCardDetail getDriverCreditCardDetail(int id)
        {
            try
            {
                return DbSet.Find(id).DriverCreditCardDetail;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Driver not found against Given ID");
            }
        }

        public IQueryable<RideActivity> getCurrentRideActivities(int id)
        {
            try
            {
                return DbSet.Find(id).VehicleDriverMembership.VehicleDetail.RideActivities.AsQueryable<RideActivity>();
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Driver not found against Given ID");
            }
        }

        //public IQueryable<RideBillingTransaction> getRideBillingTransactions(int id)
        //{
        //    try
        //    {
        //        return DbSet.Find(id).RideBillingTransactions.AsQueryable<RideBillingTransaction>();
        //    }
        //    catch (Exception)
        //    {

        //        throw new KeyNotFoundException("Driver not found against Given ID");
        //    }
        //}

        public VehicleDetail getVehicleDetail(int id)
        {
            try
            {
                return DbSet.Find(id).VehicleDriverMembership.VehicleDetail;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Driver not found against Given ID");
            }
        }
    }
}
