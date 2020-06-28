// File:    DrugStateChangeRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class DrugStateChangeRepository

using Class_Diagram.Repository;
using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
    public class DrugStateChangeRepository : IDrugStateChangeRepository

    //Id,DrugId,Timestamp,TotalNumber,Threshold

    {
        private string path = @"../../Data/drug_state_change.csv";
        private static DrugStateChangeRepository instance = null;

        private DrugStateChangeRepository() { }

        public static DrugStateChangeRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new DrugStateChangeRepository();
            }

            return instance;
        }

        public List<DrugStateChange> GetAllByDrug(Drug drug)
        {
            List<string[]> data = Persistence.ReadEntryByKey(path, drug.GetId().ToString(), 1);
            List<DrugStateChange> ret = new List<DrugStateChange>();
            foreach (string[] temp in data)
            {
                ret.Add(new DrugStateChange(uint.Parse(temp[0]), new DateTime(long.Parse(temp[2])), int.Parse(temp[3]), int.Parse(temp[4]), uint.Parse(temp[1])));
            }

            return ret;
        }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public DrugStateChange Create(DrugStateChange item)
        {
            string[] data = new string[5];
            item.SetId(Persistence.GetNewId(path));
            data[0] = item.GetId().ToString();
            data[1] = item.DrugId.ToString();
            data[2] = item.Timestamp.Ticks.ToString();
            data[3] = item.TotalNumber.ToString();
            data[4] = item.Threshold.ToString();
            bool isAdded = Persistence.WriteEntry(path, data);
            if (isAdded)
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public DrugStateChange Read(uint id)
        {
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            return new DrugStateChange(uint.Parse(temp[0][0]), new DateTime(long.Parse(temp[0][2])), int.Parse(temp[0][3]), int.Parse(temp[0][4]), uint.Parse(temp[0][1]));
        }

        public DrugStateChange Update(DrugStateChange item)
        {
            string[] data = new string[5];
            data[0] = item.GetId().ToString();
            data[1] = item.DrugId.ToString();
            data[2] = item.Timestamp.Ticks.ToString();
            data[3] = item.TotalNumber.ToString();
            data[4] = item.Threshold.ToString();
            bool isAdded = Persistence.EditEntry(path, data);
            if (isAdded)
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public List<DrugStateChange> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}