// File:    IAppoinmentController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:30:59 PM
// Purpose: Definition of Interface IAppoinmentController

using Model.Appointments;
using System;
using System.Collections.Generic;

namespace Controller
{
   public interface IAppoinmentController
   {
      List<Appointment> GetAppointmentsInTimeFrame(DateTime startTime, DateTime endTime, Model.Roles.Doctor doctor, Model.Rooms.Room room);
      
      bool AddAppointment(ref Model.Appointments.Appointment appoinment, Model.Rooms.RoomType roomType, Model.Roles.Doctor doctor);
      
      bool EditAppoinment(Model.Appointments.Appointment appoinment);
      
      bool DeleteAppoinment(Model.Appointments.Appointment appoinment);
   
   }
}