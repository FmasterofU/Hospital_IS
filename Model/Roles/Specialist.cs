// File:    Specialist.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Specialist

using System;

namespace Model.Roles
{
   public class Specialist : Doctor
   {
      private string specialization;
      
      public string Specialization
      {
         get
         {
            return specialization;
         }
         set
         {
            this.specialization = value;
         }
      }
   
   }
}