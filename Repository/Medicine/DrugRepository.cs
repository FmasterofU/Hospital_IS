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
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public Drug Create(Drug item)
        {
            string[] drugEntry = new string[7];
            item.SetId(Persistence.GetNewId(path));
            drugEntry[0] = item.GetId().ToString();
            drugEntry[1] = item.Name;
            drugEntry[2] = item.InUse.ToString();
            drugEntry[3] = "";
            foreach (DrugBatch db in item.DrugBatch)
                drugEntry[3] += db.GetId().ToString() + " ";
            if (item.drugBatch.Count != 0) drugEntry[3] = drugEntry[3].Substring(0, drugEntry[3].Length - 1);
            drugEntry[4] = "";
            foreach (IngridientRatio ir in item.IngridientRatio)
                drugEntry[4] += ir.GetId().ToString() + " ";
            if (item.IngridientRatio.Count != 0) drugEntry[4] = drugEntry[4].Substring(0, drugEntry[4].Length - 1);
            drugEntry[5] = "";
            foreach (SideEffectFrequency sef in item.SideEffectFrequency)
                drugEntry[5] += sef.GetId().ToString() + " ";
            if (item.SideEffectFrequency.Count != 0) drugEntry[5] = drugEntry[5].Substring(0, drugEntry[5].Length - 1);
            drugEntry[6] = item.drugStateChange.GetId().ToString();
            if (Persistence.WriteEntry(path, drugEntry))
                return item;
            else return null;
        }

        public Drug Read(uint id)
        {
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            string name = temp[0][1];
            bool inUse = bool.Parse(temp[0][2]);
            DrugStateChange dsc = DrugStateChangeRepository.GetInstance().Read(uint.Parse(temp[0][6]));
            string[] dbids = temp[0][3].Split(' ');
            List<DrugBatch> dbs = new List<DrugBatch>();
            foreach (string dbid in dbids)
                dbs.Add(DrugBatchRepository.GetInstance().Read(uint.Parse(dbid)));
            string[] irids = temp[0][4].Split(' ');
            List<IngridientRatio> irs = new List<IngridientRatio>();
            foreach (string irid in irids)
                irs.Add(IngridientRatioRepository.GetInstance().Read(uint.Parse(irid)));
            string[] sefids = temp[0][5].Split(' ');
            List<SideEffectFrequency> sefs = new List<SideEffectFrequency>();
            foreach (string sefid in sefids)
                sefs.Add(SideEffectFrequencyRepository.GetInstance().Read(uint.Parse(sefid)));
            return new Drug(id, name, inUse, dbs, irs, sefs, dsc);
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
            List<string> allIds = Persistence.ReadAllPrimaryIds(path);
            List<Drug> ret = new List<Drug>();
            foreach (string s in allIds)
                ret.Add(Read(uint.Parse(s)));
            return ret;
        }
   }
}