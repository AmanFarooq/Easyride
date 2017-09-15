namespace DataAccessLayer.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminConnectivityDetail> AdminConnectivityDetails { get; set; }
        public virtual DbSet<AdminCredential> AdminCredentials { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyCreditCardDetail> CompanyCreditCardDetails { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverBalanceSheet> DriverBalanceSheets { get; set; }
        public virtual DbSet<DriverCompensationStrategy> DriverCompensationStrategies { get; set; }
        public virtual DbSet<DriverConnectivityDetail> DriverConnectivityDetails { get; set; }
        public virtual DbSet<DriverCredential> DriverCredentials { get; set; }
        public virtual DbSet<DriverCreditCardDetail> DriverCreditCardDetails { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<PassengerConnectivityDetail> PassengerConnectivityDetails { get; set; }
        public virtual DbSet<PassengerCredential> PassengerCredentials { get; set; }
        public virtual DbSet<PassengerCreditCardDetail> PassengerCreditCardDetails { get; set; }
        public virtual DbSet<PhoneNumberVerification> PhoneNumberVerifications { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<RideActivity> RideActivities { get; set; }
        public virtual DbSet<RideBillingTransaction> RideBillingTransactions { get; set; }
        public virtual DbSet<RideInfo> RideInfoes { get; set; }
        public virtual DbSet<RideRateStrategy> RideRateStrategies { get; set; }
        public virtual DbSet<VehicleCategory> VehicleCategories { get; set; }
        public virtual DbSet<VehicleCategoryMemberShip> VehicleCategoryMemberShips { get; set; }
        public virtual DbSet<VehicleDetail> VehicleDetails { get; set; }
        public virtual DbSet<VehicleDriverMembership> VehicleDriverMemberships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.phoneno)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Admin1)
                .WithOptional(e => e.Admin2)
                .HasForeignKey(e => e.referenceAdmin);

            modelBuilder.Entity<Admin>()
                .HasOptional(e => e.AdminConnectivityDetail)
                .WithRequired(e => e.Admin);

            modelBuilder.Entity<Admin>()
                .HasOptional(e => e.AdminCredential)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AdminConnectivityDetail>()
                .Property(e => e.fcmToken)
                .IsUnicode(false);

            modelBuilder.Entity<AdminConnectivityDetail>()
                .Property(e => e.signalRConnectivityID)
                .IsUnicode(false);

            modelBuilder.Entity<AdminCredential>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<AdminCredential>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<AdminCredential>()
                .Property(e => e.accessToken)
                .IsUnicode(false);

            modelBuilder.Entity<AdminCredential>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<AdminCredential>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.phoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.identificationKey)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.mode)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Admins)
                .WithOptional(e => e.Company)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Company>()
                .HasOptional(e => e.CompanyCreditCardDetail)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Company>()
                .HasOptional(e => e.Configuration)
                .WithRequired(e => e.Company);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Drivers)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyCreditCardDetail>()
                .Property(e => e.holderName)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyCreditCardDetail>()
                .Property(e => e.cardNo)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyCreditCardDetail>()
                .Property(e => e.ccvNo)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.phoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.cnic)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.availabilityStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .HasOptional(e => e.DriverCreditCardDetail)
                .WithRequired(e => e.Driver)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Driver>()
                .HasOptional(e => e.DriverBalanceSheet)
                .WithRequired(e => e.Driver)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Driver>()
                .HasOptional(e => e.DriverConnectivityDetail)
                .WithRequired(e => e.Driver);

            modelBuilder.Entity<Driver>()
                .HasOptional(e => e.DriverCredential)
                .WithRequired(e => e.Driver)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.VehicleDetails)
                .WithOptional(e => e.Driver)
                .HasForeignKey(e => e.currentDriver);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.VehicleDriverMemberships)
                .WithOptional(e => e.Driver1)
                .HasForeignKey(e => e.Driver);

            modelBuilder.Entity<DriverConnectivityDetail>()
                .Property(e => e.fcmToken)
                .IsUnicode(false);

            modelBuilder.Entity<DriverConnectivityDetail>()
                .Property(e => e.SignalRConnectivityID)
                .IsUnicode(false);

            modelBuilder.Entity<DriverCredential>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<DriverCredential>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<DriverCredential>()
                .Property(e => e.accessToken)
                .IsUnicode(false);

            modelBuilder.Entity<DriverCredential>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<DriverCredential>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<DriverCreditCardDetail>()
                .Property(e => e.holderName)
                .IsUnicode(false);

            modelBuilder.Entity<DriverCreditCardDetail>()
                .Property(e => e.cardNo)
                .IsUnicode(false);

            modelBuilder.Entity<DriverCreditCardDetail>()
                .Property(e => e.ccvNo)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.phoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.defaultPaymentMode)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<Passenger>()
                .HasOptional(e => e.PassengerCreditCardDetail)
                .WithRequired(e => e.Passenger)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Passenger>()
                .HasOptional(e => e.PassengerConnectivityDetail)
                .WithRequired(e => e.Passenger);

            modelBuilder.Entity<Passenger>()
                .HasOptional(e => e.PassengerCredential)
                .WithRequired(e => e.Passenger)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PassengerConnectivityDetail>()
                .Property(e => e.fcmToken)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerConnectivityDetail>()
                .Property(e => e.signalRConnectionID)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerCredential>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerCredential>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerCredential>()
                .Property(e => e.accessToken)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerCredential>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerCredential>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerCreditCardDetail>()
                .Property(e => e.holderName)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerCreditCardDetail>()
                .Property(e => e.cardNo)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerCreditCardDetail>()
                .Property(e => e.ccvNo)
                .IsUnicode(false);

            modelBuilder.Entity<PhoneNumberVerification>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<PhoneNumberVerification>()
                .Property(e => e.verificationCode)
                .IsUnicode(false);

            modelBuilder.Entity<Promotion>()
                .Property(e => e.promotionType)
                .IsUnicode(false);

            modelBuilder.Entity<Promotion>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Promotion>()
                .Property(e => e.promotionCode)
                .IsUnicode(false);

            modelBuilder.Entity<RideActivity>()
                .Property(e => e.requestStatus)
                .IsUnicode(false);

            modelBuilder.Entity<RideActivity>()
                .Property(e => e.activityStatus)
                .IsUnicode(false);

            modelBuilder.Entity<RideActivity>()
                .Property(e => e.paymentMode)
                .IsUnicode(false);

            modelBuilder.Entity<RideActivity>()
                .HasOptional(e => e.RideBillingTransaction)
                .WithRequired(e => e.RideActivity)
                .WillCascadeOnDelete();

            modelBuilder.Entity<RideActivity>()
                .HasOptional(e => e.RideInfo)
                .WithRequired(e => e.RideActivity)
                .WillCascadeOnDelete();

            modelBuilder.Entity<RideBillingTransaction>()
                .Property(e => e.overallStatus)
                .IsUnicode(false);

            modelBuilder.Entity<RideBillingTransaction>()
                .Property(e => e.driverPayableStatus)
                .IsUnicode(false);

            modelBuilder.Entity<RideBillingTransaction>()
                .Property(e => e.paymentMode)
                .IsUnicode(false);

            modelBuilder.Entity<RideBillingTransaction>()
                .Property(e => e.passengerPayableStatus)
                .IsUnicode(false);

            modelBuilder.Entity<RideBillingTransaction>()
                .Property(e => e.companyPayableStatus)
                .IsUnicode(false);

            modelBuilder.Entity<RideInfo>()
                .Property(e => e.pickupAddress)
                .IsUnicode(false);

            modelBuilder.Entity<RideInfo>()
                .Property(e => e.destinationAddress)
                .IsUnicode(false);

            modelBuilder.Entity<RideInfo>()
                .Property(e => e.extraDetail)
                .IsUnicode(false);

            modelBuilder.Entity<RideRateStrategy>()
                .Property(e => e.strategyType)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleCategory>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleCategory>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleCategory>()
                .Property(e => e.iconPath)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleCategory>()
                .HasMany(e => e.RideActivities)
                .WithOptional(e => e.VehicleCategory)
                .HasForeignKey(e => e.VehicleCatagoryID);

            modelBuilder.Entity<VehicleCategory>()
                .HasMany(e => e.RideRateStrategies)
                .WithRequired(e => e.VehicleCategory)
                .HasForeignKey(e => e.vehicleCatagoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VehicleCategory>()
                .HasMany(e => e.VehicleCategory1)
                .WithOptional(e => e.VehicleCategory2)
                .HasForeignKey(e => e.parentCategory);

            modelBuilder.Entity<VehicleCategory>()
                .HasMany(e => e.VehicleDetails)
                .WithOptional(e => e.VehicleCategory)
                .HasForeignKey(e => e.category);

            modelBuilder.Entity<VehicleDetail>()
                .Property(e => e.VIN)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleDetail>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleDetail>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleDetail>()
                .HasMany(e => e.RideActivities)
                .WithOptional(e => e.VehicleDetail)
                .HasForeignKey(e => e.vehicle);

            modelBuilder.Entity<VehicleDetail>()
                .HasMany(e => e.VehicleDriverMemberships)
                .WithOptional(e => e.VehicleDetail)
                .HasForeignKey(e => e.vehicle);

            modelBuilder.Entity<VehicleDriverMembership>()
                .HasMany(e => e.Drivers)
                .WithOptional(e => e.VehicleDriverMembership)
                .HasForeignKey(e => e.currentVehicleMembership);
        }
    }
}
