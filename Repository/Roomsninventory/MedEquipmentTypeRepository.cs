// File:    MedEquipmentTypeRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:08:39 PM
// Purpose: Definition of Class MedEquipmentTypeRepository

using Model.Inventory;
using System;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
   public class MedEquipmentTypeRepository : Repository.IRepositoryCRUD<MedEquipmentType, uint>
   {
      private string path;
      private static MedEquipmentTypeRepository instance = null;

        private MedEquipmentTypeRepository() {}
      
      public static MedEquipmentTypeRepository GetInstance()
      {
            if (instance == null) instance = new MedEquipmentTypeRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public MedEquipmentType Create(MedEquipmentType item)
        {
            throw new NotImplementedException();
        }

        public MedEquipmentType Read(uint id)
        {
            throw new NotImplementedException();
        }

        public MedEquipmentType Update(MedEquipmentType item)
        {
            throw new NotImplementedException();
        }

        public List<MedEquipmentType> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}