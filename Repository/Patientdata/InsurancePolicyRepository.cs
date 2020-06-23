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
      private InsurancePolicyRepository instance;
      
      public static InsurancePolicyRepository GetInstance()
      {
         throw new NotImplementedException();
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

        public InsurancePolicyRepository insurancePolicyRepositoryB;
   
   }
}