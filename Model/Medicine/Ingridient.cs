// File:    Ingridient.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Ingridient

namespace Model.Medicine
{
    public class Ingridient : Repository.IIdentifiable<uint>
    {
        private string name;
        private bool isAlergen = false;
        private uint id;

        public Ingridient(string name, bool isAlergen)
        {
            this.name = name;
            this.isAlergen = isAlergen;
            id = 0;
        }

        public Ingridient(uint id, string name, bool isAlergen)
        {
            this.name = name;
            this.isAlergen = isAlergen;
            this.id = id;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public bool IsAlergen
        {
            get => isAlergen;
            set => isAlergen = value;
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