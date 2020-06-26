// File:    AppFeedback.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class AppFeedback

using Model.Roles;
using System;

namespace Model.Blognfeedback
{
   public class AppFeedback : Repository.IIdentifiable<uint>
    {
      private string subject;
      private string note;
      private uint id;

        public AppFeedback(string subject, string note, Person person)
        {
            this.subject = subject;
            this.note = note;
            this.id = 0;
            this.person = person;
        }

        public string Subject
      {
         get
         {
            return subject;
         }
         set
         {
            this.subject = value;
         }
      }
      
      public string Note
      {
         get
         {
            return note;
         }
         set
         {
            this.note = value;
         }
      }
      
      public Model.Roles.Person person;
      
      /// <summary>
      /// Property for Model.Roles.Person
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Model.Roles.Person Person
      {
         get
         {
            return person;
         }
         set
         {
            this.person = value;
         }
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