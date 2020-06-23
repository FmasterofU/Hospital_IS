// File:    IAppoinmentService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Interface IAppoinmentService

using Model.Appointments;
using System;
using System.Collections.Generic;

namespace Service
{
   public interface IAppoinmentService
   {
      List<Appointment> GetAppointmentsInTimeFrame(DateTime startTime, DateTime endTime, Model.Roles.Doctor doctor, Model.Rooms.Room room);
      
      bool AddAppointment(ref Model.Appointments.Appointment appoinment, Model.Rooms.RoomType roomType, Model.Roles.Doctor doctor);
      
      bool EditAppoinment(Model.Appointments.Appointment appoinment);
      
      bool DeleteAppoinment(Model.Appointments.Appointment appoinment);
      
      void SetStrategy(IAppointmentRecommendationStrategy strategy);
      
      List<Appointment> RecommendAppointments(DateTime startDateTime, DateTime endDateTime, Model.Roles.Doctor doctor);
   
   }
}