// File:    MedicalRecord.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class MedicalRecord

using Model.Roles;
using System.Collections.Generic;
using System.Text;

namespace Model.Medicalrecord
{
    public class MedicalRecord : Repository.IIdentifiable<uint>
    {
        private uint id;

        public InsurancePolicy insurancePolicy;
        public System.Collections.Generic.List<Model.Examination.Examination> examination;

        public MedicalRecord(InsurancePolicy insurancePolicy, List<Examination.Examination> examination, Patient patient)
        {
            id = 0;
            this.insurancePolicy = insurancePolicy;
            this.examination = examination;
            this.patient = patient;
        }

        public MedicalRecord(InsurancePolicy insurancePolicy, Patient patient)
        {
            id = 0;
            this.patient = patient;
            examination = new List<Examination.Examination>();
            this.insurancePolicy = insurancePolicy;
        }



        /// <summary>
        /// Property for collection of Model.Examination.Examination
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Model.Examination.Examination> Examination
        {
            get
            {
                if (examination == null)
                {
                    examination = new System.Collections.Generic.List<Model.Examination.Examination>();
                }

                return examination;
            }
            set
            {
                RemoveAllExamination();
                if (value != null)
                {
                    foreach (Model.Examination.Examination oExamination in value)
                    {
                        AddExamination(oExamination);
                    }
                }
            }
        }

        /// <summary>
        /// Add a new Model.Examination.Examination in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddExamination(Model.Examination.Examination newExamination)
        {
            if (newExamination == null)
            {
                return;
            }

            if (examination == null)
            {
                examination = new System.Collections.Generic.List<Model.Examination.Examination>();
            }

            if (!examination.Contains(newExamination))
            {
                examination.Add(newExamination);
            }
        }

        /// <summary>
        /// Remove an existing Model.Examination.Examination from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveExamination(Model.Examination.Examination oldExamination)
        {
            if (oldExamination == null)
            {
                return;
            }

            if (examination != null)
            {
                if (examination.Contains(oldExamination))
                {
                    examination.Remove(oldExamination);
                }
            }
        }

        /// <summary>
        /// Remove all instances of Model.Examination.Examination from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllExamination()
        {
            if (examination != null)
            {
                examination.Clear();
            }
        }

        public uint GetId()
        {
            return id;
        }

        public void SetId(uint id)
        {
            this.id = id;
        }

        public Model.Roles.Patient patient;

        private string getExaminationSpaceSeparateIds()
        {
            StringBuilder result = new StringBuilder("");
            foreach (Model.Examination.Examination one_examination in examination)
            {
                result.Append(" " + one_examination.GetId().ToString());
            }
            if (examination.Count != 0)
            {
                return result.ToString().Substring(1);
            }

            return result.ToString();
        }
    }
}
