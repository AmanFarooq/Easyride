using ExpressiveAnnotations.Attributes;
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
    public class PassengerLoginController : BaseWebApiController
    {
        [ValidateModel, HttpPost, Route("login"), AutoResponce]
        public void LoginByUserNamePassword([FromBody]LoginRequest req)
        {
            string accessTokenIfVerified = unitOfBussinessLogic.PassengerManager.Login(req.identifier, req.password, out callerPassenger);



            if (accessTokenIfVerified != null)
            {
                ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.LOGED_IN);
                ResponceBuilder.Add(Labels.NAME, callerPassenger.name);
                ResponceBuilder.Add(Labels.EMAIL, callerPassenger.PassengerCredential.email);
                ResponceBuilder.Add(Labels.PHONENO, callerPassenger.phoneNo);
                ResponceBuilder.Add(Labels.AUTHTOKEN, accessTokenIfVerified);
                ResponceBuilder.Add(Labels.STATUS, callerPassenger.status);
                Messages.Add("Wellcome ! You are now logged in");

            }
            else
            {
                ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.LOGIN_FAIL);
                Messages.Add("Login Failed ! Username o password is invalid");
                httpStatusCode = HttpStatusCode.Unauthorized;
            }

        }

       

        public class VerificationRequest
        {
            public string token { get; set; }
        }
        public class LoginRequest
        {

            [Required(ErrorMessage = "Identifier must contain Username,Email or Phone Number"), JsonProperty(PropertyName = Labels.IDENTIFIER)]
            public string identifier { get; set; }

            [Required]
            public string password { get; set; }
        }

    }
}
