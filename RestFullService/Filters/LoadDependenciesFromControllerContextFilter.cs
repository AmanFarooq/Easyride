using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using RestFullService.Controllers;
using System.Net;
using System.Net.Http;
using DataAccessLayer.Entities;

namespace RestFullService.Filters
{
    public abstract class LoadDependenciesFromControllerContextFilter :ActionFilterAttribute
    {
     
      
        protected UnitOfBusinessLogic unitOfBusinessLogic;
       protected UnitOfWork unitOfWork;
       protected Dictionary<string, object> ResponceBuilder;
        protected List<string> Messages;

        protected Driver callerDriver;
        protected Admin callerAdmin;
        protected Passenger callerPassenger;
        protected Company callerCompany;
        protected BaseWebApiController controller;
        public override bool AllowMultiple
        {
            get
            {
                return false;
            }
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            
            try
            {
                controller = ((BaseWebApiController)(actionContext.ControllerContext.Controller));
                unitOfBusinessLogic = controller.unitOfBussinessLogic;
                unitOfWork = controller.unitOfWork;
                ResponceBuilder = controller.ResponceBuilder;
                Messages = controller.Messages;

              
            }
            catch (Exception e)
            {

                throw new InvalidOperationException("Controller not found while casting to base controller in actionfilterattribute",e);
            }

            
        }
        
        
      

    }
}