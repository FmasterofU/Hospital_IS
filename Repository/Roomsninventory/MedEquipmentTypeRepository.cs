// File:    MedEquipmentTypeRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:08:39 PM
// Purpose: Definition of Class MedEquipmentTypeRepository

using Class_Diagram.Repository;
using Model.Inventory;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
    public class MedEquipmentTypeRepository : Repository.IRepositoryCRUD<MedEquipmentType, uint>

    //Id,Name,Number

    {
        private string path = @"../../Data/med_equipment_type.csv";
        private static MedEquipmentTypeRepository instance = null;

        private MedEquipmentTypeRepository() { }

        public static MedEquipmentTypeRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new MedEquipmentTypeRepository();
            }

            return instance;
        }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public MedEquipmentType Create(MedEquipmentType item)
        {
            string[] data = new string[3];
            item.SetId(Persistence.GetNewId(path));
            data[0] = item.GetId().ToString();
            data[1] = item.Name;
            data[2] = item.Number.ToString();
            if (Persistence.WriteEntry(path, data))
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public MedEquipmentType Read(uint id)
        {
            List<string[]> data = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            return new MedEquipmentType(uint.Parse(data[0][0]), data[0][1], uint.Parse(data[0][2]));
        }

        public MedEquipmentType Update(MedEquipmentType item)
        {
            string[] data = new string[3];
            data[0] = item.GetId().ToString();
            data[1] = item.Name;
            data[2] = item.Number.ToString();
            if (Persistence.EditEntry(path, data))
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public List<MedEquipmentType> GetAll()
        {
            List<string> ids = Persistence.ReadAllPrimaryIds(path);
            List<MedEquipmentType> met = new List<MedEquipmentType>();
            foreach (string s in ids)
            {
                met.Add(Read(uint.Parse(s)));
            }

            return met;
        }
    }
}