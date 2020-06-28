// File:    MedEquipmentType.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class MedEquipmentType

namespace Model.Inventory
{
    public class MedEquipmentType : Repository.IIdentifiable<uint>
    {
        private string name;
        private uint id;
        private uint number;

        public MedEquipmentType(string name, uint number)
        {
            this.name = name;
            id = 0;
            this.number = number;
        }

        public MedEquipmentType(uint id, string name, uint number)
        {
            this.name = name;
            this.id = id;
            this.number = number;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public uint Id => id;

        public uint Number
        {
            get => number;
            set => number = value;
        }

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