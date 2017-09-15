
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
    public class AdminManager
    {

        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;
        static object allotUserNameLock = new object();


        public AdminManager(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }

        private string LoginByUserName(string userName, string password, out Admin admin)
        {
            try
            {
                admin = unitOfWork.AdminCredentialRepository.getAll().Where(d => d.username.ToLower() == userName.ToLower() && d.password == password).First().Admin;
                if (admin == null)
                {
                    return null;
                }
                else
                {
                    return unitOfBusinessLogic.AccessManager.generateNewAccessTokenForAdmin(admin);
                }
            }
            catch (Exception)
            {
                admin = null;
                return null;
            }
        }

        private string LoginByPhoneNumber(string identifier, string password, out Admin admin)
        {
            try
            {
                admin = unitOfWork.AdminCredentialRepository.getAll().Where(d => d.Admin.phoneno == identifier && d.password == password).First().Admin;
                if (admin == null)
                {
                    return null;
                }
                else
                {
                    return unitOfBusinessLogic.AccessManager.generateNewAccessTokenForAdmin(admin);
                }
            }
            catch (Exception)
            {
                admin = null;
                return null;
            }
        }

        public string Login(string identifier, string password, out Admin admin)
        {
            string accessToken = null;
            if (identifier != null)
            {
                accessToken = LoginByUserName(identifier, password, out admin);


                if (accessToken == null)
                {
                    accessToken = LoginByEmailId(identifier, password, out admin);
                }
                else if (accessToken == null)
                {
                    accessToken = LoginByPhoneNumber(identifier, password, out admin);
                }

            }
            else
            {
                admin = null;
            }
            return accessToken;
        }
        private string LoginByEmailId(string email, string password, out Admin admin)
        {
            try
            {
                admin = unitOfWork.AdminCredentialRepository.getAll().Where(d => d.email.ToLower() == email.ToLower() && d.password == password).First().Admin;
                if (admin == null)
                {
                    return null;
                }
                else
                {
                    return unitOfBusinessLogic.AccessManager.generateNewAccessTokenForAdmin(admin);
                }
            }
            catch (Exception)
            {
                admin = null;
                return null;
            }
        }

        public void activateAdmin(int adminID)
        {
            if (adminID != 0)
            {
                try
                {
                    DataAccessLayer.Entities.Admin findAdmin = unitOfWork.AdminRepository.Find(adminID);
                    if (findAdmin != null)
                    {
                        findAdmin.setActive(true);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Admin is not activated against given ID", e);
                }
            }
        }

        public Admin createNewAdmin(Company company, Admin newAdmin, Admin referenceAdmin, AdminCredential credential)
        {

            if (newAdmin != null && company != null && credential != null)
            {
                if (referenceAdmin != null)
                {
                    newAdmin.referenceAdmin = referenceAdmin.id;
                }

                newAdmin.companyID = company.id;
                newAdmin = unitOfWork.AdminRepository.AddNew(newAdmin);
                unitOfWork.Save();

                credential.id = newAdmin.id;
                credential = unitOfWork.AdminCredentialRepository.AddNew(credential);
                unitOfWork.Save();
                AlotUserName(newAdmin);
                return newAdmin;
            }
            return null;
        }

        public string AlotUserName(Admin admin, string username = null)
        {
            if (admin != null)
            {
                if (username == null)
                {

                    List<string> nameParts = new List<string>();
                    List<string> nameCombinations = new List<string>();
                    nameParts = admin.name.Split(' ').ToList();
                    nameCombinations.AddRange(nameParts);
                    
                    foreach (var item in nameParts)
                    {
                        foreach (var inneritem in nameParts)
                        {
                            if (item == inneritem)
                            {
                                continue;
                            }
                            else
                            {
                                nameCombinations.Add(item + inneritem);

                            }
                        }
                    }


                    List<string> Tempusernames = new List<string>();
                    Tempusernames.AddRange(nameCombinations);
                    int codeLength = 3;
                    while (true)
                    {

                        Tempusernames.Sort((a, b) => a.Length.CompareTo(b.Length));
                        foreach (var item in Tempusernames)
                        {

                            lock (allotUserNameLock)
                            {


                                try
                                {
                                    if (item.Length<5 || unitOfWork.AdminCredentialRepository.getAll().Where(d => d.username.ToLower().Equals(item)).ToList().Count > 0)
                                    {
                                        continue;
                                    }
                                }
                                catch (Exception)
                                {

                                    
                                }
                                

                                admin.AdminCredential.username = item.ToLower();
                                unitOfWork.Save();
                                return item;

                            }


                        }
                        Tempusernames = new List<string>();
                        if (codeLength<=5)
                        {

                         
                            foreach (var item in nameCombinations)
                            {
                                Tempusernames.Add(item + admin.phoneno.Substring(admin.phoneno.Length - codeLength));
                            }
                            
                        }
                        else
                        {
                           
                            foreach (var item in nameCombinations)
                            {
                                Tempusernames.Add(item + unitOfBusinessLogic.UniqueCodeGenerator.RandomString(codeLength%5,false,true));
                            }
                            
                        }

                        codeLength++;

                    }
                    

                }
                else
                {

                    lock (allotUserNameLock)
                    {
                        if (unitOfWork.AdminCredentialRepository.getAll().Where(d => d.username == username) == null)
                        {
                            throw new Exception("UserName Already Exist");
                        }
                        else
                        {
                            admin.AdminCredential.username = username.ToLower();
                            unitOfWork.Save();
                            return username; ;
                        }
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public void deactivateAdmin(int adminID)
        {
            if (adminID != 0)
            {
                try
                {
                    DataAccessLayer.Entities.Admin findAdmin = unitOfWork.AdminRepository.Find(adminID);
                    if (findAdmin != null)
                    {
                        findAdmin.setActive(false);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Admin is not deactivated against given ID", e);
                }
            }
        }

        public void deleteAdmin(int adminID)
        {
            if (adminID != 0)
            {
                try
                {
                    unitOfWork.AdminRepository.Delete(adminID);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Admin is not deleted against given ID", e);
                }
            }
        }

        public void updateAdmin(int adminID, DataAccessLayer.Entities.Admin admin)
        {
            if (adminID != 0)
            {

                try
                {
                    DataAccessLayer.Entities.Admin findAdmin = unitOfWork.AdminRepository.Find(adminID);
                    if (findAdmin != null)
                    {
                        if (admin.name != null)
                        {
                            findAdmin.name = admin.name;
                        }

                        if (admin.phoneno != null)
                        {
                            findAdmin.phoneno = admin.phoneno;
                        }
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Admin is not updated against given ID", e);
                }
            }
        }

        public void AssignCredentials(int adminID, AdminCredential credentials)
        {
            credentials.id = adminID;
            unitOfWork.AdminCredentialRepository.AddNew(credentials);
            unitOfWork.Save();
        }

        public void updateAdminCredential(int adminID, AdminCredential adminCredential)
        {

            if (adminID != 0)
            {
                try
                {
                    AdminCredential findAdminCredential = unitOfWork.AdminCredentialRepository.Find(adminID);

                    if (findAdminCredential != null)
                    {

                        if (adminCredential.password != null)
                        {
                            findAdminCredential.password = adminCredential.password;
                        }


                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {

                    throw new KeyNotFoundException("AdminCredential not found against given ID", e);
                }
            }
        }
    }
}
