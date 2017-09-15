 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class PromotionRepository : GenericRepository<Promotion>
    {
        public PromotionRepository(UnitOfWork context) : base(context)
        {
        }

        //public Promotion getPromotionCode(int id)
        //{
        //    try
        //    {
        //        return DbSet.Find(id).PromotionCode;
        //    }
        //    catch (Exception)
        //    {

        //        throw new KeyNotFoundException("GeneraLPromotion not found against given ID");
        //    }
        //}
    }
}
