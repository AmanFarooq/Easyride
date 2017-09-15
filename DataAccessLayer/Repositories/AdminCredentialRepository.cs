﻿ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class AdminCredentialRepository : GenericRepository<AdminCredential>
    {
        public AdminCredentialRepository(UnitOfWork context) : base(context){}

        public void allocateNewAccessToken(int id)
        {
            try
            {
                
                string newToken="";
                //allocate ne token
                DbSet.Find(id).accessToken=newToken;
                throw new NotImplementedException("must allocate new token");


            }
            catch (Exception)
            {

                throw new KeyNotFoundException("AdminCredential is not found against given ID");
            }
        }

        public Admin getAdmin(int id)
        {
            try
            {
                return DbSet.Find(id).Admin;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("Admin Credential not found against Provided ID", e);
            }
        }

        public string status(int id)
        {
            try
            {
                return DbSet.Find(id).status;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("AdmimCredential not found against Provided ID", e);
            }
        }

        public void updateStatus(string status, int id)
        {
            if (status == null)
            {
                throw new ArgumentNullException("Status cannot be null");
            }
            try
            {
                DbSet.Find(id).status = status;
            }
            catch (Exception e)
            {

                throw new KeyNotFoundException("Admin Credential not found against Provided ID", e);
            }
        }

        
    }
}
