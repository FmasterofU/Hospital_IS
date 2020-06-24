// File:    ReferralRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:02:48 PM
// Purpose: Definition of Class ReferralRepository

using Model.Examination;
using System;
using System.Collections.Generic;

namespace Repository.Patientdata
{
   public class ReferralRepository : Repository.IRepositoryCRUD<Referral, uint>
   {
      private string path;
      private static ReferralRepository instance = null;

        private ReferralRepository() {}
      
      public static ReferralRepository GetInstance()
      {
            if (instance == null) instance = new ReferralRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public Referral Create(Referral item)
        {
            throw new NotImplementedException();
        }

        public Referral Read(uint id)
        {
            throw new NotImplementedException();
        }

        public Referral Update(Referral item)
        {
            throw new NotImplementedException();
        }

        public List<Referral> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}