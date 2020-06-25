// File:    SideEffectFrequencyRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class SideEffectFrequencyRepository

using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
   public class SideEffectFrequencyRepository : Repository.IRepositoryCRUD<SideEffectFrequency, uint>

        //Id,DrugId,Basis,Freq,SideEffectId

    {
        private string path = @"../../Data/side_effect_frequency.csv";
        private static SideEffectFrequencyRepository instance = null;

        private SideEffectFrequencyRepository() {}
      
      public static SideEffectFrequencyRepository GetInstance()
      {
            if (instance == null) instance = new SideEffectFrequencyRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public SideEffectFrequency Create(SideEffectFrequency item)
        {
            throw new NotImplementedException();
        }

        public SideEffectFrequency Read(uint id)
        {
            throw new NotImplementedException();
        }

        public SideEffectFrequency Update(SideEffectFrequency item)
        {
            throw new NotImplementedException();
        }

        public List<SideEffectFrequency> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}