// File:    RoomAndInventoryController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:07 PM
// Purpose: Definition of Class RoomAndInventoryController

using Model.Inventory;
using Model.Rooms;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class RoomAndInventoryController : IRoomAndInventoryController
   {
      public Service.IRoomAndInventoryService iRoomAndInventoryService = new RoomAndInventoryService();

        public Room AddEquipmentToRoom(Room room, MedEquipmentType eqType, uint number)
        {
            return iRoomAndInventoryService.AddEquipmentToRoom(room, eqType, number);
        }

        public ItemCount AddItemCount(ItemCount item)
        {
            return iRoomAndInventoryService.AddItemCount(item);
        }

        public MedEquipmentItem AddMedEquipmentItem(MedEquipmentType medEquipmentType, Room room)
        {
            return iRoomAndInventoryService.AddMedEquipmentItem(medEquipmentType, room);
        }

        public MedEquipmentType AddMedEquipmentType(MedEquipmentType medEquipmentType)
        {
            return iRoomAndInventoryService.AddMedEquipmentType(medEquipmentType);
        }

        public Room AddRoom(Room room)
        {
            return iRoomAndInventoryService.AddRoom(room);
        }

        public StationaryRoomPatientsState AddStationaryRoomPatientsState(StationaryRoomPatientsState stat)
        {
            return iRoomAndInventoryService.AddStationaryRoomPatientsState(stat);
        }

        public bool DeleteItemCount(ItemCount item)
        {
            return iRoomAndInventoryService.DeleteItemCount(item);
        }

        public bool DeleteMedEquipmentitem(MedEquipmentItem medEquipmentItem)
        {
            return iRoomAndInventoryService.DeleteMedEquipmentitem(medEquipmentItem);
        }

        public bool DeleteRoom(Room room)
        {
            return iRoomAndInventoryService.DeleteRoom(room);
        }

        public bool EditItemCount(ItemCount item)
        {
            return iRoomAndInventoryService.EditItemCount(item);
        }

        public bool EditMedEquipmentType(MedEquipmentType medEqType)
        {
            return iRoomAndInventoryService.EditMedEquipmentType(medEqType);
        }

        public bool EditRoom(Room room)
        {
            return iRoomAndInventoryService.EditRoom(room);
        }

        public bool EditStationaryRoomPatientsState(StationaryRoomPatientsState stat)
        {
            return iRoomAndInventoryService.EditStationaryRoomPatientsState(stat);
        }

        public List<MedEquipmentType> GetAllMedEquipmentType()
        {
            return iRoomAndInventoryService.GetAllMedEquipmentType();
        }

        public List<Room> GetAllRooms()
        {
            return iRoomAndInventoryService.GetAllRooms();
        }

        public List<StationaryRoomPatientsState> GetAllStationaryRoomPatientsState(StationaryRoom stationaryRoom)
        {
            return iRoomAndInventoryService.GetAllStationaryRoomPatientsState(stationaryRoom);
        }

        public bool UpdateMedEquipmentType(MedEquipmentType medEqType)
        {
            return iRoomAndInventoryService.EditMedEquipmentType(medEqType);
        }
    }
}