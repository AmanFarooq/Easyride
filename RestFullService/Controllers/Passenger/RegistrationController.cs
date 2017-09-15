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
    [RoutePrefix("Passenger")]
    public class RegistrationController : BaseWebApiController
    {

        [Route("checkUserName"), HttpPost, ValidateModel, AuthorizePassenger, AutoResponce]
        public void checkUsername([FromBody]UserNameClass username)
        {
            if (unitOfBussinessLogic.PassengerManager.isUserNameExist(username.UserName))
            {
                ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.NOT_ALLOWED);
                ResponceBuilder.Add(Labels.USERNAME, "NotAllowed");

            }
            else
            {

                ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.ALLOWED);
                ResponceBuilder.Add(Labels.USERNAME, "Allowed");
            }
        }

        [Route("Register"), HttpPost, ValidateModel, AuthorizeCompany, AutoResponce]
        public void Register([FromBody]RegistrationRequest req)
        {

            callerPassenger = unitOfBussinessLogic.PassengerManager.isPhoneNumberAlreadyRegistered(callerCompany, req.PhoneNumber);
            if (callerPassenger!=null)
            {
                Messages.Add("User Already registered");
                Messages.Add("Please Login to procede");
                ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.ALREADY_REGISTERED);
                return;
            }



            PhoneNumberVerification pnv;
            if (!unitOfBussinessLogic.PhoneNumberVerification.Verify(req.Key, req.Code, out pnv))
            {

                Messages.Add("Phone Number does not verified!");
                ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.UNAUTHORIZED);
                httpStatusCode = HttpStatusCode.Unauthorized;
                return;
            }

            Passenger passenger = new Passenger();
            passenger.name = req.Name;
            passenger.phoneNo = req.PhoneNumber;
            passenger.setDefaultPaymentModCash();

            PassengerCredential credential = new PassengerCredential();
            credential.password = req.Password;


            string accessToken;
            passenger = unitOfBussinessLogic.PassengerManager.RegisterNewPassenger(callerCompany, passenger, credential, out accessToken);

            ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.REGISTERED);
            ResponceBuilder.Add(Labels.AUTHTOKEN, accessToken);
            ResponceBuilder.Add(Labels.USERNAME, passenger.PassengerCredential.username);

        }



        public class UserNameClass
        {
            [Required, JsonProperty(PropertyName = Labels.USERNAME)]
            public string UserName { get; set; }
        }

        public class RegistrationRequest
        {
            [Required, MinLength(13), MaxLength(13), JsonProperty(PropertyName = Labels.PHONENO)]
            public string PhoneNumber { get; set; }
            // public string FCMToken { get; set; }
            [Required, MinLength(8), JsonProperty(PropertyName = Labels.PASSWORD)]
            public string Password { get; set; }
            [Required, JsonProperty(PropertyName = Labels.NAME)]
            public string Name { get; set; }


            [Required, JsonProperty(PropertyName = Labels.KEY)]
            public string Key { get; set; }

            [Required, JsonProperty(PropertyName = Labels.CODE)]
            public string Code { get; set; }





        }

    }
}
