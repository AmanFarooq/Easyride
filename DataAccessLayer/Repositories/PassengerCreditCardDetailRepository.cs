 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class PassengerCreditCardDetailRepository : GenericRepository<PassengerCreditCardDetail>
    {
        public PassengerCreditCardDetailRepository(UnitOfWork context) : base(context)
        {
        }

        public Entities.Passenger getPassenegr(int id)
        {
            try
            {
                return DbSet.Find(id).Passenger;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("PassengerCreditCardDetail is not found against Given ID", e);
            }
        }
    }
}
