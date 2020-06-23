// File:    MedEquipmentType.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class MedEquipmentType

using System;

namespace Model.Inventory
{
   public class MedEquipmentType : Repository.IIdentifiable<uint>
    {
      private string name;
      private uint id;
      private uint number;
      
      public string Name
      {
         get
         {
            return name;
         }
         set
         {
            this.name = value;
         }
      }
      
      public uint Id
      {
         get
         {
            return id;
         }
      }
      
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