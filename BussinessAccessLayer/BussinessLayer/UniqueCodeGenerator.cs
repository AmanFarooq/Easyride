
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Repositories;

namespace BusinessAccessLayer.BussinessLayer
{
    public class UniqueCodeGenerator 
    {
        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;

        public UniqueCodeGenerator(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }

        public string generatePhoneNumberVerificationCode()
        {
            //throw new NotImplementedException();

            return RandomString(4,false,true);
        }


        public string GenerateNewAccessKeyForPassenger()
        {
            
            while (true)
            {
                string key = RandomString(50, true, true);
                if (unitOfWork.PassengerCredentialRepository.getAll().Where(d=>d.accessToken==key).ToList().Count>0)
                {
                    continue;
                }
                return key;
            }
        }

        public string GenerateNewAccessKeyForDriver()
        {

            while (true)
            {
                string key = RandomString(50, true, true);
                if (unitOfWork.DriverCredentialRepository.getAll().Where(d => d.accessToken == key).ToList().Count > 0)
                {
                    continue;
                }
                return key;
            }
        }

        public string GenerateNewAccessKeyForCompany()
        {

            while (true)
            {
                string key = RandomString(10, true, true);
                if (unitOfWork.CompanyRepository.getAll().Where(d => d.identificationKey == key).ToList().Count > 0)
                {
                    continue;
                }
                return key;
            }
        }

        public string GenerateNewAccessKeyForAdmin()
        {

            while (true)
            {
                string key = RandomString(50, true, true);
                if (unitOfWork.AdminCredentialRepository.getAll().Where(d => d.accessToken == key).ToList().Count > 0)
                {
                    continue;
                }
                return key;
            }
        }







        public string RandomString(int length, bool Alphabets, bool digits)
        {
            Random random = new Random();
            const string alp = "ABCDEFGHIJKLMNOPQRSTUVWXYZqwertyuiopasdfghjklzxcvbnm";
            const string dgt = "1234567890";
            string chars = "";
            if (Alphabets)
            {
                chars += alp;
            }
            if (digits)
            {
                chars += dgt;
            }

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
