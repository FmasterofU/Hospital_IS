// File:    AppointmentService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Class AppointmentService

using Model.Appointments;
using Model.Roles;
using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Service
{
   public class AppointmentService : IAppoinmentService
   {
      public IAppointmentRecommendationStrategy iAppointmentRecommendationStrategy;

        public bool AddAppointment(ref Appointment appoinment, RoomType roomType, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAppoinment(Appointment appoinment)
        {
            throw new NotImplementedException();
        }

        public bool EditAppoinment(Appointment appoinment)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsInTimeFrame(DateTime startTime, DateTime endTime, Doctor doctor, Room room)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> RecommendAppointments(DateTime startDateTime, DateTime endDateTime, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void SetStrategy(IAppointmentRecommendationStrategy strategy)
        {
            throw new NotImplementedException();
        }
    }
}