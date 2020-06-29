// File:    MedEquipmentItemRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:08:39 PM
// Purpose: Definition of Class MedEquipmentItemRepository

using Class_Diagram.Repository;
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
            string[] data = new string[3];
            item.SetId(Persistence.GetNewId(path));
            data[0] = item.GetId().ToString();
            data[1] = item.TypeId.ToString();
            data[2] = item.RoomId.ToString();
            if (Persistence.WriteEntry(path, data))
                return item;
            else return null;
        }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public List<MedEquipmentItem> GetAll()
        {
            List<string> ids = Persistence.ReadAllPrimaryIds(path);
            List<MedEquipmentItem> mei = new List<MedEquipmentItem>();
            foreach (string s in ids)
                mei.Add(Read(uint.Parse(s)));
            return mei;
        }

        public List<MedEquipmentItem> GetAllByRoom(Room room)
        {
            List<string[]> ids = Persistence.ReadEntryByKey(path, room.GetId().ToString(), 2);
            List<MedEquipmentItem> mei = new List<MedEquipmentItem>();
            foreach (string[] s in ids)
                mei.Add(Read(uint.Parse(s[0])));
            return mei;
        }

        public List<MedEquipmentItem> GetByMedEquipmentType(MedEquipmentType medEquipmentType)
        {
            List<string[]> ids = Persistence.ReadEntryByKey(path, medEquipmentType.GetId().ToString(), 1);
            List<MedEquipmentItem> mei = new List<MedEquipmentItem>();
            foreach (string[] s in ids)
                mei.Add(Read(uint.Parse(s[0])));
            return mei;
        }

        public MedEquipmentItem Read(uint id)
        {
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            return new MedEquipmentItem(uint.Parse(temp[0][0]), uint.Parse(temp[0][1]), uint.Parse(temp[0][2]), MedEquipmentTypeRepository.GetInstance().Read(uint.Parse(temp[0][1])));
        }

        public MedEquipmentItem Update(MedEquipmentItem item)
        {
            string[] data = new string[3];
            data[0] = item.GetId().ToString();
            data[1] = item.TypeId.ToString();
            data[2] = item.RoomId.ToString();
            if (Persistence.EditEntry(path, data))
                return item;
            else return null;
        }
    }
}