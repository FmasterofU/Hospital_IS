// File:    IMedEquipmentItemRepository.cs
// Author:  fmaster
// Created: Sunday, May 31, 2020 10:42:46 PM
// Purpose: Definition of Interface IMedEquipmentItemRepository

using Model.Inventory;
using System;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
   public interface IMedEquipmentItemRepository : Repository.IRepositoryCRUD<MedEquipmentItem, uint>
   {
      List<MedEquipmentItem> GetAllByRoom(Model.Rooms.Room room);
      
      List<MedEquipmentItem> GetByMedEquipmentType(Model.Inventory.MedEquipmentType medEquipmentType);
   
   }
}