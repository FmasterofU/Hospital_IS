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

        //Id,TypeId,ItemIds,Number

    {
        private string path = @"../../Data/item_count.csv";
        private static ItemCountRepository instance = null;

        private ItemCountRepository() {}
      
      public static ItemCountRepository GetInstance()
      {
            if (instance == null) instance = new ItemCountRepository();
            return instance;
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
   }
}