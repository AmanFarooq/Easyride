
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class DriverBalanceSheetRepository : GenericRepository<DriverBalanceSheet>
    {
        public DriverBalanceSheetRepository(UnitOfWork context) : base(context)
        {
        }

        public double addBalance(double balance, int id)
        {

            if (balance < 0)
            {
                throw new ArgumentNullException("Balance cannot be Negative");
            }
            try
            {
                DbSet.Find(id).balance += balance;
                return DbSet.Find(id).balance;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("DriverBalanceSheet not found against Provided ID");
            }
        }

        public double deductBalance(double balance, int id)
        {
            if (balance < 0)
            {
                throw new ArgumentNullException("Balance cannot be Negative");
            }
            try
            {
                DbSet.Find(id).balance -= balance;
                return DbSet.Find(id).balance;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("DriverBalanceSheet not found against Provided ID");
            }
        }

        public double getBalance(int id)
        {
            try
            {
                
                return DbSet.Find(id).balance;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("DriverBalanceSheet not found against Provided ID");
            }
        }

        public Driver getDriver(int id)
        {
            try
            {
                return DbSet.Find(id).Driver;
            }
            catch (Exception)
            {

                throw new KeyNotFoundException("DriverBalanceSheet not found against Provided ID");
            }
        }
    }
}
