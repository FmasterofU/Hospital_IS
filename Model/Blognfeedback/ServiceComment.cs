// File:    ServiceComment.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class ServiceComment

using System;

namespace Model.Blognfeedback
{
   public class ServiceComment : Repository.IIdentifiable<uint>
    {
      private string note;
      private uint id;
      private uint appointmentId;
      
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
      
      public uint AppointmentId
      {
         get
         {
            return appointmentId;
         }
         set
         {
            this.appointmentId = value;
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