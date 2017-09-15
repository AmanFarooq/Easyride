 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class PhoneNumberVerificationRepository : GenericRepository<PhoneNumberVerification>
    {
        public PhoneNumberVerificationRepository(UnitOfWork context) : base(context)
        {
        }

     

        public IQueryable<PhoneNumberVerification> FindByPhoneNumber(string phoneNumber)
        {
            return DbSet.Where(d => d.phoneNumber == phoneNumber).AsQueryable<PhoneNumberVerification>();
        }
    }
}
