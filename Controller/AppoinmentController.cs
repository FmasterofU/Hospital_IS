// File:    AppoinmentController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:03 PM
// Purpose: Definition of Class AppoinmentController

using Model.Appointments;
using Model.Roles;
using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class AppoinmentController : IAppoinmentController
   {
      public Service.IAppoinmentService iAppoinmentService;

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
    }
}