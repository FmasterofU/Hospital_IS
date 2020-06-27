// File:    InsurancePolicyRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:02:48 PM
// Purpose: Definition of Class InsurancePolicyRepository

using Class_Diagram.Repository;
using Model.Medicalrecord;
using System;
using System.Collections.Generic;

namespace Repository.Patientdata
{
   public class InsurancePolicyRepository : Repository.IRepositoryCRUD<InsurancePolicy, string>

        //PolicyId,InsuranceId

    {
        private string path = @"../../Data/insurance_policy.csv";
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
            List<string[]> data = Persistence.ReadEntryByPrimaryKey(path, id);
            if (data.Count == 1)
            {
                string policyID = data[0][0];
                uint insuranceID = uint.Parse(data[0][1]);
                InsurancePolicy ret = new InsurancePolicy(insuranceID);
                ret.SetId(policyID);
                return ret;
            }
            return null;
        }

        public InsurancePolicy Update(InsurancePolicy item)
        {
            throw new NotImplementedException();
        }

        public List<InsurancePolicy> GetAll()
        {
            throw new NotImplementedException();
        }

        public string getPath()
        {
            return path;
        }
   }
}