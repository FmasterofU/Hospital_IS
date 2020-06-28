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

        private DrugBatchRepository() { }

        public static DrugBatchRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new DrugBatchRepository();
            }

            return instance;
        }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public DrugBatch Create(DrugBatch item)
        {
            string[] data = new string[5];
            item.SetId(Persistence.GetNewId(path));
            data[0] = item.GetId().ToString();
            data[1] = item.DrugId.ToString();
            data[2] = item.Number.ToString();
            data[3] = item.ExpDate.Ticks.ToString();
            data[4] = item.LotNumber;
            if (Persistence.WriteEntry(path, data))
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public DrugBatch Read(uint id)
        {
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            return new DrugBatch(uint.Parse(temp[0][0]), temp[0][4], int.Parse(temp[0][2]), new DateTime(long.Parse(temp[0][3])), uint.Parse(temp[0][1]));
        }

        public DrugBatch Update(DrugBatch item)
        {
            string[] data = new string[5];
            data[0] = item.GetId().ToString();
            data[1] = item.DrugId.ToString();
            data[2] = item.Number.ToString();
            data[3] = item.ExpDate.Ticks.ToString();
            data[4] = item.LotNumber;
            if (Persistence.EditEntry(path, data))
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public List<DrugBatch> GetAll()
        {
            List<string> ids = Persistence.ReadAllPrimaryIds(path);
            List<DrugBatch> ret = new List<DrugBatch>();
            foreach (string s in ids)
            {
                ret.Add(Read(uint.Parse(s)));
            }

            return ret;
        }
    }
}