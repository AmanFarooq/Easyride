using DataAccessLayer.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AdminConnectivityDetailRepository : GenericRepository<AdminConnectivityDetail>
    {
        public AdminConnectivityDetailRepository(UnitOfWork context):base(context){}


        public Admin getAdmin(int key)
        {
            try
            {
               return DbSet.Find(key).Admin;

            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("AdminiConnectivityDetail Not Found against provided key ",e);
            }
        }

        public bool isFCMEnabled(int key)
        {
            try
            {

                return DbSet.Find(key).isFCMEnabeled();

            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("AdminiConnectivityDetail Not Found against provided key ", e);
            }
        }

        public bool isSignalRConnected(int key)
        {
            try
            {
                return DbSet.Find(key).IsSignalRConnected();
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("AdminiConnectivityDetail Not Found against provided key ", e);
            }
        }

        public void setSignalRConnected(int key,bool flag=true)
        {
            try
            {
                DbSet.Find(key).setSignalRConnected(flag);
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("AdminiConnectivityDetail Not Found against provided key ", e);
            }
        }

        public void setSignalRConnectionID(string connectionID, int key)
        {
            if (connectionID==null)
            {
                throw new ArgumentNullException("Connection Id cannot be null");
            }
            try
            {
                DbSet.Find(key).signalRConnectivityID = connectionID;

            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("AdminiConnectivityDetail Not Found against provided key ", e);

            }

        }

        public void updateFCMToken(string token, int key)
        {
            if (token == null)
            {
                throw new ArgumentNullException("FCM token cannot be null");
            }
            try
            {
                DbSet.Find(key).fcmToken = token;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("AdminiConnectivityDetail Not Found against provided key ", e);
            }
        }
    }
}
