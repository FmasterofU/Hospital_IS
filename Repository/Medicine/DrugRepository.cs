// File:    DrugRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class DrugRepository

using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
   public class DrugRepository : Repository.IRepositoryCRUD<Drug, uint>
   {
      private string path;
      private DrugRepository instance;
      
      public static DrugRepository GetInstance()
      {
         throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<Drug> GetAll()
        {
            throw new NotImplementedException();
        }

        public DrugRepository drugRepositoryB;
   
   }
}