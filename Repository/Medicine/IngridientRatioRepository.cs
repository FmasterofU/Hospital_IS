// File:    IngridientRatioRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class IngridientRatioRepository

using Class_Diagram.Repository;
using Model.Medicine;
using System;
using System.Collections.Generic;

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
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            return new IngridientRatio(uint.Parse(temp[0][0]), decimal.Parse(temp[0][3]), uint.Parse(temp[0][2]), IngridientRepository.GetInstance().Read(uint.Parse(temp[0][1])));
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