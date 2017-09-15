using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;
using System.Web.Http.Results;

namespace RestFullService.Controllers
{
    public class BaseWebApiController : ApiController
    {
        public UnitOfBusinessLogic unitOfBussinessLogic;
        public UnitOfWork unitOfWork;
        public Dictionary<string, object> ResponceBuilder;
        public Driver callerDriver;
        public Admin callerAdmin;
        public Passenger callerPassenger;
        public Company callerCompany;
        public List<string> Messages;
        public HttpStatusCode httpStatusCode = HttpStatusCode.OK;
        public BaseWebApiController()
        {
            unitOfWork = new UnitOfWork();
            Messages = new List<string>();
            unitOfBussinessLogic = new UnitOfBusinessLogic(unitOfWork,Messages);
            ResponceBuilder = new Dictionary<string, object>();


        }
       
    }
}
