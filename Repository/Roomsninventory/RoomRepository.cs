// File:    RoomRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:30:38 PM
// Purpose: Definition of Class RoomRepository

using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
   public class RoomRepository : IRoomRepository
   {
      private string path;
      private static RoomRepository instance = null;

        private RoomRepository() {}
      
      public static RoomRepository GetInstance()
      {
            if (instance == null) instance = new RoomRepository();
            return instance;
      }

        public List<Room> GetAllByType(RoomType type)
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public Room Create(Room item)
        {
            throw new NotImplementedException();
        }

        public Room Read(uint id)
        {
            throw new NotImplementedException();
        }

        public Room Update(Room item)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}