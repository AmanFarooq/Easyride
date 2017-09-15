using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Newtonsoft.Json;
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
    public class CompanyController : BaseWebApiController
    {

        [HttpPost, Route("Register"), ValidateModel, AutoResponce]
        public void RegisterCompany([FromBody]CompanyRegistrationRequest req)
        {
            Company company = new Company();
            company.name = req.Company.Name;
            company.address = req.Company.Address;
            company.email = req.Company.Email;
            company.phoneNo = req.Company.PhoneNumber;

            if (req.Company.Mode == 0)
            {
                company.setPublic(false);
            }
            else
            {
                company.setPublic(true);
            }
            company.setActive(false);

            company.setTypeClient(true);

            company = unitOfBussinessLogic.CompanyManager.createNewCompany(company);

            Admin admin = new Admin();
            admin.name = req.Admin.Name;
            admin.phoneno = req.Admin.PhoneNumber;
            admin.setActive();

            AdminCredential credentials = new AdminCredential();

            credentials.password = req.Admin.Password;
            credentials.accessLevel = 90;

            if (req.Admin.Email == null)
            {
                credentials.email = req.Company.Email;
            }
            else
            {
                credentials.email = req.Admin.Email;
            }

            admin = unitOfBussinessLogic.AdminManager.createNewAdmin(company, admin, callerAdmin, credentials);

            Messages.Add( "Company Registered Sussessfully ");

            ResponceBuilder.Add(Labels.USERNAME, admin.AdminCredential.username);




        }

        [HttpPost, Route("key"), ValidateModel]
        public string getKey([FromBody ]ID id)
        {
            return unitOfBussinessLogic.AccessManager.getCompanyAccessToken(unitOfWork.CompanyRepository.Find(id.id));
        }

        public class ID
        {
            public int id;
        }

       

        public class CompanyRegistrationRequest
        {
            [Required,JsonRequired]
            public CompanyDetail Company { get; set; }
            [Required,JsonRequired]
            public AdminDetail Admin { get; set; }

        }

        public class CompanyDetail
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Address { get; set; }
            [Required]
            public string City { get; set; }
            [Required]
            public string PhoneNumber { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public int Mode { get; set; }
        }
        public class AdminDetail
        {
            [Required]
            public string Name { get; set; }

            
            public string Email { get; set; }

            [Required]
            public string PhoneNumber { get; set; }
            
            [Required]
            public string Password { get; set; }
        }
    }
}
