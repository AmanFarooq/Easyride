using RestFullService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace RestFullService.Filters
{
    public class AutoResponce :LoadDependenciesFromControllerContextFilter
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {

            try
            {
                if (Messages.Count>0)
                {
                    ResponceBuilder.Add(Labels.MESSAGE, Messages);
                }
                if (ResponceBuilder.Count>0 )
                {

                    actionExecutedContext.ActionContext.Response = actionExecutedContext.ActionContext.Request.CreateResponse(
                 controller.httpStatusCode, ResponceBuilder);
                }
            }
            catch (Exception ) {
                ResponceBuilder.Add("Exception", actionExecutedContext.Exception);
            }
            
        }
    }
}