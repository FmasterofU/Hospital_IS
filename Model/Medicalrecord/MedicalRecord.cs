// File:    MedicalRecord.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class MedicalRecord

using System;

namespace Model.Medicalrecord
{
   public class MedicalRecord : Repository.IIdentifiable<uint>
    {
      private uint id;
      
      public InsurancePolicy insurancePolicy;
      public System.Collections.Generic.List<Model.Examination.Examination> examination;
      
      /// <summary>
      /// Property for collection of Model.Examination.Examination
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Model.Examination.Examination> Examination
      {
         get
         {
            if (examination == null)
               examination = new System.Collections.Generic.List<Model.Examination.Examination>();
            return examination;
         }
         set
         {
            RemoveAllExamination();
            if (value != null)
            {
               foreach (Model.Examination.Examination oExamination in value)
                  AddExamination(oExamination);
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
            return;
         if (this.examination == null)
            this.examination = new System.Collections.Generic.List<Model.Examination.Examination>();
         if (!this.examination.Contains(newExamination))
            this.examination.Add(newExamination);
      }
      
      /// <summary>
      /// Remove an existing Model.Examination.Examination from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveExamination(Model.Examination.Examination oldExamination)
      {
         if (oldExamination == null)
            return;
         if (this.examination != null)
            if (this.examination.Contains(oldExamination))
               this.examination.Remove(oldExamination);
      }
      
      /// <summary>
      /// Remove all instances of Model.Examination.Examination from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllExamination()
      {
         if (examination != null)
            examination.Clear();
      }

        public uint GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(uint id)
        {
            throw new NotImplementedException();
        }

        public Model.Roles.Patient patient;
   
   }
}