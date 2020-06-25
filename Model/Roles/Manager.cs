// File:    Manager.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Manager

using System;

namespace Model.Roles
{
   public class Manager : Staff
   {
        protected Manager(string name, string surname, string phone, string email, Sex sex, string jmbg, string username, string password, UserType userType, object contract,
        bool active) : base(name, surname, phone, email, sex, jmbg, username, password, userType, contract, active) {}
    }
}