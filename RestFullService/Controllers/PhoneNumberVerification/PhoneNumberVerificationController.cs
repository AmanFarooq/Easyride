using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using BusinessAccessLayer.BussinessLayer;
using RestFullService.Filters;
using System.ComponentModel.DataAnnotations;
using RestFullService.Models;
using Newtonsoft.Json;

namespace RestFullService.Controllers.PNV
{
    public partial class PhoneNumberVerificationController : BaseWebApiController
    {

        [HttpPost, ValidateModel, Route("PNVRequest"/*PhoneNumberVerification request*/),AutoResponce]
        public void VerificationRequests([FromBody]VerificationRequest Req)
        {

            //creating phone verification request record in database
            int secondRemainingToTimeoutCode = 0;
            PhoneNumberVerificationLayer BAL = unitOfBussinessLogic.PhoneNumberVerification;
            string code;
            string key = BAL.generatePhoneNumberVerificationRequestKey(Req.PhoneNumber,out secondRemainingToTimeoutCode,out code);

            ResponceBuilder.Add(Labels.SUCCESSCODE, Codes.SUCCESSFULL);
            ResponceBuilder.Add(Labels.KEY, key);
            ResponceBuilder.Add(Labels.CODE, code);
            ResponceBuilder.Add(Labels.TIMEOUT, secondRemainingToTimeoutCode);
            ResponceBuilder.Add(Labels.PHONENO, Req.PhoneNumber);
            httpStatusCode = HttpStatusCode.OK;

            
        }

        [HttpPost ,Route("key")]
        public string getKEY([FromBody]ID id)
        {
            return unitOfBussinessLogic.AccessManager.getPhoneNumberverificationKey(id.id);
        }

        public class ID
        {
            public int id { get; set; }
        }

        public class VerificationRequest
        {
            [Required,MaxLength(13),MinLength(13), JsonProperty(PropertyName = Labels.PHONENO)]
            public string PhoneNumber { get; set; }
        }
    }
}
