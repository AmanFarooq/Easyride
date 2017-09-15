using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.BussinessLayer
{
    public class RedundencyCheck
    {
        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;


        public RedundencyCheck(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }

        

        

        private bool isEmailExist(Company company, string email)
        {
            if (company != null)
            {
                try
                {
                    
                    if (company.email == email)
                    {
                        return true;
                    }
                    if (company.Drivers.Where(d => d.DriverCredential.email == email).ToList()!=null)
                    {
                        return true;
                    }
                    else if (company.Passengers.Where(p => p.PassengerCredential.email == email).ToList() != null)
                    {
                        return true;
                    }
                    else if (company.Admins.Where(a => a.AdminCredential.email == email).ToList() != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Company Not Found Against given ID",e);
                }
            }
            else
            {
                throw new ArgumentNullException("Email cannot be NULL");
            }
        }

        public bool isEmailExistInPublicDomain(string email)
        {
            if (email != null)
            {
                List<Company> companyList = unitOfWork.CompanyRepository.getAll().Where(m => m.mode == Flags.PUBLIC).ToList();

                foreach (var item in companyList)
                {
                    if (isEmailExist(item, email))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                throw new ArgumentNullException("Email cannot be NULL");
            }
            
        }

       

        private bool isPhoneNumberExist(Company company, string phoneNo)
        {
            if (company != null)
            {
                try
                {
                    
                    if (company.phoneNo == phoneNo)
                    {
                        return true;
                    }
                    if (company.Drivers.Where(d => d.phoneNo == phoneNo).ToList() != null)
                    {
                        return true;
                    }
                    else if (company.Passengers.Where(p => p.phoneNo == phoneNo).ToList() != null)
                    {
                        return true;
                    }
                    else if (company.Admins.Where(a => a.phoneno == phoneNo).ToList() != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Company Not Found Against given ID", e);
                }
            }
            else
            {
                throw new ArgumentNullException("PhoneNumber cannot be NULL");
            }
        }

        public bool isPhoneNumberExistInPublicDomain(string phoneNo)
        {
            if (phoneNo != null)
            {
                List<Company> companyList = unitOfWork.CompanyRepository.getAll().Where(m => m.mode == Flags.PUBLIC).ToList();

                foreach (var item in companyList)
                {
                    if (isPhoneNumberExist(item, phoneNo))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                throw new ArgumentNullException("PhoneNumber cannot be NULL");
            }

        }

        ///////////////////////////////////////////

        private bool isUserNameExist(Company company, string userName)
        {
            if (company != null)
            {
                try
                {
                    
                    
                    if (company.Drivers.Where(d => d.DriverCredential.username == userName).ToList() != null)
                    {
                        return true;
                    }
                    else if (company.Passengers.Where(p => p.PassengerCredential.username == userName).ToList() != null)
                    {
                        return true;
                    }
                    else if (company.Admins.Where(a => a.AdminCredential.username == userName).ToList() != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Company Not Found Against given ID", e);
                }
            }
            else
            {
                throw new ArgumentNullException("UserName cannot be NULL");
            }
        }

        public bool isUserNameExistInPublicDomain(string userName)
        {
            if (userName != null)
            {
                List<Company> companyList = unitOfWork.CompanyRepository.getAll().Where(m => m.mode == Flags.PUBLIC).ToList();

                foreach (var item in companyList)
                {
                    if (isEmailExist(item, userName))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                throw new ArgumentNullException("UserName cannot be NULL");
            }

        }

        public bool isUserNameAlreadyExist(Company company, string userName)
        {
            if (company==null || userName==null)
            {
                return true;
            }
            else
            {
                if (company.isPublicMode())
                {
                    return isUserNameExistInPublicDomain(userName);
                }
                else
                {
                    return isUserNameExist(company, userName);
                }
            }
        }


        public bool isPhoneNumberAlreadyExist(Company company, string phonenumber)
        {
            if (company == null || phonenumber == null)
            {
                return true;
            }
            else
            {
                if (company.isPublicMode())
                {
                    return isUserNameExistInPublicDomain(phonenumber);
                }
                else
                {
                    return isPhoneNumberExist(company, phonenumber);
                }
            }
        }
    }
}
