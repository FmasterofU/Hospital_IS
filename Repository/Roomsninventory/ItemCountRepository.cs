// File:    ItemCountRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:08:39 PM
// Purpose: Definition of Class ItemCountRepository

using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
   public class ItemCountRepository : Repository.IRepositoryCRUD<ItemCount, uint>
   {
      private string path;
      
      public static ItemCountRepository GetInstance()
      {
         throw new NotImplementedException();
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public ItemCount Create(ItemCount item)
        {
            throw new NotImplementedException();
        }

        public ItemCount Read(uint id)
        {
            throw new NotImplementedException();
        }

        public ItemCount Update(ItemCount item)
        {
            throw new NotImplementedException();
        }

        public List<ItemCount> GetAll()
        {
            throw new NotImplementedException();
        }

        public ItemCountRepository itemCountRepositoryB;
   
   }
}