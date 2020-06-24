// File:    SideEffect.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class SideEffect

using System;

namespace Model.Medicine
{
   public class SideEffect : Repository.IIdentifiable<uint>
    {
      private string description;
      private string name;
      private uint id;
      
      public string Description
      {
         get
         {
            return description;
         }
      }
      
      public string Name
      {
         get
         {
            return name;
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