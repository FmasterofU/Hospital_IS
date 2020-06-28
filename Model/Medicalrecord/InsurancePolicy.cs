// File:    InsurancePolicy.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class InsurancePolicy

namespace Model.Medicalrecord
{
    public class InsurancePolicy : Repository.IIdentifiable<string>
    {
        private ulong insuranceId;
        private string policyId;

        public InsurancePolicy(ulong insuranceId)
        {
            this.insuranceId = insuranceId;
            policyId = "0";
        }

        public ulong InsuranceId
        {
            get => insuranceId;
            set => insuranceId = value;
        }

        public string PolicyId
        {
            get => policyId;
            set => policyId = value;
        }

        public string GetId()
        {
            return policyId;
        }

        public void SetId(string id)
        {
            policyId = id;
        }
    }
}