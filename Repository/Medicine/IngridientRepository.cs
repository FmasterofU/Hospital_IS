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
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public Ingridient Create(Ingridient item)
        {
            string[] data = new string[3];
            item.SetId(Persistence.GetNewId(path));
            data[0] = item.GetId().ToString();
            data[1] = item.Name;
            data[2] = item.IsAlergen.ToString();
            if (Persistence.WriteEntry(path, data))
                return item;
            else return null;
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