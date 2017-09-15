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
    [RoutePrefix("company")]
    public class CreditCardController : BaseWebApiController
    {
        [Route("UpdateCreditCardDetail"), HttpPost, AuthorizeAdmin, ValidateModel, AutoResponce]
        public void updateCreditCardDetail(CreditCardDetail creditcarddetail)
        {

            CompanyCreditCardDetail CompanyCreditCardDetail = new CompanyCreditCardDetail();
            CompanyCreditCardDetail.cardNo = creditcarddetail.cardNo;
            CompanyCreditCardDetail.ccvNo = creditcarddetail.ccvNo;
            CompanyCreditCardDetail.expiryDate = creditcarddetail.expiryDate;
            CompanyCreditCardDetail.holderName = creditcarddetail.holderName;
            CompanyCreditCardDetail= unitOfBussinessLogic.CompanyManager.updateCompanyCreditCard(callerCompany, CompanyCreditCardDetail);
            ResponceBuilder.Add(Labels.CREDITCARD, CompanyCreditCardDetail);
            
        }

        [Route("CreditCardDetail"), HttpGet, AuthorizeAdmin, ValidateModel, AutoResponce]
        public void getCreditCardDetail()
        {
            ResponceBuilder.Add(Labels.CREDITCARD, callerCompany.CompanyCreditCardDetail);
        }

    }




    public class CreditCardDetail
    {
       
        [Required]
        [StringLength(30)]
        public string holderName { get; set; }

        [Required]
        [StringLength(20)]
        public string cardNo { get; set; }

        [Required]
        [StringLength(3)]
        public string ccvNo { get; set; }

        public DateTime expiryDate { get; set; }
        
    }
}
