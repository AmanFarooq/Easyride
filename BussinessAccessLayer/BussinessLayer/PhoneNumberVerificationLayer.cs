
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Repositories;
using DataAccessLayer.Entities;

namespace BusinessAccessLayer.BussinessLayer
{
    public class PhoneNumberVerificationLayer 
    {
        private static object Lock = new object();
        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;
        
        public PhoneNumberVerificationLayer(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }

        private PhoneNumberVerification CreateVerificationRequestCode(string phoneNumber, out int RemainingTime)
        {
            int minuts = 30;

            lock (Lock)
            {
                PhoneNumberVerification PNV;
                try
                {
                    PNV = unitOfWork.PhoneNumberVerificationRepository.FindByPhoneNumber(phoneNumber).First();
                    if (PNV == null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        if (PNV.expiryDate >= DateTime.Now )
                        {
                            RemainingTime = Convert.ToInt32((PNV.expiryDate - DateTime.Now).TotalSeconds);
                            return PNV;
                        }
                        else
                        {
                            PNV.verificationCode = unitOfBusinessLogic.UniqueCodeGenerator.generatePhoneNumberVerificationCode();
                            PNV.expiryDate = DateTime.Now + TimeSpan.FromMinutes(minuts);
                            RemainingTime = minuts * 60;
                        }
                    }

                }
                catch (Exception)
                {
                    PNV = new PhoneNumberVerification();
                    PNV.phoneNumber = phoneNumber;
                    PNV.verificationCode = unitOfBusinessLogic.UniqueCodeGenerator.generatePhoneNumberVerificationCode();
                    PNV.expiryDate = DateTime.Now + TimeSpan.FromMinutes(minuts);
                    RemainingTime = minuts * 60;
                    unitOfWork.PhoneNumberVerificationRepository.AddNew(PNV);

                }
               
                unitOfWork.Save();
                return PNV;
            }


        }

        public string generatePhoneNumberVerificationRequestKey(string phoneNumber, out int RemainingTime,out string code)
        {

            PhoneNumberVerification pnv= CreateVerificationRequestCode(phoneNumber,out RemainingTime);
            code = pnv.verificationCode;

            string encryptionKey = unitOfBusinessLogic.UniqueCodeGenerator.RandomString(3, true, false);
          return unitOfBusinessLogic.CryptoGraphy.Encrypt(pnv.Id.ToString(), encryptionKey);

        }

        public bool Verify(string key, string code,out PhoneNumberVerification PNV)
        {
          return  unitOfBusinessLogic.AccessManager.verifyPNV(key, code, out PNV);
        }

    }
}
