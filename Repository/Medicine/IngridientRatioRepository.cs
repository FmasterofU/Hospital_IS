// File:    IngridientRatioRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class IngridientRatioRepository

using Model.Medicine;
using System;

namespace Repository.Medicine
{
   public class IngridientRatioRepository : Repository.IRepositoryCRUD<IngridientRatio, uint>
   {
      private string path;
      private IngridientRatioRepository instance;
      
      public static IngridientRatioRepository GetInstance()
      {
         throw new NotImplementedException();
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public IngridientRatio Create(IngridientRatio item)
        {
            throw new NotImplementedException();
        }

        public IngridientRatio Read(uint id)
        {
            throw new NotImplementedException();
        }

        public IngridientRatio Update(IngridientRatio item)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<IngridientRatio> GetAll()
        {
            throw new NotImplementedException();
        }

        public IngridientRatioRepository ingridientRatioRepositoryB;
   
   }
}