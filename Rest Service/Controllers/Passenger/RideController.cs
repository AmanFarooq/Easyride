using DataAccessLayer.Entities;
using Newtonsoft.Json;
using RestFullService.Filters;
using RestFullService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestFullService.Controllers.PassengerControllers
{
    [RoutePrefix("Passenger/Ride")]
    public class RideController : BaseWebApiController
    {
        [Route("EstimateRide"),AuthorizePassenger,ValidateModel,AutoResponce]
        public void estimateRide([FromBody]RideEstimateRequest req)
        {
            BusinessAccessLayer.Models.RideEstimate asd = new BusinessAccessLayer.Models.RideEstimate();

            asd.PickUpLocation.fromLatLong(req.Latitude, req.Longitude);
            asd.Time = req.Time;
            asd.Distance = req.Distance;

            int fare;
            double surge;
            VehicleCategory VC = unitOfWork.VehicleCategoryRepository.Find(req.VehicleCategory);
            if (callerCompany != VC.Company)
            {
                ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.INVALIDREQUEST);
                Messages.Add( "Company has no Such a Vehicle Category ");
                return;
            }
            else if (!callerCompany.isActive())
            {
                ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.INVALIDREQUEST);
                Messages.Add( "Company is Disabled");
                return;
            }
            

            if (VC != null)
            {
                bool isEstimated = unitOfBussinessLogic.RideManager.CalculateRideEstimate(VC, asd, out fare, out surge);
                if (isEstimated)
                {
                    ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.SUCCESSFULL);
                    ResponceBuilder.Add(Labels.FARE, fare);
                    ResponceBuilder.Add(Labels.SURGE, surge);
                }
                else
                {
                    ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.INVALIDREQUEST);

                    Messages.Add( "The Company Domain is not properly configured");
                }
            }
            else
            {

                
            }

        }

        public class RideEstimateRequest
        {
            [Required, JsonProperty(PropertyName = Labels.LONGITUDE)]
            public double Longitude { get; set; }
            [Required, JsonProperty(PropertyName = Labels.LATITUDE)]
            public double Latitude { get; set; }
            [Required, JsonProperty(PropertyName = Labels.DISTANCE)]
            public int Distance { get; set; }
            [Required, JsonProperty(PropertyName = Labels.TIME)]
            public int Time { get; set; }
            [Required, JsonProperty(PropertyName = Labels.VEHICLE_CATEGORY)]
            public int VehicleCategory { get; set; }

        }

    }
}
