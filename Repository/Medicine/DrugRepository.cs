// File:    DrugRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class DrugRepository

using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
   public class DrugRepository : Repository.IRepositoryCRUD<Drug, uint>

        //Id,Name,InUse,DrugBatchIds,IngridientRatioIds,SideEffectFrequencyIds,DrugStateChangeId

    {
        private string path = @"../../Data/drug.csv";
        private static DrugRepository instance = null;

        private DrugRepository() {}
      
      public static DrugRepository GetInstance()
      {
            if (instance == null) instance = new DrugRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public Drug Create(Drug item)
        {
            throw new NotImplementedException();
        }

        public Drug Read(uint id)
        {
            throw new NotImplementedException();
        }

        public Drug Update(Drug item)
        {
            throw new NotImplementedException();
        }

        public List<Drug> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}