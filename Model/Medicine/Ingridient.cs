// File:    Ingridient.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Ingridient

using System;

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
            this.id = 0;
        }

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
      
      public bool IsAlergen
      {
         get
         {
            return isAlergen;
         }
         set
         {
            this.isAlergen = value;
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