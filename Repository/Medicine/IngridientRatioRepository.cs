// File:    IngridientRatioRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class IngridientRatioRepository

using Model.Medicine;
using System;

namespace Repository.Medicine
{
   public class IngridientRatioRepository : Repository.IRepositoryCRUD<IngridientRatio, uint>

        //Id,IngridientId,DrugId,Ratio

    {
        private string path = @"../../Data/ingridient_ratio.csv";
        private static IngridientRatioRepository instance = null;

        private IngridientRatioRepository() {}
      
      public static IngridientRatioRepository GetInstance()
      {
            if (instance == null) instance = new IngridientRatioRepository();
            return instance;
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
   }
}