 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class PassengerConnectivityDetailRepository : GenericRepository<PassengerConnectivityDetail>
    {
        public PassengerConnectivityDetailRepository(UnitOfWork context) : base(context)
        {
        }

        public Entities.Passenger getPassenger(int id)
        {
            try
            {
                return DbSet.Find(id).Passenger;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("PassengerConnectivityDetail is not found against given ID");
            }
        }

        public bool isFCMEnabled(int id)
        {
            try
            {
                return DbSet.Find(id).isFCMEnabeled();
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("PassengerConnectivityDetail is not found against given ID");
            }
        }

        public bool isSignalRConnected(int id)
        {
            try
            {
                return DbSet.Find(id).IsSignalRConnected();
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("PassengerConnectivityDetail is not found against given ID");
            }
        }

        public void setSignalRConnected(int id, bool flag = true)
        {
            try
            {
                DbSet.Find(id).setSignalRConnected(flag);
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("PassengerConnectivityDetail is not found against given ID");
            }
        }

        public void setSignalRConnectionID(string connectionID, int id)
        {
            if (connectionID == null)
            {
                throw new ArgumentNullException("Connection Id cannot be null");
            }
            try
            {
                DbSet.Find(id).signalRConnectionID = connectionID;

            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("PassengerConnectivityDetail Not Found against provided key ", e);

            }
        }

        public void updateFCMToken(string token, int id)
        {

            if (token == null)
            {
                throw new ArgumentNullException("FCM token cannot be null");
            }
            try
            {
                DbSet.Find(id).fcmToken = token;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("PassengerConnectivityDetail Not Found against provided key ");
            }
        }
    }
}
