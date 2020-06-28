// File:    IRoomRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:30:38 PM
// Purpose: Definition of Interface IRoomRepository

using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
   public interface IRoomRepository : Repository.IRepositoryCRUD<Room, uint>
   {
      List<Room> GetAllByType(Model.Rooms.RoomType type);
   
   }
}