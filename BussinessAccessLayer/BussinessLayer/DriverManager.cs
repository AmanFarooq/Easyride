
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Repositories;

namespace BusinessAccessLayer.BussinessLayer
{
    class DriverManager 
    {

        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;


        public DriverManager(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }


        public void activateDriver(int driverID)
        {
            if (driverID != 0)
            {
                try
                {
                    DataAccessLayer.Entities.Driver findDriver = unitOfWork.DriverRepository.Find(driverID);
                    if (findDriver != null)
                    {
                        findDriver.setActive(true);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Driver is not activated against given ID", e);
                }
            }
        }

        public void createNewDriver(DataAccessLayer.Entities.Driver driver)
        {
            if (driver!= null)
            {
                unitOfWork.DriverRepository.AddNew(driver);
                unitOfWork.Save();
            }
        }

        public void deactivateDriver(int driverID)
        {
            if (driverID != 0)
            {
                try
                {
                    DataAccessLayer.Entities.Driver findDriver = unitOfWork.DriverRepository.Find(driverID);
                    if (findDriver != null)
                    {
                        findDriver.setActive(false);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Driver is not deactivated against given ID", e);
                }
            }
        }

        public void deleteDriver(int driverID)
        {
            if (driverID != 0)
            {
                try
                {
                    unitOfWork.DriverRepository.Delete(driverID);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Driver is not deleted against given ID", e);
                }
            }
        }
      
        
    }
}
