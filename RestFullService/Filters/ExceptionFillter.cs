using RestFullService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace RestFullService.Filters
{
    public class ExceptionFillter :ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            ((BaseWebApiController)(actionExecutedContext.ActionContext.ControllerContext.Controller)).ResponceBuilder.Add("aman", "farooq");
        }
    }
}