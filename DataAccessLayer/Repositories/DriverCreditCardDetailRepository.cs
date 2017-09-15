 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class DriverCreditCardDetailRepository : GenericRepository<DriverCreditCardDetail>
    {
        public DriverCreditCardDetailRepository(UnitOfWork context) : base(context)
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

                throw new KeyNotFoundException("DriverCreditCardDetail is not found against Given ID");
            }
        }
    }
}
