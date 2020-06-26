// File:    DrugRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class DrugRepository

using Class_Diagram.Repository;
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
            string[] data = new string[7];
            data[0] = item.GetId().ToString();
            data[1] = item.Name;
            data[2] = item.InUse.ToString();
            data[3] = "";
            foreach(DrugBatch batch in item.DrugBatch)
            {
                data[3] += batch.GetId().ToString() + " ";
            }
            data[3] = data[3].Trim();
            data[4] = "";
            foreach(IngridientRatio ratio in item.IngridientRatio)
            {
                data[4] += ratio.GetId().ToString() + " ";
            }
            data[4] = data[4].Trim();
            data[5] = "";
            foreach(SideEffectFrequency frequency in item.SideEffectFrequency)
            {
                data[5] += frequency.GetId().ToString() + " ";
            }
            data[5] = data[5].Trim();
            data[6] = item.drugStateChange.GetId().ToString();
            bool isUpdated = Persistence.EditEntry(path, data);
            if (isUpdated) return item;
            else return null;
        }

        public List<Drug> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}