using RestFullService.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RestFullService.Filters
{
    


    public class ValidateModel :ActionFilterAttribute
    {
        
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            if (actionContext.ActionArguments.Any(kv => kv.Value == null))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Arguments cannot be null");
            }

            if (!actionContext.ModelState.IsValid  )
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
              HttpStatusCode.BadRequest,  actionContext.ModelState );
            }

        }

       

    }
}