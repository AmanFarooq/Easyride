 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class DriverConnectivityDetailRepository : GenericRepository<DriverConnectivityDetail>
    {
        public DriverConnectivityDetailRepository(UnitOfWork context) : base(context)
        {
        }

        public Driver getDriver(int id)
        {
            try
            {
                return DbSet.Find(id).Driver;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("DriverConnectivityDetail is not found against provided ID");
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
                throw new KeyNotFoundException("DriverConnectivityDetail is not found against provided ID");
            }
        }

        public bool isSignalRConnected(int id)
        {
            try
            {
                return DbSet.Find(id).IsSignalRConnected();
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("DriverConnectivityDetail is not found against provided ID", e);
            }
        }

        public void setSignalRConnected(int id, bool flag = true)
        {
            try
            {
                DbSet.Find(id).setSignalRConnected(flag);
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("DriverConnectivityDetail is not found against provided ID",e);
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
                DbSet.Find(id).SignalRConnectivityID = connectionID;

            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("DriverConnectivityDetail Not Found against provided key ", e);

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
            catch (Exception e)
            {

                throw new KeyNotFoundException("DriverConnectivityDetail Not Found against provided key ", e);
            }
        }
    }
}
