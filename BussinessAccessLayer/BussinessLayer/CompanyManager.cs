
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
    public class CompanyManager 
    {

        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;


        public CompanyManager(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }

        public void activateCompany(int companyID)
        {
            if (companyID != 0)
            {
                try
                {
                    DataAccessLayer.Entities.Company findCompany;
                    findCompany = unitOfWork.CompanyRepository.Find(companyID);

                    if (findCompany != null)
                    {
                        findCompany.setActive(true);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e)
                {

                    throw new KeyNotFoundException("company is Not activated againt given ID", e);
                }
            }

        }

        public Company createNewCompany(DataAccessLayer.Entities.Company company)
        {
            if (company != null)
            {

                unitOfWork.CompanyRepository.AddNew(company);
                unitOfBusinessLogic.AccessManager.generateNewAccessTokenForCompany(company);
                unitOfWork.Save();
            }
            return company;
        }

        public void deactivateCompany(int companyID)
        {
            if (companyID != 0)
            {
                try
                {
                    DataAccessLayer.Entities.Company findCompany;
                    findCompany = unitOfWork.CompanyRepository.Find(companyID);

                    if (findCompany != null)
                    {
                        findCompany.setActive(false);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e)
                {

                    throw new KeyNotFoundException("company is Not deactivated againt given ID", e);
                }
            }
        }

        public void deleteCompany(int companyID)
        {
            if (companyID != 0)
            {
                try
                {

                    unitOfWork.CompanyRepository.Delete(companyID);
                    unitOfWork.Save();


                }
                catch (Exception e)
                {

                    throw new KeyNotFoundException("Company Is Not deleted Against given ID", e);
                }
            }
        }

        public void updateCompany(int companyID, DataAccessLayer.Entities.Company company)
        {
            if (companyID != 0)
            {
                try
                {
                    DataAccessLayer.Entities.Company findCompany;
                    findCompany = unitOfWork.CompanyRepository.Find(companyID);

                    if (findCompany != null)
                    {
                        if (company.address != null)
                        {
                            findCompany.address = company.address;
                        }

                        if (company.email != null)
                        {
                            findCompany.email = company.email;
                        }
                        if (company.identificationKey != null)
                        {
                            findCompany.identificationKey = company.identificationKey;
                        }
                        if (company.mode != null)
                        {
                            findCompany.mode = company.mode;

                        }
                        if (company.name != null)
                        {
                            findCompany.name = company.name;
                        }

                        if (company.phoneNo != null)
                        {
                            findCompany.phoneNo = company.phoneNo;
                        }
                        if (company.type != null)
                        {
                            findCompany.type = company.type;
                        }

                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {

                    throw new KeyNotFoundException("company is Not Updated againt given ID", e);
                }
            }
        }

        public CompanyCreditCardDetail updateCompanyCreditCard(Company company, CompanyCreditCardDetail CreditCardDetail)
        {
            if (company != null && CreditCardDetail != null)
            {
                CompanyCreditCardDetail findCreditCard = company.CompanyCreditCardDetail;
                if (findCreditCard == null)
                {
                    unitOfWork.CompanyCreditCardDetailRepository.Delete(findCreditCard.id);
                }

                CreditCardDetail.id = company.id;
                unitOfWork.CompanyCreditCardDetailRepository.AddNew(CreditCardDetail);
                return CreditCardDetail;

            }
            else
            {
                return null;
            }
        }
    }
}
