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

        protected Staff(string name, string surname, string phone, string email, Sex sex, string jmbg, string username, string password, UserType userType, object contract, 
                bool active) : base(name, surname, phone, email, sex, jmbg, username, password, userType)
        {
            this.contract = contract;
            this.active = active;
        }

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

        public string getStaffCommaSeparatedData()
        {
            return getPersonCommaSeparatedData()+","+""+","+Active.ToString(); //treba dodati contract ali trenutno to nije prioritet
        }

    }
}