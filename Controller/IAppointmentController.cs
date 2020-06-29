// File:    IAppoinmentController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:30:59 PM
// Purpose: Definition of Interface IAppoinmentController

using Class_Diagram.Model.Appointments;
using Model.Appointments;
using Model.Roles;
using System;
using System.Collections.Generic;

namespace Controller
{
   public interface IAppointmentController
   {
      List<Appointment> GetAppointmentsInTimeFrame(DateTime startTime, DateTime endTime, Model.Roles.Doctor doctor, Model.Rooms.Room room);
      
      bool AddAppointment(ref Model.Appointments.Appointment appoinment, Model.Rooms.RoomType roomType, Model.Roles.Doctor doctor);
      
      bool EditAppoinment(Model.Appointments.Appointment appoinment);
      
      bool DeleteAppoinment(Model.Appointments.Appointment appoinment);

        void SetStrategy(string strategy);

        List<Term> RecommendAppointments(DateTime startDateTime, DateTime endDateTime, Doctor doctor);

        List<Appointment> GetExistingAppointmentsInSpan(DateTime startTime, DateTime endTime, Doctor doctor);
   }
}