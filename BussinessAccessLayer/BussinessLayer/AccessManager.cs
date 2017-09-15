
using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace BusinessAccessLayer.BussinessLayer
{
    public class AccessManager
    {
        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;
        private static object adminLock = new object();
        private static object driverLock = new object();
        private static object passengerLock = new object();
        private static object companyLock = new object();
        public AccessManager(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }

        private void decodeAccessToken(string encodedToken, out int companyID, out string compqnayIdentificationKey, out int userID, out string userAccessToken)
        {
            try
            {
                string str = encodedToken;

                companyID = Int32.Parse(str.Substring(0, str.IndexOf("-")));
                str = str.Remove(0, str.IndexOf("-") + 1);


                compqnayIdentificationKey = str.Substring(0, str.IndexOf("-"));
                str = str.Remove(0, str.IndexOf("-") + 1);

                userID = Int32.Parse(str.Substring(0, str.IndexOf("-")));
                str = str.Remove(0, str.IndexOf("-") + 1);

                userAccessToken = str;
            }
            catch (Exception)
            {

                companyID = 0;
                compqnayIdentificationKey = null;
                userID = 0;
                userAccessToken = null;
            }
        }

        private void decodeAccessToken(string encodedToken, out int companyID, out string compqnayIdentificationKey)
        {
            try
            {
                string str = encodedToken;

                companyID = Int32.Parse(str.Substring(0, str.IndexOf("-")));
                str = str.Remove(0, str.IndexOf("-") + 1);


                compqnayIdentificationKey = str;
            }
            catch (Exception)
            {

                companyID =0;
                compqnayIdentificationKey = null;
            }

        }



        private string encodeAdminAccessToken(Admin admin)
        {
            try
            {
                return admin.companyID + "-" + admin.Company.identificationKey + "-" + admin.id + "-" + admin.AdminCredential.accessToken;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("Admin Does Not exixts for which you want to generaate New Token", e);
            }
        }

        private string encodeCompanyAccessToken(Company company)
        {
            try
            {
                return company.id + "-" + company.identificationKey;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("Company Does Not exixts for which you want to generaate New Token", e);
            }
        }

        private string encodeDriverAccessToken(Driver driver)
        {
            try
            {
                return driver.companyID + "-" + driver.Company.identificationKey + "-" + driver.id + "-" + driver.DriverCredential.accessToken;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("Driver does not exixts for which you want to generate New Token", e);
            }
        }

        private string encodePassengerAccessToken(Passenger passenger)
        {
            try
            {
                return passenger.companyID + "-" + passenger.Company.identificationKey + "-" + passenger.id + "-" + passenger.PassengerCredential.accessToken;

            }
            catch (Exception)
            {

                throw new KeyNotFoundException(" Passenger does not exixts for whhic you want to generate new Token");
            }
        }

        public string generateNewAccessTokenForAdmin(Admin admin)
        {
            if (admin == null)
            {
                throw new KeyNotFoundException("Admin does not exixts");
            }

            lock (adminLock)
            {

                string newAccessKey = unitOfBusinessLogic.UniqueCodeGenerator.GenerateNewAccessKeyForAdmin();
                admin.AdminCredential.accessToken = newAccessKey;
                admin.AdminCredential.accessTokenExpiry = DateTime.Now + TimeSpan.FromHours(6);
                unitOfWork.Save();
            }
            return getAdminAccessToken(admin);
        }



        public string generateNewAccessTokenForDriver(Driver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver does not exixts");
            }

            lock (driverLock)
            {
                string newAccessKey = unitOfBusinessLogic.UniqueCodeGenerator.GenerateNewAccessKeyForDriver();
                driver.DriverCredential.accessToken = newAccessKey;
                driver.DriverCredential.accessTokenExpiry = DateTime.Now + TimeSpan.FromHours(6);
                unitOfWork.Save();
            }
            return getDriverAccessToken(driver);
        }

        public string generateNewAccessTokenForCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException("Company does not exixts");
            }

            lock (companyLock)
            {
                string newAccessKey = unitOfBusinessLogic.UniqueCodeGenerator.GenerateNewAccessKeyForCompany();
                company.identificationKey = newAccessKey;
                unitOfWork.Save();
            }
            return getCompanyAccessToken(company);
        }

        public string getCompanyAccessToken(Company company)
        {
            return unitOfBusinessLogic.CryptoGraphy.Encrypt(encodeCompanyAccessToken(company), unitOfBusinessLogic.UniqueCodeGenerator.RandomString(3, true, false));

        }

        public string getPassengerAccessToken(Passenger passenger)
        {
            return unitOfBusinessLogic.CryptoGraphy.Encrypt(encodePassengerAccessToken(passenger), unitOfBusinessLogic.UniqueCodeGenerator.RandomString(3, true, false));

        }
        public string getPhoneNumberverificationKey(int id)
        {
            return unitOfBusinessLogic.CryptoGraphy.Encrypt(unitOfBusinessLogic.unitOfWork.PhoneNumberVerificationRepository.Find(id).Id.ToString(), unitOfBusinessLogic.UniqueCodeGenerator.RandomString(3, true, false));
        }
        public string getAdminAccessToken(Admin admin)
        {
            return unitOfBusinessLogic.CryptoGraphy.Encrypt(encodeAdminAccessToken(admin), unitOfBusinessLogic.UniqueCodeGenerator.RandomString(3, true, false));

        }

        public string getDriverAccessToken(Driver driver)
        {
            return unitOfBusinessLogic.CryptoGraphy.Encrypt(encodeDriverAccessToken(driver), unitOfBusinessLogic.UniqueCodeGenerator.RandomString(3, true, false));

        }

        public string generateNewAccessTokenForPassenger(Passenger passenger)
        {
            if (passenger == null)
            {
                throw new ArgumentNullException("Passenger does not exixts");

            }

            lock (passengerLock)
            {
                string newAccessKey = unitOfBusinessLogic.UniqueCodeGenerator.GenerateNewAccessKeyForPassenger();
                passenger.PassengerCredential.accessToken = newAccessKey;
                passenger.PassengerCredential.accessTokenExpiry = DateTime.Now + TimeSpan.FromHours(6);
                unitOfWork.Save();
            }
            return getPassengerAccessToken(passenger);
        }

        public bool verifyAdmin(string encryptedToken, out Admin admin)
        {
            CryptoGraphy obj = unitOfBusinessLogic.CryptoGraphy;
            string token = obj.Decrypt(encryptedToken, 3);

            int companyID, adminId;
            string identificationKey, adminAccessToken;

            decodeAccessToken(token, out companyID, out identificationKey, out adminId, out adminAccessToken);

            if (adminId != 0)
            {
                try
                {
                    Admin findAdmin = unitOfWork.AdminRepository.Find(adminId);
                    if (companyID == findAdmin.companyID && identificationKey.Equals(findAdmin.Company.identificationKey) && adminAccessToken.Equals(findAdmin.AdminCredential.accessToken))
                    {
                        admin = findAdmin;
                        return true;
                    }
                    else
                    {
                        admin = null;
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Admin is not found Against Given Key", e);
                }

            }
            else
            {
                admin = null;
                return false;
            }
        }

        public bool verifyCompany(string encryptedToken, out Company company)
        {
            CryptoGraphy obj = unitOfBusinessLogic.CryptoGraphy;
            string token = obj.Decrypt(encryptedToken, 3);
            int companyID;
            string identificationKey;
            decodeAccessToken(token, out companyID, out identificationKey);

            if (companyID != 0 && identificationKey != null)
            {
                company = unitOfWork.CompanyRepository.Find(companyID);

                if (company.id == companyID && company.identificationKey == identificationKey)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                company = null;
                return false;
            }

        }

        public bool verifyDriver(string encryptedToken, out Driver driver)
        {
            CryptoGraphy obj = unitOfBusinessLogic.CryptoGraphy;
            string token = obj.Decrypt(encryptedToken, 3);

            int companyID, driverId;
            string identificationKey, driverAccessToken;

            decodeAccessToken(token, out companyID, out identificationKey, out driverId, out driverAccessToken);

            if (driverId != 0)
            {
                try
                {
                    Driver findDriver = unitOfWork.DriverRepository.Find(driverId);
                    if (companyID == findDriver.companyID && identificationKey.Equals(findDriver.Company.identificationKey) && driverAccessToken.Equals(findDriver.DriverCredential.accessToken))
                    {
                        driver = findDriver;
                        return true;
                    }
                    else
                    {
                        driver = null;
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Driver is not found Against Given Key", e);
                }

            }
            else
            {
                driver = null;
                return false;
            }
        }

        public bool verifyPassenger(string encryptedToken, out Passenger passenger)
        {
            CryptoGraphy obj = unitOfBusinessLogic.CryptoGraphy;
            string token = obj.Decrypt(encryptedToken, 3);

            int companyID, passengerId;
            string identificationKey, passengerAccessToken;

            decodeAccessToken(token, out companyID, out identificationKey, out passengerId, out passengerAccessToken);

            if (passengerId != 0)
            {
                try
                {
                    Passenger findPassenger = unitOfWork.PassengerRepository.Find(passengerId);
                    if (companyID == findPassenger.companyID && identificationKey.Equals(findPassenger.Company.identificationKey) && passengerAccessToken.Equals(findPassenger.PassengerCredential.accessToken))
                    {

                        passenger = findPassenger;
                        return true;
                    }
                    else
                    {
                        passenger = null;
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Passenger is not found Against Given Key", e);
                }

            }
            else
            {
                passenger = null;
                return false;
            }
        }


        public bool verifyPNV(string encryptedToken, string code, out PhoneNumberVerification PNV)
        {
            int PNVID;
            CryptoGraphy obj = unitOfBusinessLogic.CryptoGraphy;
            try
            {

                PNVID = Convert.ToInt32(obj.Decrypt(encryptedToken));
            }
            catch (Exception)
            {
                PNV = null;
                return false;
            }


            if (PNVID != 0 && code != null)
            {
                PNV = unitOfWork.PhoneNumberVerificationRepository.Find(PNVID);
                if (PNV == null)
                {
                    
                     return false;
                }
                else
                {
                    if (code == PNV.verificationCode)
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
            }
            else
            {
                
                PNV = null;
                return false;
            }

        }


    }
}
