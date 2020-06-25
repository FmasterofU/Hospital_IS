// File:    Examination.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Examination

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Model.Examination
{
   public class Examination : Repository.IIdentifiable<uint>
    {
      private DateTime time;
      private string diagnosis;
      private Doctor doctor;
      private uint id;

        public Examination(DateTime time, string diagnosis, Doctor doctor, List<Prescription> prescription, List<Referral> referral)
        {
            this.time = time;
            this.diagnosis = diagnosis;
            this.doctor = doctor;
            this.id = 0;
            this.prescription = prescription;
            this.referral = referral;
        }

        public DateTime Time
      {
         get
         {
            return time;
         }
      }
      
      public Doctor Doctor
      {
         get
         {
            return doctor;
         }
      }
      
      public string Diagnosis
      {
         get
         {
            return diagnosis;
         }
         set
         {
            this.diagnosis = value;
         }
      }
      
      public System.Collections.Generic.List<Prescription> prescription;
      
      /// <summary>
      /// Property for collection of Prescription
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Prescription> Prescription
      {
         get
         {
            if (prescription == null)
               prescription = new System.Collections.Generic.List<Prescription>();
            return prescription;
         }
         set
         {
            RemoveAllPrescription();
            if (value != null)
            {
               foreach (Prescription oPrescription in value)
                  AddPrescription(oPrescription);
            }
         }
      }
      
      /// <summary>
      /// Add a new Prescription in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddPrescription(Prescription newPrescription)
      {
         if (newPrescription == null)
            return;
         if (this.prescription == null)
            this.prescription = new System.Collections.Generic.List<Prescription>();
         if (!this.prescription.Contains(newPrescription))
            this.prescription.Add(newPrescription);
      }
      
      /// <summary>
      /// Remove an existing Prescription from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemovePrescription(Prescription oldPrescription)
      {
         if (oldPrescription == null)
            return;
         if (this.prescription != null)
            if (this.prescription.Contains(oldPrescription))
               this.prescription.Remove(oldPrescription);
      }
      
      /// <summary>
      /// Remove all instances of Prescription from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllPrescription()
      {
         if (prescription != null)
            prescription.Clear();
      }
      public System.Collections.Generic.List<Referral> referral;
      
      /// <summary>
      /// Property for collection of Referral
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Referral> Referral
      {
         get
         {
            if (referral == null)
               referral = new System.Collections.Generic.List<Referral>();
            return referral;
         }
         set
         {
            RemoveAllReferral();
            if (value != null)
            {
               foreach (Referral oReferral in value)
                  AddReferral(oReferral);
            }
         }
      }
      
      /// <summary>
      /// Add a new Referral in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddReferral(Referral newReferral)
      {
         if (newReferral == null)
            return;
         if (this.referral == null)
            this.referral = new System.Collections.Generic.List<Referral>();
         if (!this.referral.Contains(newReferral))
            this.referral.Add(newReferral);
      }
      
      /// <summary>
      /// Remove an existing Referral from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveReferral(Referral oldReferral)
      {
         if (oldReferral == null)
            return;
         if (this.referral != null)
            if (this.referral.Contains(oldReferral))
               this.referral.Remove(oldReferral);
      }
      
      /// <summary>
      /// Remove all instances of Referral from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllReferral()
      {
         if (referral != null)
            referral.Clear();
      }

        public uint GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(uint id)
        {
            throw new NotImplementedException();
        }
    }
}