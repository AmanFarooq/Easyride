
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
    public class PassengerManager
    {
        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;
        static object allotUserNameLock = new object();
        public void activatePassenger(int passengerID)
        {
            if (passengerID != 0)
            {
                try
                {
                    DataAccessLayer.Entities.Passenger findPassenger;
                    findPassenger = unitOfWork.PassengerRepository.Find(passengerID);

                    if (findPassenger != null)
                    {
                        findPassenger.setActive(true);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e)
                {

                    throw new KeyNotFoundException("Passenger is Not activated againt given ID", e);
                }
            }

        }

        public Passenger isPhoneNumberAlreadyRegistered(Company callerCompany, string phoneNumber)
        {
            try
            {
                if (callerCompany.isPublicMode())
                {
                  return  unitOfWork.PassengerRepository.getAll().Where(d => d.phoneNo == phoneNumber && d.Company.isPublicMode()).First();
                }
                else
                {
                  return  callerCompany.Passengers.Where(d => d.phoneNo == phoneNumber).First();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

       

        public PassengerManager(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }

        public Passenger RegisterNewPassenger(Company comapny, Passenger passenger,PassengerCredential credential , out string accessToken)
        {

            if (passenger != null && comapny != null && credential!=null)
            {
                passenger.companyID = comapny.id;
               passenger= unitOfWork.PassengerRepository.AddNew(passenger);
               unitOfWork.Save();
                credential.id = passenger.id;
               credential= unitOfWork.PassengerCredentialRepository.AddNew(credential);
                unitOfWork.Save();
                accessToken = unitOfBusinessLogic.AccessManager.generateNewAccessTokenForPassenger(passenger);
                AlotUserName(passenger);
                return passenger;
            }
            else
            {
                accessToken = null;
                return null;
            }
        }
        public string AlotUserName(Passenger passenger, string username = null)
        {
            if (passenger != null)
            {
                if (username == null)
                {

                    List<string> nameParts = new List<string>();
                    List<string> nameCombinations = new List<string>();
                    nameParts = passenger.name.Split(' ').ToList();
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
                                    if (item.Length < 5 || unitOfWork.PassengerCredentialRepository.getAll().Where(d => d.username.ToLower().Equals(item)).ToList().Count > 0)
                                    {
                                        continue;
                                    }
                                }
                                catch (Exception)
                                {


                                }


                                passenger.PassengerCredential.username = item.ToLower();
                                unitOfWork.Save();
                                return item;

                            }


                        }
                        Tempusernames = new List<string>();
                        if (codeLength <= 5)
                        {


                            foreach (var item in nameCombinations)
                            {
                                Tempusernames.Add(item + passenger.phoneNo.Substring(passenger.phoneNo.Length - codeLength));
                            }

                        }
                        else
                        {

                            foreach (var item in nameCombinations)
                            {
                                Tempusernames.Add(item + unitOfBusinessLogic.UniqueCodeGenerator.RandomString(codeLength % 5, false, true));
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
                            passenger.PassengerCredential.username = username.ToLower();
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


        public string Login(string identifier, string password, out Passenger passenger)
        {
            string accessToken = null;
            if (identifier != null)
            {
                accessToken = LoginByUserName(identifier, password, out passenger);


                if (accessToken == null)
                {
                    accessToken = LoginByEmailId(identifier, password, out passenger);
                }
                else if (accessToken == null)
                {
                    accessToken = LoginByPhoneNumber(identifier, password, out passenger);
                }

            }
            else
            {
                passenger = null;
            }
            return accessToken;
        }

        public void deactivatePassenger(int passengerID)
        {
            if (passengerID != 0)
            {
                try
                {
                    DataAccessLayer.Entities.Passenger findPassenger;
                    findPassenger = unitOfWork.PassengerRepository.Find(passengerID);

                    if (findPassenger != null)
                    {
                        findPassenger.setActive(false);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e)
                {

                    throw new KeyNotFoundException("Passenger is Not Deactivated againt given ID", e);
                }
            }
        }

        public void deletePassenger(int passengerID)
        {
            if (passengerID != 0)
            {
                try
                {
                    unitOfWork.PassengerRepository.Delete(passengerID);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {

                    throw new KeyNotFoundException("Passenger Is Not deleted Against given ID", e);
                }
            }
        }

        public void updatePassenger(int passengerID, DataAccessLayer.Entities.Passenger passenger)
        {
            if (passengerID != 0)
            {
                try
                {
                    DataAccessLayer.Entities.Passenger findPassenger = unitOfWork.PassengerRepository.Find(passengerID);

                    if (findPassenger != null)

                    {

                        if (passenger.name != null)
                        {
                            findPassenger.name = passenger.name;
                        }
                        if (passenger.defaultPaymentMode != null)
                        {
                            findPassenger.defaultPaymentMode = passenger.defaultPaymentMode;
                        }


                        if (passenger.phoneNo != null)
                        {
                            findPassenger.phoneNo = passenger.phoneNo;
                        }


                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {

                    throw new KeyNotFoundException("Passenger is not Updated against given ID", e);
                }
            }
        }

        private string LoginByUserName(string userName, string password, out Passenger passenger)
        {
            try
            {
                passenger = unitOfWork.PassengerCredentialRepository.getAll().Where(d => d.username.ToLower() == userName.ToLower() && d.password == password).First().Passenger;
                if (passenger == null)
                {
                    return null;
                }
                else
                {
                    return unitOfBusinessLogic.AccessManager.generateNewAccessTokenForPassenger(passenger);
                }
            }
            catch (Exception)
            {
                passenger = null;
                return null;
            }
        }

        private string LoginByPhoneNumber(string identifier, string password, out Passenger passenger)
        {
            try
            {
                passenger = unitOfWork.PassengerCredentialRepository.getAll().Where(d => d.Passenger.phoneNo == identifier && d.password == password).First().Passenger;
                if (passenger == null)
                {
                    return null;
                }
                else
                {
                    return unitOfBusinessLogic.AccessManager.generateNewAccessTokenForPassenger(passenger);
                }
            }
            catch (Exception)
            {
                passenger = null;
                return null;
            }
        }
        private string LoginByEmailId(string email, string password, out Passenger passenger)
        {
            try
            {
                passenger = unitOfWork.PassengerCredentialRepository.getAll().Where(d => d.email.ToLower() == email.ToLower() && d.password == password).First().Passenger;
                if (passenger == null)
                {
                    return null;
                }
                else
                {
                    return unitOfBusinessLogic.AccessManager.generateNewAccessTokenForPassenger(passenger);
                }
            }
            catch (Exception)
            {
                passenger = null;
                return null;
            }
        }

        public bool isUserNameExist(string userName)
        {
            try
            {

                var result = unitOfWork.PassengerCredentialRepository.getAll().Where(d => d.username.ToLower().Equals(userName.ToLower()));
                if (result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
