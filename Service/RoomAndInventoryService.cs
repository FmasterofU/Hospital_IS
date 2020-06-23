// File:    RoomAndInventoryService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Class RoomAndInventoryService

using Model.Inventory;
using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Service
{
    public class RoomAndInventoryService : IRoomAndInventoryService
    {
        public Room AddEquipmentToRoom(Room room, MedEquipmentType eqType, uint number)
        {
            throw new NotImplementedException();
        }

        public bool AddMedEquipmentItem(MedEquipmentType medEquipmentType, Room room)
        {
            throw new NotImplementedException();
        }

        public bool AddMedEquipmentType(MedEquipmentType medEquipmentType)
        {
            throw new NotImplementedException();
        }

        public bool AddRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMedEquipmentitem(MedEquipmentItem medEquipmentItem)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public bool EditRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public List<MedEquipmentType> GetAllMedEquipmentType()
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public List<StationaryRoomPatientsState> GetAllStationaryRoomPatientsState(StationaryRoom stationaryRoom)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMedEquipmentType(MedEquipmentType medEqType)
        {
            throw new NotImplementedException();
        }
    }
}