// File:    Prescription.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Prescription

using System;

namespace Model.Examination
{
   public class Prescription : Repository.IIdentifiable<uint>
    {
      private uint number;
      private string usage;
      private uint id;
      
      public uint Number
      {
         get
         {
            return number;
         }
         set
         {
            this.number = value;
         }
      }
      
      public string Usage
      {
         get
         {
            return usage;
         }
         set
         {
            this.usage = value;
         }
      }
      
      public Model.Medicine.Drug drug;

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