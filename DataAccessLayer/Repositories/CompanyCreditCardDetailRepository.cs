
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class CompanyCreditCardDetailRepository : GenericRepository<CompanyCreditCardDetail>
    {
        public CompanyCreditCardDetailRepository(UnitOfWork context) : base(context)
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
                throw new KeyNotFoundException("CompanyCreditCardDetailRepository not found against Provided ID");
            }
        }
    }
}
