using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.BussinessLayer
{
    public class DriverCompensationStrategyManager
    {
        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;


        public DriverCompensationStrategyManager(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }

        public DriverCompensationStrategy createNewStrategy(Company company, DriverCompensationStrategy strategy)
        {
            if (company==null || strategy==null)
            {
                return null;
            }
            strategy.companyID = company.id;
            unitOfWork.DriverCompensationStrategyRepository.AddNew(strategy);
            unitOfWork.Save();

            if (company.DriverCompensationStrategies.Count == 1)
            {
                activateStrategy(company, strategy.id);
            }

            return strategy;
        }


        public DriverCompensationStrategy activateStrategy(Company company, int DriverCompensationStrategyID)
        {
            if (company==null)
            {
                return null;
            }

            try
            {
               DriverCompensationStrategy strategy=  unitOfWork.DriverCompensationStrategyRepository.Find(DriverCompensationStrategyID);
                if (strategy!=null)
                {
                    strategy.validFrom = DateTime.Now;
                    strategy.validTo = null;
                }
                else
                {
                    return null;
                }

                List<DriverCompensationStrategy> list = unitOfWork.DriverCompensationStrategyRepository.getAll().Where(d => d.id != DriverCompensationStrategyID).ToList();
                if (list!=null)
                {
                    foreach (var item in list)
                    {
                        item.validTo = DateTime.Now - TimeSpan.FromMinutes(1);
                    }
                }
                unitOfWork.Save();
                return strategy;
            }
            catch (Exception)
            {

                return null;
            }
            
        }


        public List<DriverCompensationStrategy> getAllStrategies()
        {
           return  unitOfWork.DriverCompensationStrategyRepository.getAll().ToList();
        }
         
    }
}
