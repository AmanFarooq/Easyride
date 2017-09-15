using RestFullService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;

namespace RestFullService.Filters
{
    public class AuthorizeAdmin : LoadDependenciesFromControllerContextFilter
    {
        public int AccessLevel { get; set; }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            IEnumerable<string> headerValues;
            string Token="";
            if (actionContext.Request.Headers.TryGetValues(Labels.AUTHTOKEN, out headerValues))
            {
                Token = headerValues.FirstOrDefault();
            }

            if (Token!="" && unitOfBusinessLogic.AccessManager.verifyAdmin(Token, out callerAdmin) && callerAdmin.AdminCredential.accessLevel >= AccessLevel)
            {
                callerCompany = callerAdmin.Company;
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
             HttpStatusCode.Unauthorized, "Authorization Failed! HTTP Request Header Must Contain A Valid AuthToken for authorization");
            }


            controller.callerAdmin = callerAdmin;
            controller.callerCompany = callerCompany;

        }
    }
}