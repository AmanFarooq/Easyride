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

namespace RestFullService.Controllers.Registration
{
    [RoutePrefix("Admin")]
    public class AdminRegistrationController : BaseWebApiController
    {
        
        [HttpPost,Route("Register"),AuthorizeAdmin,ValidateModel,AutoResponce]
        public void  CreateNewAdmin([FromBody] RegistrationRequest req)
        {
            Admin admin = new Admin();
            admin.name = req.Name;
            admin.phoneno = req.PhoneNo;

            AdminCredential credentials = new AdminCredential();
            credentials.email = req.Email;
            credentials.password = req.Password;
            credentials.accessLevel = req.AccessLevel;


            admin= unitOfBussinessLogic.AdminManager.createNewAdmin(callerCompany, admin, callerAdmin, credentials);

            Messages.Add( "Admin Created Successfully !");
            ResponceBuilder.Add(Labels.USERNAME, admin.AdminCredential.username);
            ResponceBuilder.Add(Labels.NAME, admin.name);
        }

        




        public class RegistrationRequest
        {

            [Required]
            [StringLength(50)]
            public string Name { get; set; }

         
            [Required]
            public string PhoneNo { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            public int AccessLevel { get; set; }
            

        }



    }
}
