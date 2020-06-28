// File:    Prescription.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Prescription

using Model.Medicine;

namespace Model.Examination
{
    public class Prescription : Repository.IIdentifiable<uint>
    {
        private uint number;
        private string usage;
        private uint id;

        public Prescription(uint number, string usage, Drug drug)
        {
            this.number = number;
            this.usage = usage;
            id = 0;
            this.drug = drug;
        }

        public uint Number
        {
            get => number;
            set => number = value;
        }

        public string Usage
        {
            get => usage;
            set => usage = value;
        }

        public Model.Medicine.Drug drug;

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