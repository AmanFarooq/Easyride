
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class CompanyRepository : GenericRepository<Company>
    {
        public CompanyRepository(UnitOfWork context) : base(context)
        {
        }

        

        public IQueryable<Admin> getAdmins(int id)
        {
            try
            {
                return Find(id).Admins.AsQueryable<Admin>();
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Company not found against Provided ID");
            }
        }

        public Company getBaseOwnerCompany()
        {
           return getAll().Where(d => d.isClientType() == false).First();
            
        }

        public CompanyCreditCardDetail getCreditCardDetail(int id)
        {
            try
            {
                return DbSet.Find(id).CompanyCreditCardDetail;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Company not found against Provided ID");
            }
        }

        public IQueryable<DriverCompensationStrategy> getDriverCompensationStrategies(int id)
        {

            try
            {
                return DbSet.Find(id).DriverCompensationStrategies.AsQueryable<DriverCompensationStrategy>();
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Company not found against Provided ID");
            }
        }

        public IQueryable<VehicleDetail> getVehicle(Company company)
        {
            return company.VehiclDetails;
        }

        public string getStatus(int id)
        {
            try
            {
                return DbSet.Find(id).status;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Company not found against Provided ID");
            }
        }

        public IQueryable<VehicleCategory> getVehicalDetails(int id)
        {
            try
            {
                return DbSet.Find(id).VehicleCategories.AsQueryable<VehicleCategory>();
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("Company not found against Provided ID");
            }
        }

        public void renewIdentificationKey(int id)
        {
            throw new NotImplementedException();
        }

    }
}
