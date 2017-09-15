using DataAccessLayer.Entities;
using RestFullService.Filters;
using RestFullService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestFullService.Controllers.CompanyControllers
{
    [RoutePrefix("Company")]
    public class DriverCompensationController : BaseWebApiController
    {

        [Route("NewStrategy"),HttpPost,AuthorizeAdmin,ValidateModel,AutoResponce]
        public void AddNewCompensationStrategy([FromBody]CompensationStrategy strategy)
        {
            DriverCompensationStrategy entity = new DriverCompensationStrategy();

            entity.driverPercentage = strategy.Compensation;
           entity= unitOfBussinessLogic.DriverCompensationStrategyManager.createNewStrategy(callerCompany, entity);

            if (entity!=null)
            {
                ResponceBuilder.Add(Labels.COMPENSATIONSTRATEGY, strategy);
                
            }
            else
            {
                ResponceBuilder.Add(Labels.COMPENSATIONSTRATEGY, null);
                httpStatusCode = HttpStatusCode.BadRequest;
            }

        }


        [Route("GetAllStrategies"), HttpGet, AuthorizeAdmin, AutoResponce]
        public void GetAllCompensationstrategies()
        {
            ResponceBuilder.Add(Labels.COMPENSATIONSTRATEGY, unitOfWork.DriverCompensationStrategyRepository.getAll().Where(d => d.companyID == callerCompany.id));

        }
        [Route("ActivateStrategy"), HttpPost, ValidateModel, AuthorizeAdmin, AutoResponce]
        public void ActivateCompensationstrategies(CompensationStrategyID stretegy)
        {

            DriverCompensationStrategy entity= unitOfBussinessLogic.DriverCompensationStrategyManager.activateStrategy(callerCompany, stretegy.CompensationID);

            if (entity!=null)
            {
                ResponceBuilder.Add(Labels.COMPENSATIONSTRATEGY, entity);
            }
            else
            {
                ResponceBuilder.Add(Labels.COMPENSATIONSTRATEGY, null);
                httpStatusCode = HttpStatusCode.BadRequest;
            }
        }





        public class CompensationStrategy
        {
            [Required]
            public double Compensation { get; set; }
        }
        public class CompensationStrategyID
        {
            [Required]
            public int CompensationID { get; set; }
        }

    }
}
