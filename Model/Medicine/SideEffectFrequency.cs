// File:    SideEffectFrequency.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class SideEffectFrequency

using System;

namespace Model.Medicine
{
   public class SideEffectFrequency : Repository.IIdentifiable<uint>
    {
      private uint drugId;
      private uint id;
      private int basis;
      private int freq;

        public SideEffectFrequency(uint drugId, int basis, int freq, SideEffect sideEffect)
        {
            this.drugId = drugId;
            this.id = 0;
            this.basis = basis;
            this.freq = freq;
            this.sideEffect = sideEffect;
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
      
      public int Basis
      {
         get
         {
            return basis;
         }
         set
         {
            this.basis = value;
         }
      }
      
      public int Freq
      {
         get
         {
            return freq;
         }
         set
         {
            this.freq = value;
         }
      }
      
      public SideEffect sideEffect;

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