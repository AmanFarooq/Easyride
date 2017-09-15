
using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;
using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Repositories;

namespace BusinessAccessLayer.BussinessLayer.Registration
{
    class CompanyRegistration
    {
        public void ActivateCompany(int id)
        {
            Company company;
            
            company = unitOfWork.CompanyRepository.Find(id);
            if (company != null)
            {

                company.setActive(true);
                unitOfWork.Save();
            }
            else
            {
                throw new KeyNotFoundException("Company not found!");
            }

        }

        public Company RegisterNewCompany(Company company)
        {

            unitOfWork.CompanyRepository.AddNew(company);
            unitOfWork.Save();
            return company;

        }

        public void SuspendCompany(int id)
        {
            Company company;

            company = unitOfWork.CompanyRepository.Find(id);
            if (company != null)
            {

                company.setActive(true);
                unitOfWork.Save();
            }
            else
            {
                throw new KeyNotFoundException("Company not found!");
            }
        }

        public void updateCredentials(int companyID, CompanyCreditCardDetail creditCardDetail)
        {
            throw new NotImplementedException();
        }

        private static object Lock = new object();
        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;

        public CompanyRegistration(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }
    }
}
