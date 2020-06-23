// File:    IngridientRatio.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class IngridientRatio

using System;

namespace Model.Medicine
{
   public class IngridientRatio : Repository.IIdentifiable<uint>
    {
      private decimal ratio;
      private uint drugId;
      private uint id;
      
      public decimal Ratio
      {
         get
         {
            return ratio;
         }
         set
         {
            this.ratio = value;
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
      
      public Ingridient ingridient;

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