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

namespace RestFullService.Controllers.AdminControllers
{
    [RoutePrefix("Admin")]
    public class AdminLoginController : BaseWebApiController
    {
        [ValidateModel,HttpPost,Route("login"),AutoResponce]
        public void LoginByUserNamePassword([FromBody]LoginRequest req)
        {
            string accessTokenIfVerified=unitOfBussinessLogic.AdminManager.Login(req.identifier,req.password,out callerAdmin);
            


            if (accessTokenIfVerified != null)
            {
                ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.VERIFIED);
                ResponceBuilder.Add(Labels.NAME, callerAdmin.name);
                ResponceBuilder.Add(Labels.EMAIL, callerAdmin.AdminCredential.email);
                ResponceBuilder.Add(Labels.ACCESSLEVEL, callerAdmin.AdminCredential.accessLevel);
                ResponceBuilder.Add(Labels.AUTHTOKEN, accessTokenIfVerified);
                ResponceBuilder.Add(Labels.STATUS, callerAdmin.status);
                ResponceBuilder.Add(Labels.REFERENCE, callerAdmin.referenceAdmin);
               
            }
            else
            {
                ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.UNVERIFIED);
                Messages.Add( "Login Failed ! Username o password is invalid");
                httpStatusCode = HttpStatusCode.Unauthorized;
            }

        }

        [HttpPost,Route("verify")]
        public object verifyAdminTest([FromBody]VerificationRequest token)
        {
           return unitOfBussinessLogic.AccessManager.verifyAdmin(token.token,out callerAdmin);
        }

        public class VerificationRequest
        {
            public string token { get; set; }
        }
        public class LoginRequest
        {

            [Required(ErrorMessage ="Identifier must contain Username,Email or Phone Number"), JsonProperty(PropertyName = Labels.IDENTIFIER)]
            public string identifier { get; set; }
            
            [Required]
            public string password { get; set; }
        }

    }
}
