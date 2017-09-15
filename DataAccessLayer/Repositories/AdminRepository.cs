
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class AdminRepository : GenericRepository<Admin>
    {
        public AdminRepository(UnitOfWork context) : base(context)
        {
        }

        public AdminConnectivityDetail getAdminConnectivityDetail(int id)
        {
            try
            {
                return DbSet.Find(id).AdminConnectivityDetail;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("Admin Is not found against Provided ID", e);
            }
        }

        public AdminCredential getAdminCredential(int id)
        {
            try
            {
                return DbSet.Find(id).AdminCredential;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("Admin Not found against provided ID",e);
            }
        }

        public Company getCompany(int id)
        {
            try
            {
                return DbSet.Find(id).Company;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Admin not found against provided ID");
            }
        }
    }
}
