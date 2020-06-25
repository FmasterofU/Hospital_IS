// File:    MedEquipmentItemRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:08:39 PM
// Purpose: Definition of Class MedEquipmentItemRepository

using Model.Inventory;
using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
   public class MedEquipmentItemRepository : IMedEquipmentItemRepository

        //Id,TypeId,RoomId

    {
        private string path = @"../../Data/med_equipment_item.csv";
        private static MedEquipmentItemRepository instance = null;

        private MedEquipmentItemRepository() {}
      
      public static MedEquipmentItemRepository GetInstance()
      {
            if (instance == null) instance = new MedEquipmentItemRepository();
            return instance;
      }

        public MedEquipmentItem Create(MedEquipmentItem item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public List<MedEquipmentItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<MedEquipmentItem> GetAllByRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public List<MedEquipmentItem> GetByMedEquipmentType(MedEquipmentType medEquipmentType)
        {
            throw new NotImplementedException();
        }

        public MedEquipmentItem Read(uint id)
        {
            throw new NotImplementedException();
        }

        public MedEquipmentItem Update(MedEquipmentItem item)
        {
            throw new NotImplementedException();
        }
    }
}