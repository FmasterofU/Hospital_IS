// File:    DrugBatchRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class DrugBatchRepository

using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
   public class DrugBatchRepository : Repository.IRepositoryCRUD<DrugBatch, uint>
   {
      private string path;
      private DrugBatchRepository instance;
      
      public static DrugBatchRepository GetInstance()
      {
         throw new NotImplementedException();
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public DrugBatch Create(DrugBatch item)
        {
            throw new NotImplementedException();
        }

        public DrugBatch Read(uint id)
        {
            throw new NotImplementedException();
        }

        public DrugBatch Update(DrugBatch item)
        {
            throw new NotImplementedException();
        }

        public List<DrugBatch> GetAll()
        {
            throw new NotImplementedException();
        }

        public DrugBatchRepository drugBatchRepositoryB;
   
   }
}