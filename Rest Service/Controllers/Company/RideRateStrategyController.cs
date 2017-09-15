using RestFullService.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestFullService.Controllers.CompanyControllers
{
    [RoutePrefix("Company")]
    public class RideRateStrategyController : BaseWebApiController
    {
        [Route("NewVehicalCategory"), HttpPost , AuthorizeAdmin , ValidateModel , AutoResponce]
        public void AddNewCompensationStrategy([FromBody]VehicalCategory vehicalCategory)
        {
            

        }

        public class VehicalCategory
        {
        }
    }
}
