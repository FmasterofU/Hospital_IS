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
   {
      private string path;
      private SideEffectFrequencyRepository instance;
      
      public static SideEffectFrequencyRepository GetInstance()
      {
         throw new NotImplementedException();
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

        public SideEffectFrequencyRepository sideEffectFrequencyRepositoryB;
   
   }
}