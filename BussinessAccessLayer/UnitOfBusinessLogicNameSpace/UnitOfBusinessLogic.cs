using BusinessAccessLayer.BussinessLayer;

using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.UnitOfBusinessLogicNameSpace
{
    //List of Logic Classes
    public partial class UnitOfBusinessLogic
    {
        //for performing exclusive tasks, used to lock threads
        static object Lock = new object();


        public UnitOfWork unitOfWork { get; private set; }
        PhoneNumberVerificationLayer _phoneNumberVerification;
        UniqueCodeGenerator _uniqueCodeGenerator;
        CryptoGraphy _cryptoGraphy;
        AccessManager _accessTokenManager;

        CompanyManager _companyManager;

        AdminManager _adminManager;
        DriverCompensationStrategyManager _DriverCompensationStrategyManager;
        

        PassengerManager _PassengerManager;


        RideManager _RideManager;

       public List<string> Messages;
    }



    //methods and ,getter setter machanism
    public partial class UnitOfBusinessLogic
    {



        public PhoneNumberVerificationLayer PhoneNumberVerification
        {
            get
            {
                if (_phoneNumberVerification == null)
                {
                    _phoneNumberVerification = new PhoneNumberVerificationLayer(this);

                }
                return _phoneNumberVerification;
            }

        }

        public PassengerManager PassengerManager
        {
            get
            {
                if (_PassengerManager == null)
                {
                    _PassengerManager = new PassengerManager(this);

                }
                return _PassengerManager;
            }

        }


       
        public DriverCompensationStrategyManager DriverCompensationStrategyManager
        {
            get
            {
                if (_DriverCompensationStrategyManager == null)
                {
                    _DriverCompensationStrategyManager = new DriverCompensationStrategyManager(this);

                }
                return _DriverCompensationStrategyManager;
            }

        }

        public UniqueCodeGenerator UniqueCodeGenerator
        {
            get
            {
                if (_uniqueCodeGenerator == null)
                {
                    _uniqueCodeGenerator = new UniqueCodeGenerator(this);
                }
                return _uniqueCodeGenerator;
            }
        }

        public CryptoGraphy CryptoGraphy
        {
            get
            {
                if (_cryptoGraphy == null)
                {
                    _cryptoGraphy = new CryptoGraphy(this);

                }
                return _cryptoGraphy;
            }

        }

        public AccessManager AccessManager
        {
            get
            {
                if (_accessTokenManager == null)
                {
                    _accessTokenManager = new AccessManager(this);

                }
                return _accessTokenManager;
            }
        }


        public CompanyManager CompanyManager
        {
            get
            {
                if (_companyManager == null)
                {
                    _companyManager = new CompanyManager(this);
                };
                return _companyManager;
            }

        }

        public AdminManager AdminManager
        {
            get
            {
                if (_adminManager == null)
                {
                    _adminManager = new AdminManager(this);

                }
                return _adminManager;
            }
        }
        public RideManager RideManager
        {
            get
            {
                if (_RideManager == null)
                {
                    _RideManager = new RideManager(this);

                }
                return _RideManager;
            }
        }

        public UnitOfBusinessLogic()
        {
            unitOfWork = new UnitOfWork();
        }

        public UnitOfBusinessLogic(UnitOfWork unitOfWork,List<string> messages)
        {
            this.Messages = messages;
            this.unitOfWork = unitOfWork;
        }



    }

}
