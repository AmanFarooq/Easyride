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
    public class AuthorizeCompany : LoadDependenciesFromControllerContextFilter
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            IEnumerable<string> headerValues;
            string Token="";
            try
            {
                if (actionContext.Request.Headers.TryGetValues(Labels.AUTHTOKEN, out headerValues))
                {
                    Token = headerValues.FirstOrDefault();
                }
            }
            catch (Exception)
            {

                
            }

            if (Token != "" && !unitOfBusinessLogic.AccessManager.verifyCompany(Token, out callerCompany))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                 HttpStatusCode.Unauthorized, "Authorization Failed! HTTP Request Header Must Contain A Valid AuthToken for authorization");

            }
            controller.callerCompany = callerCompany;

        }
    }
}