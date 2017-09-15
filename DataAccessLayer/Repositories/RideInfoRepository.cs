 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class RideInfoRepository : GenericRepository<RideInfo>
    {
        public RideInfoRepository(UnitOfWork context) : base(context)
        {
        }

        public RideActivity getRideActivity(int id)
        {
            try
            {
                return DbSet.Find(id).RideActivity;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("RideInfo is not found against given id");
            }
        }
    }
}
