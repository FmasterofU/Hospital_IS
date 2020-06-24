// File:    DrugStateChangeRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class DrugStateChangeRepository

using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
   public class DrugStateChangeRepository : IDrugStateChangeRepository
   {
      private string path;
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
            throw new NotImplementedException();
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