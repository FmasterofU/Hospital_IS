// File:    InsurancePolicyRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:02:48 PM
// Purpose: Definition of Class InsurancePolicyRepository

using Model.Medicalrecord;
using System;
using System.Collections.Generic;

namespace Repository.Patientdata
{
   public class InsurancePolicyRepository : Repository.IRepositoryCRUD<InsurancePolicy, string>
   {
      private string path;
      private static InsurancePolicyRepository instance = null;

        private InsurancePolicyRepository() {}
      
      public static InsurancePolicyRepository GetInstance()
      {
            if (instance == null) instance = new InsurancePolicyRepository();
            return instance;
      }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public InsurancePolicy Create(InsurancePolicy item)
        {
            throw new NotImplementedException();
        }

        public InsurancePolicy Read(string id)
        {
            throw new NotImplementedException();
        }

        public InsurancePolicy Update(InsurancePolicy item)
        {
            throw new NotImplementedException();
        }

        public List<InsurancePolicy> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}