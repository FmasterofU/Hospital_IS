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

        public Specialist(string name, string surname, string phone, string email, Sex sex, string jmbg, string username, string password, UserType userType, object contract,
            bool active, string specialization) : base(name, surname, phone, email, sex, jmbg, username, password, userType, contract, active)
        {
            this.specialization = specialization;
        }

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

        public string getSpecialistCommaSeparatedData()
        {
            return getDoctorCommaSeparatedData() + "," + Specialization;
        }

    }
}