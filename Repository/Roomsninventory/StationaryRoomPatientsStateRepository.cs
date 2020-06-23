// File:    StationaryRoomPatientsStateRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:08:39 PM
// Purpose: Definition of Class StationaryRoomPatientsStateRepository

using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
   public class StationaryRoomPatientsStateRepository : IStationaryRoomPatientsStateRepository
   {
      private string path;
      private StationaryRoomPatientsStateRepository instance;
      
      public static StationaryRoomPatientsStateRepository GetInstance()
      {
         throw new NotImplementedException();
      }

        public List<StationaryRoomPatientsState> GetAllByRoom(StationaryRoom room)
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public StationaryRoomPatientsState Create(StationaryRoomPatientsState item)
        {
            throw new NotImplementedException();
        }

        public StationaryRoomPatientsState Read(uint id)
        {
            throw new NotImplementedException();
        }

        public StationaryRoomPatientsState Update(StationaryRoomPatientsState item)
        {
            throw new NotImplementedException();
        }

        public List<StationaryRoomPatientsState> GetAll()
        {
            throw new NotImplementedException();
        }

        public StationaryRoomPatientsStateRepository stationaryRoomPatientsStateRepositoryB;
   
   }
}