// File:    SideEffect.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class SideEffect

namespace Model.Medicine
{
    public class SideEffect : Repository.IIdentifiable<uint>
    {
        private string description;
        private string name;
        private uint id;

        public SideEffect(string description, string name)
        {
            this.description = description;
            this.name = name;
            id = 0;
        }

        public SideEffect(uint id, string description, string name)
        {
            this.description = description;
            this.name = name;
            this.id = id;
        }

        public string Description => description;

        public string Name => name;

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