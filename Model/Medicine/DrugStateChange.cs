// File:    DrugStateChange.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class DrugStateChange

using System;

namespace Model.Medicine
{
   public class DrugStateChange : Repository.IIdentifiable<uint>
    {
      private DateTime timestamp;
      private int totalNumber;
      private int threshold;
      private uint drugId;
      private uint id;

        public DrugStateChange(DateTime timestamp, int totalNumber, int threshold, uint drugId, uint id)
        {
            this.timestamp = timestamp;
            this.totalNumber = totalNumber;
            this.threshold = threshold;
            this.drugId = drugId;
            this.id = id;
        }
      
      public DateTime Timestamp
      {
         get
         {
            return timestamp;
         }
         set
         {
            this.timestamp = value;
         }
      }
      
      public int TotalNumber
      {
         get
         {
            return totalNumber;
         }
         set
         {
            this.totalNumber = value;
         }
      }
      
      public int Threshold
      {
         get
         {
            return threshold;
         }
         set
         {
            this.threshold = value;
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