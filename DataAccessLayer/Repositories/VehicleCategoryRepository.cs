 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class VehicleCategoryRepository : GenericRepository<VehicleCategory>
    {
        public VehicleCategoryRepository(UnitOfWork context) : base(context)
        {
        }

        public Company getCompany(int id)
        {
            try
            {
                return DbSet.Find(id).Company;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("VehicleCategory is not find against given ID", e);
            }
        }

        public IQueryable<RideRateStrategy> getRideRateStrategy(int id)
        {
            try
            {
                return DbSet.Find(id).RideRateStrategies.AsQueryable<RideRateStrategy>();
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("VehicleCategory is not find against given ID", e);
            }
        }

        public IQueryable<VehicleDetail> getVehicalDetail(int id)
        {
            try
            {
               List<VehicleCategoryMemberShip> detail= DbSet.Find(id).VehicleCategoryMemberShips.Where(d => d.vehicleCategoryID == id).ToList();
                List<VehicleDetail> resultset = new List<VehicleDetail>();
                foreach (var item in detail)
                {
                    resultset.Add(item.VehicleDetail);
                }
                return resultset.AsQueryable<VehicleDetail>();
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("VehicleCategory is not find against given ID", e);
            }
        }


    }
}
