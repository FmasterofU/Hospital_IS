// File:    AppointmentRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:34:03 PM
// Purpose: Definition of Class AppointmentRepository

using Model.Appointments;
using System;
using System.Collections.Generic;

namespace Repository.Schedule
{
   public class AppointmentRepository : IAppointmentRepository

        //Id,startTime,endTime,medicalRecordId,DoctorId,RoomId,ServiceCommentId

    {
        private string path = @"../../Data/appointment.csv";
        private static AppointmentRepository instance = null;

        private AppointmentRepository() {}
      
      public static AppointmentRepository GetInstance()
      {
            if (instance == null) instance = new AppointmentRepository();
            return instance;
      }

        public List<Appointment> GetSpan()
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public Appointment Create(Appointment item)
        {
            throw new NotImplementedException();
        }

        public Appointment Read(uint id)
        {
            throw new NotImplementedException();
        }

        public Appointment Update(Appointment item)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}