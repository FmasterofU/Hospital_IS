// File:    DrugBatch.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class DrugBatch

using System;

namespace Model.Medicine
{
   public class DrugBatch : Repository.IIdentifiable<uint>
   {
      private string lotNumber;
      private int number;
      private DateTime expDate;
      private uint drugId;
      private uint id;
      
      public int Number
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
      
      public DateTime ExpDate
      {
         get
         {
            return expDate;
         }
         set
         {
            this.expDate = value;
         }
      }
      
      public string LotNumber
      {
         get
         {
            return lotNumber;
         }
         set
         {
            this.lotNumber = value;
         }
      }
      
      public uint DrugId
      {
         get
         {
            return drugId;
         }
         set
         {
            this.drugId = value;
         }
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