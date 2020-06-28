// File:    IRoomAndInventoryService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Interface IRoomAndInventoryService

using Model.Inventory;
using Model.Medicine;
using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Service
{
   public interface IRoomAndInventoryService
   {
      Model.Rooms.Room AddEquipmentToRoom(Model.Rooms.Room room, Model.Inventory.MedEquipmentType eqType, uint number);
      
      List<StationaryRoomPatientsState> GetAllStationaryRoomPatientsState(Model.Rooms.StationaryRoom stationaryRoom);
      
      List<Room> GetAllRooms();
      
      bool DeleteRoom(Model.Rooms.Room room);
      
      bool EditRoom(Model.Rooms.Room room);
      
      Room AddRoom(Model.Rooms.Room room);
      
      MedEquipmentType AddMedEquipmentType(Model.Inventory.MedEquipmentType medEquipmentType);

        List<MedEquipmentType> GetAllMedEquipmentType();
      
      MedEquipmentItem AddMedEquipmentItem(Model.Inventory.MedEquipmentType medEquipmentType, Model.Rooms.Room room);

        bool DeleteMedEquipmentitem(MedEquipmentItem medEquipmentItem);
      
      bool EditMedEquipmentType(Model.Inventory.MedEquipmentType medEqType);

        ItemCount AddItemCount(ItemCount item);

        bool EditItemCount(ItemCount item);

        bool DeleteItemCount(ItemCount item);

    }
}