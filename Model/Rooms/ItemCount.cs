// File:    ItemCount.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class ItemCount

using Model.Inventory;

namespace Model.Rooms
{
    public class ItemCount : Repository.IIdentifiable<uint>
    {
        private uint number;
        private uint itemId;
        private uint id;

        public ItemCount(uint number, uint itemId, MedEquipmentItem[] medEquipmentItem)
        {
            this.number = number;
            this.itemId = itemId;
            id = 0;
            this.medEquipmentItem = medEquipmentItem;
        }

        public ItemCount(uint id, uint number, uint itemId, MedEquipmentItem[] medEquipmentItem)
        {
            this.number = number;
            this.itemId = itemId;
            this.id = id;
            this.medEquipmentItem = medEquipmentItem;
        }

        public uint Number
        {
            get => number;
            set => number = value;
        }

        public uint ItemId
        {
            get => itemId;
            set => itemId = value;
        }

        public Model.Inventory.MedEquipmentItem[] medEquipmentItem;

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