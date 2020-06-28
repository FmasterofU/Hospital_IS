// File:    ItemCountRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:08:39 PM
// Purpose: Definition of Class ItemCountRepository

using Class_Diagram.Repository;
using Model.Inventory;
using Model.Rooms;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
    public class ItemCountRepository : Repository.IRepositoryCRUD<ItemCount, uint>

    //Id,TypeId,ItemIds,Number

    {
        private string path = @"../../Data/item_count.csv";
        private static ItemCountRepository instance = null;

        private ItemCountRepository() { }

        public static ItemCountRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new ItemCountRepository();
            }

            return instance;
        }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public ItemCount Create(ItemCount item)
        {
            string[] data = new string[4];
            item.SetId(Persistence.GetNewId(path));
            data[0] = item.GetId().ToString();
            data[1] = item.ItemId.ToString();
            data[2] = "";
            foreach (MedEquipmentItem mei in item.medEquipmentItem)
            {
                data[2] += mei.GetId().ToString() + " ";
            }

            data[2] = data[2].Trim();
            data[3] = item.Number.ToString();
            if (Persistence.WriteEntry(path, data))
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public ItemCount Read(uint id)
        {
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            string[] ids = temp[0][2].Split(' ');
            List<MedEquipmentItem> mei = new List<MedEquipmentItem>();
            foreach (string s in ids)
            {
                mei.Add(MedEquipmentItemRepository.GetInstance().Read(uint.Parse(s)));
            }

            return new ItemCount(uint.Parse(temp[0][0]), uint.Parse(temp[0][3]), uint.Parse(temp[0][1]), mei.ToArray());
        }

        public ItemCount Update(ItemCount item)
        {
            string[] data = new string[4];
            data[0] = item.GetId().ToString();
            data[1] = item.ItemId.ToString();
            data[2] = "";
            foreach (MedEquipmentItem mei in item.medEquipmentItem)
            {
                data[2] += mei.GetId().ToString() + " ";
            }

            data[2] = data[2].Trim();
            data[3] = item.Number.ToString();
            if (Persistence.EditEntry(path, data))
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public List<ItemCount> GetAll()
        {
            List<string> ids = Persistence.ReadAllPrimaryIds(path);
            List<ItemCount> ic = new List<ItemCount>();
            foreach (string s in ids)
            {
                ic.Add(Read(uint.Parse(s)));
            }

            return ic;
        }
    }
}