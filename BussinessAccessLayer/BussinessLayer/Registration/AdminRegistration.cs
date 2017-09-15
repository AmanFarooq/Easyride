
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Repositories;

namespace BusinessAccessLayer.BussinessLayer.Registration
{
    class AdminRegistration
    {
        
        public void ActivateAdmin(int id)
        {

           Admin admin;
            admin = unitOfWork.AdminRepository.Find(id);
            if (admin != null)
            {

                admin.setActive(true);
                unitOfWork.Save();
            }
            else
            {
                throw new KeyNotFoundException("Admin not found!");
            }
        }

        public Admin RegisterNewAdmin(Admin admin, AdminCredential credentials)
        {

            unitOfWork.AdminRepository.AddNew(admin);
            unitOfWork.Save();

            credentials.id = admin.id;
            unitOfWork.AdminCredentialRepository.AddNew(credentials);
            unitOfWork.Save();

            return admin;

        }

        public void SuspendAdmin(int id)
        {
            Admin admin;
            admin = unitOfWork.AdminRepository.Find(id);
            if (admin!=null)
            {

                admin.setActive(false);
                unitOfWork.Save();
            }
            else
            {
                throw new KeyNotFoundException("Admin not found!");
            }
           
        }




        private static object Lock = new object();
        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;

        public AdminRegistration(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }
    }
}
