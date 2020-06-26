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

        private DrugStateChangeRepository() {}
      
      public static DrugStateChangeRepository GetInstance()
      {
            if (instance == null) instance = new DrugStateChangeRepository();
            return instance;
      }

        public List<DrugStateChange> GetAllByDrug()
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public DrugStateChange Create(DrugStateChange item)
        {
            string[] data = new string[5];
            data[0] = item.GetId().ToString();
            data[1] = item.DrugId.ToString();
            data[2] = item.Timestamp.ToString();
            data[3] = item.TotalNumber.ToString();
            data[4] = item.Threshold.ToString();
            bool isAdded = Persistence.WriteEntry(path, data);
            if (isAdded) return item;
            else return null;
        }

        public DrugStateChange Read(uint id)
        {
            throw new NotImplementedException();
        }

        public DrugStateChange Update(DrugStateChange item)
        {
            throw new NotImplementedException();
        }

        public List<DrugStateChange> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}