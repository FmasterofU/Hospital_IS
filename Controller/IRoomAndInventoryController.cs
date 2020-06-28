// File:    IRoomAndInventoryController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:30:59 PM
// Purpose: Definition of Interface IRoomAndInventoryController

using Model.Inventory;
using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Controller
{
   public interface IRoomAndInventoryController
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
      
      bool UpdateMedEquipmentType(Model.Inventory.MedEquipmentType medEqType);
   
   }
}