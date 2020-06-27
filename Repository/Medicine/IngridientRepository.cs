// File:    IngridientRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class IngridientRepository

using Class_Diagram.Repository;
using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
   public class IngridientRepository : Repository.IRepositoryCRUD<Ingridient, uint>

        //Id,Name,IsAlergen

    {
        private string path = @"../../Data/ingridient.csv";
        private static IngridientRepository instance = null;

        private IngridientRepository() {}
      
      public static IngridientRepository GetInstance()
      {
            if (instance == null) instance = new IngridientRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public Ingridient Create(Ingridient item)
        {
            throw new NotImplementedException();
        }

        public Ingridient Read(uint id)
        {
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            return new Ingridient(uint.Parse(temp[0][0]), temp[0][1], bool.Parse(temp[0][2]));
        }

        public Ingridient Update(Ingridient item)
        {
            throw new NotImplementedException();
        }

        public List<Ingridient> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}