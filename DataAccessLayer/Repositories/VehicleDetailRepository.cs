 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class VehicleDetailRepository : GenericRepository<VehicleDetail>
    {
        public VehicleDetailRepository(UnitOfWork context) : base(context)
        {
        }

        
        public IQueryable< VehicleCategory> getVehicalCatagory(int id)
        {
            try
            {
                return DbSet.Find(id).VehicleCategoryMemberShips.Where(d=>d.vehicleDetailId==id).Select(f=>f.VehicleCategory).AsQueryable();
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("VehicleDetail is not found against given ID", e);
            }
        }
    }
}
