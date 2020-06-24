// File:    Person.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Person

using System;

namespace Model.Roles
{
   public abstract class Person : Repository.IIdentifiable<uint>
   {
      private uint id;
      private string name;
      private string surname;
      private string phone;
      private string email;
      private Sex sex;
      private string jmbg;
      private string username;
      private string password;
      private UserType userType = UserType.None;
      
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
      
      public string Surname
      {
         get
         {
            return surname;
         }
         set
         {
            this.surname = value;
         }
      }
      
      public string Phone
      {
         get
         {
            return phone;
         }
         set
         {
            this.phone = value;
         }
      }
      
      public string Email
      {
         get
         {
            return email;
         }
         set
         {
            this.email = value;
         }
      }
      
      public Sex Sex
      {
         get
         {
            return sex;
         }
         set
         {
            this.sex = value;
         }
      }
      
      public string Jmbg
      {
         get
         {
            return jmbg;
         }
      }
      
      public UserType UserType
      {
         get
         {
            return userType;
         }
         set
         {
            this.userType = value;
         }
      }
      
      public string Username
      {
         get
         {
            return username;
         }
         set
         {
            this.username = value;
         }
      }
      
      public string Password
      {
         get
         {
            return password;
         }
         set
         {
            this.password = value;
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