// File:    Staff.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Staff

using System;

namespace Model.Roles
{
   public abstract class Staff : Person
   {
      private Object contract;
      private bool active;
      
      public Object Contract
      {
         get
         {
            return contract;
         }
         set
         {
            this.contract = value;
         }
      }
      
      public bool Active
      {
         get
         {
            return active;
         }
         set
         {
            this.active = value;
         }
      }
   
   }
}