// File:    SideEffectRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class SideEffectRepository

using Class_Diagram.Repository;
using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
   public class SideEffectRepository : Repository.IRepositoryCRUD<SideEffect, uint>

        //Id,Name,Description

    {
        private string path = @"../../Data/side_effect.csv";
        private static SideEffectRepository instance = null;

        private SideEffectRepository() {}
      
      public static SideEffectRepository GetInstance()
      {
            if (instance == null) instance = new SideEffectRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public SideEffect Create(SideEffect item)
        {
            throw new NotImplementedException();
        }

        public SideEffect Read(uint id)
        {
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            return new SideEffect(uint.Parse(temp[0][0]), temp[0][2], temp[0][1]);
        }

        public SideEffect Update(SideEffect item)
        {
            throw new NotImplementedException();
        }

        public List<SideEffect> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}