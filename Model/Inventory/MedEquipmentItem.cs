// File:    MedEquipmentItem.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class MedEquipmentItem

using System;

namespace Model.Inventory
{
   public class MedEquipmentItem : Repository.IIdentifiable<uint>
   {
      private uint id;
      private uint typeId;
      private uint roomId;

        //TODO: maybe refactor constructor (type and type id)
        public MedEquipmentItem(uint typeId, uint roomId, MedEquipmentType medEquipmentType)
        {
            this.id = 0;
            this.typeId = typeId;
            this.roomId = roomId;
            this.medEquipmentType = medEquipmentType;
        }

        public uint TypeId
      {
         get
         {
            return typeId;
         }
         set
         {
            this.typeId = value;
         }
      }
      
      public uint RoomId
      {
         get
         {
            return roomId;
         }
         set
         {
            this.roomId = value;
         }
      }
      
      public MedEquipmentType medEquipmentType;

        public uint GetId()
        {
            return id;
        }

        public void SetId(uint id)
        {
            this.id = id;
        }
    }
}