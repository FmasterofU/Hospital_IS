// File:    ItemCount.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class ItemCount

using System;

namespace Model.Rooms
{
   public class ItemCount : Repository.IIdentifiable<uint>
   {
      private uint number;
      private uint itemId;
      private uint id;
      
      public uint Number
      {
         get
         {
            return number;
         }
         set
         {
            this.number = value;
         }
      }
      
      public uint ItemId
      {
         get
         {
            return itemId;
         }
         set
         {
            this.itemId = value;
         }
      }
      
      public Model.Inventory.MedEquipmentItem[] medEquipmentItem;

        public uint GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(uint id)
        {
            throw new NotImplementedException();
        }
    }
}