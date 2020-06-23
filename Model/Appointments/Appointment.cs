// File:    Appointment.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Appointment

using Model.Blognfeedback;
using System;

namespace Model.Appointments
{
   public class Appointment : Repository.IIdentifiable<uint>
    {
      private DateTime startTime;
      private DateTime endTime;
      private uint id;
      private uint medicalRecordId;
      
      public DateTime StartTime
      {
         get
         {
            return startTime;
         }
         set
         {
            this.startTime = value;
         }
      }
      
      public DateTime EndTime
      {
         get
         {
            return endTime;
         }
         set
         {
            this.endTime = value;
         }
      }
      
      public uint MedicalRecordId
      {
         get
         {
            return medicalRecordId;
         }
         set
         {
            this.medicalRecordId = value;
         }
      }
      
      public Model.Roles.Doctor doctor;
      public Model.Rooms.Room room;
      public ServiceComment serviceComment;

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