// File:    IngridientRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class IngridientRepository

using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
   public class IngridientRepository : Repository.IRepositoryCRUD<Ingridient, uint>
   {
      private string path;
      private IngridientRepository instance;
      
      public static IngridientRepository GetInstance()
      {
         throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Ingridient Update(Ingridient item)
        {
            throw new NotImplementedException();
        }

        public List<Ingridient> GetAll()
        {
            throw new NotImplementedException();
        }

        public IngridientRepository ingridientRepositoryB;
   
   }
}