// File:    StationaryRoomPatientsState.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class StationaryRoomPatientsState

using System;

namespace Model.Rooms
{
   public class StationaryRoomPatientsState : Repository.IIdentifiable<uint>
   {
      private DateTime timestamp;
      private uint patientsNumber;
      private uint roomId;
      private uint id;
      
      public DateTime Timestamp
      {
         get
         {
            return timestamp;
         }
         set
         {
            this.timestamp = value;
         }
      }
      
      public uint PatientsNumber
      {
         get
         {
            return patientsNumber;
         }
         set
         {
            this.patientsNumber = value;
         }
      }
      
      public uint RoomId
      {
         get
         {
            return roomId;
         }
         set
         {
            this.roomId = value;
         }
      }

        public uint GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(uint id)
        {
            throw new NotImplementedException();
        }
    }
}