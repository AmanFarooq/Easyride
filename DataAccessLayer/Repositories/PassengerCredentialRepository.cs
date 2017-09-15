 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class PassengerCredentialRepository : GenericRepository<PassengerCredential>
    {
        public PassengerCredentialRepository(UnitOfWork context) : base(context)
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

                throw new KeyNotFoundException("PassengerCredential not found against Provided ID", e);
            }
        }

        public string status(int id)
        {
            try
            {
                return DbSet.Find(id).status;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("PassengerCredential not found against Provided ID", e);
            }
        }

        public void updateStatus(string status, int id)
        {
            if (status == null)
            {
                throw new ArgumentNullException("Status cannot be null");
            }
            try
            {
                DbSet.Find(id).status = status;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("PassengerCredential not found against Provided ID", e);
            }
        }

    }
}
