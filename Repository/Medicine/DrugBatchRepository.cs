// File:    DrugBatchRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class DrugBatchRepository

using Class_Diagram.Repository;
using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
   public class DrugBatchRepository : Repository.IRepositoryCRUD<DrugBatch, uint>

        //Id,DrugId,Number,ExpDate,LotNumber

    {
        private string path = @"../../Data/drug_batch.csv";
        private static DrugBatchRepository instance = null;

        private DrugBatchRepository() {}
      
      public static DrugBatchRepository GetInstance()
      {
            if (instance == null) instance = new DrugBatchRepository();
            return instance;
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
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            return new DrugBatch(uint.Parse(temp[0][0]), temp[0][4], int.Parse(temp[0][2]), new DateTime(long.Parse(temp[0][3])), uint.Parse(temp[0][1]));
        }

        public DrugBatch Update(DrugBatch item)
        {
            throw new NotImplementedException();
        }

        public List<DrugBatch> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}