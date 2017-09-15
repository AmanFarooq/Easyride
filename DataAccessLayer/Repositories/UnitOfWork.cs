
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork
    {
        public Entities.DatabaseContext context;

        protected AdminRepository _AdminRepository;
        protected AdminConnectivityDetailRepository _AdminConnectivityDetailRepository;
        protected AdminCredentialRepository _AdminCredentialRepository;

        protected CompanyCreditCardDetailRepository _CompanyCreditCardDetailRepository;
        protected CompanyRepository _CompanyRepository;

        protected DriverBalanceSheetRepository _DriverBalanceSheetRepository;
        protected DriverCompensationStrategyRepository _DriverCompensationStrategyRepository;
        protected DriverConnectivityDetailRepository _DriverConnectivityDetailRepository;
        protected DriverCredentialRepository _DriverCredentialRepository;
        protected DriverCreditCardDetailRepository _DriverCreditCardDetailRepository;
        protected DriverRepository _DriverRepository;

        protected PromotionRepository _GeneralPromotionRepository;

        protected PassengerConnectivityDetailRepository _PassengerConnectivityDetailRepository;
        protected PassengerCredentialRepository _PassengerCredentialRepository;
        protected PassengerCreditCardDetailRepository _PassengerCreditCardDetailRepository;
        protected PassengerRepository _PassengerRepository;

        protected PhoneNumberVerificationRepository _PhoneNumberVerificationRepository;
        //protected PromotionCodeRepository _PromotionCodeRepository;
        protected RideActivityRepository _RideActivityRepository;
        protected RideBillingTransactionRepositry _RideBillingTransactionRepositry;
        protected RideInfoRepository _RideInfoRepository;
        protected RideRateStrategyRepository _RideRateStrategyRepository;
        //protected SharedRideRepository _SharedRideRepository;
        protected VehicleCategoryRepository _VehicleCategoryRepository;
        protected VehicleDetailRepository _VehicleDetailRepository;


        public UnitOfWork()
        {
            context = new Entities.DatabaseContext();

        }


        public AdminRepository AdminRepository {
            get
            {
                if (_AdminRepository == null)
                {
                    _AdminRepository = new AdminRepository(this);
                }
                return _AdminRepository;
            }
        }

        public AdminConnectivityDetailRepository AdminConnectivityDetailRepository
        {
            get {
                if (_AdminConnectivityDetailRepository == null)
                {
                    _AdminConnectivityDetailRepository = new AdminConnectivityDetailRepository(this);
                }
                return _AdminConnectivityDetailRepository;
            }
        }

        public AdminCredentialRepository AdminCredentialRepository
        {
            get
            {
                if (_AdminCredentialRepository == null)
                {
                    _AdminCredentialRepository = new AdminCredentialRepository(this);
                }
                return _AdminCredentialRepository;
            }
        }

        public CompanyCreditCardDetailRepository CompanyCreditCardDetailRepository
        {
            get
            {
                if (_CompanyCreditCardDetailRepository == null)
                {
                    _CompanyCreditCardDetailRepository = new CompanyCreditCardDetailRepository(this);
                }
                return _CompanyCreditCardDetailRepository;
            }
            
        }

        public CompanyRepository CompanyRepository
        {
            get
            {
                if (_CompanyRepository == null)
                {
                    _CompanyRepository = new CompanyRepository(this);
                }
                return _CompanyRepository;
            }
        }


        public DriverBalanceSheetRepository DriverBalanceSheetRepository
        {
            get
            {
                if (_DriverBalanceSheetRepository == null)
                {
                    _DriverBalanceSheetRepository = new DriverBalanceSheetRepository(this);
                    
                }
                return _DriverBalanceSheetRepository;
            }
        }

        public DriverCompensationStrategyRepository DriverCompensationStrategyRepository
        {
            get
            {
                if (_DriverCompensationStrategyRepository == null)
                {
                    _DriverCompensationStrategyRepository = new DriverCompensationStrategyRepository(this);
                }
                return _DriverCompensationStrategyRepository;
            }
        }


        public DriverConnectivityDetailRepository DriverConnectivityDetailRepository
        {
            get
            {
                if (_DriverConnectivityDetailRepository == null)
                {
                    _DriverConnectivityDetailRepository = new DriverConnectivityDetailRepository(this);
                }
                return _DriverConnectivityDetailRepository;
            }
        }

        public DriverCredentialRepository DriverCredentialRepository
        {
            get
            {
                if (_DriverCredentialRepository == null)
                {
                    _DriverCredentialRepository = new DriverCredentialRepository(this);
                }
                return _DriverCredentialRepository;
            }
        }


        public DriverCreditCardDetailRepository DriverCreditCardDetailRepository
        {
            get
            {
                if (_DriverCreditCardDetailRepository == null)
                {
                    _DriverCreditCardDetailRepository = new DriverCreditCardDetailRepository(this);
                }
                return _DriverCreditCardDetailRepository;
            }
        }

        public DriverRepository DriverRepository
        {
            get
            {
                if (_DriverRepository == null)
                {
                    _DriverRepository = new DriverRepository(this);
                }
                return _DriverRepository;
            }
        }

        public PromotionRepository GeneralPromotionRepository
        {
            get
            {
                if (_GeneralPromotionRepository == null)
                {
                    _GeneralPromotionRepository = new PromotionRepository(this);
                }
                return _GeneralPromotionRepository;
            }
        }

        public PassengerConnectivityDetailRepository PassengerConnectivityDetailRepository
        {
            get
            {
                if (_PassengerConnectivityDetailRepository == null)
                {
                    _PassengerConnectivityDetailRepository = new PassengerConnectivityDetailRepository(this);
                }
                return _PassengerConnectivityDetailRepository;
            }
        }


        public PassengerCredentialRepository PassengerCredentialRepository
        {
            get
            {
                if (_PassengerCredentialRepository == null)
                {
                    _PassengerCredentialRepository = new PassengerCredentialRepository(this);
                }
                return _PassengerCredentialRepository;
            }
            
        }


        public PassengerCreditCardDetailRepository PassengerCreditCardDetailRepository
        {
            get
            {
                if (_PassengerCreditCardDetailRepository == null)
                {
                    _PassengerCreditCardDetailRepository = new PassengerCreditCardDetailRepository(this);
                }
                return _PassengerCreditCardDetailRepository;
            }
        }

        public PassengerRepository PassengerRepository
        {
            get
            {
                if (_PassengerRepository == null)
                {
                    _PassengerRepository = new PassengerRepository(this);
                }
                return _PassengerRepository;
            }
        }

        public PhoneNumberVerificationRepository PhoneNumberVerificationRepository
        {
            get
            {
                if (_PhoneNumberVerificationRepository == null)
                {
                    _PhoneNumberVerificationRepository = new PhoneNumberVerificationRepository(this);
                }
                return _PhoneNumberVerificationRepository;
            }
        }

        //public PromotionCodeRepository PromotionCodeRepository
        //{
        //    get
        //    {
        //        if (_PromotionCodeRepository == null)
        //        {
        //            _PromotionCodeRepository = new PromotionCodeRepository(this);
        //        }
        //        return _PromotionCodeRepository;
        //    }
        //}


        public RideActivityRepository RideActivityRepository
        {
            get
            {
                if (_RideActivityRepository == null)
                {
                    _RideActivityRepository = new RideActivityRepository(this);
                }
                return _RideActivityRepository;
            }
        }

        public RideBillingTransactionRepositry RideBillingTransactionRepositry
        {
            get
            {
                if (_RideBillingTransactionRepositry == null)
                {
                    _RideBillingTransactionRepositry = new RideBillingTransactionRepositry(this);
                }
                return _RideBillingTransactionRepositry;
            }
        }

        public RideInfoRepository RideInfoRepository
        {

            get
            {
                if (_RideInfoRepository == null)
                {
                    _RideInfoRepository = new RideInfoRepository(this);
                }
                return _RideInfoRepository;

            }
        }

        public RideRateStrategyRepository RideRateStrategyRepository
        {
            get
            {
                if (_RideRateStrategyRepository == null)
                {
                    _RideRateStrategyRepository = new RideRateStrategyRepository(this);
                }
                return _RideRateStrategyRepository;
            }
        }

        //public SharedRideRepository SharedRideRepository
        //{
        //    get
        //    {
        //        if (_SharedRideRepository == null)
        //        {
        //            _SharedRideRepository = new SharedRideRepository(this);
        //        }
        //        return _SharedRideRepository;

        //    }
        //}

        public VehicleCategoryRepository VehicleCategoryRepository
        {
            get
            {
                if (_VehicleCategoryRepository == null)
                {
                    _VehicleCategoryRepository = new VehicleCategoryRepository(this);
                }
                return _VehicleCategoryRepository;
            }
        }


        public VehicleDetailRepository VehicleDetailRepository
        {
            get
            {
                if (_VehicleDetailRepository == null)
                {
                    _VehicleDetailRepository = new VehicleDetailRepository(this);
                }
                return _VehicleDetailRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }



    }
}
