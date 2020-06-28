// File:    InsurancePolicy.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class InsurancePolicy

using System;

namespace Model.Medicalrecord
{
   public class InsurancePolicy : Repository.IIdentifiable<string>
    {
      private ulong insuranceId;
      private string policyId;

        public InsurancePolicy(ulong insuranceId)
        {
            this.insuranceId = insuranceId;
            this.policyId = "0";
        }

        public ulong InsuranceId
      {
         get
         {
            return insuranceId;
         }
         set
         {
            this.insuranceId = value;
         }
      }
      
      public string PolicyId
      {
         get
         {
            return policyId;
         }
         set
         {
            this.policyId = value;
         }
      }

        public string GetId()
        {
            return policyId;
        }

        public void SetId(string id)
        {
            this.policyId = id;
        }
    }
}