using BusinessAccessLayer.Models;
using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.BussinessLayer
{
    public class RideManager
    {
        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;


        public RideManager(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }



        public bool CalculateRideEstimate(VehicleCategory Vcatagory, RideEstimate req, out int fare, out double surge)
        {

            try
            {
                if (req != null && req.isValid())
                {
                    Configuration configuration = Vcatagory.Company.Configuration;

                    RideRateStrategy strategy = unitOfWork.RideRateStrategyRepository.getAll().Where(d => d.isCurrentStrategy()).First();
                    DbGeometry pickupPoint = DbGeometry.FromText(req.PickUpLocation.ToWkt());
                    surge = 1;

                    IQueryable<RideActivity> rideactivities;
                    if (Vcatagory.Company.isPublicMode())
                    {
                        unitOfBusinessLogic.Messages.Add("Public Mode Company");
                        rideactivities = unitOfWork.RideActivityRepository.getAll().Where(d => d.Company.isPublicMode() && d.VehicleCategory==Vcatagory).AsQueryable();
                    }
                    else
                    {
                        unitOfBusinessLogic.Messages.Add("Private Mode Company");
                        rideactivities = Vcatagory.RideActivities.AsQueryable();
                    }

                    if (strategy.isSurgeApplied())
                    {
                        unitOfBusinessLogic.Messages.Add("Surge Applied");

                        int count = rideactivities.Count(d => d.isRideMade() && d.requestTime >= DateTime.Now - TimeSpan.FromMinutes((double)(configuration.SurgeTimespan / 60)) && d.RideInfo.pickupLocation.Distance(pickupPoint) <= configuration.SurgeBuffer);
                        if (count > configuration.SurgeMinCount)
                        {
                            count -= configuration.SurgeMinCount;
                            surge += count * configuration.SurgeIncrementalRatio;
                        }
                    }

                    fare = Convert.ToInt32((req.Distance * (strategy.perKmMoving / 1000) + req.Time * (strategy.perMinuteMoving / 60)));
                    fare = Convert.ToInt32(fare * surge);
                    return true;
                }
                else {
                    surge = 0; fare = 0;
                    return false;
                }
            }
            catch (Exception)
            {
                surge = 0;fare = 0;
                return false;
            }

        }
    }
}
