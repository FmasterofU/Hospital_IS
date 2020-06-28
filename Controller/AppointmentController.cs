// File:    AppoinmentController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:03 PM
// Purpose: Definition of Class AppoinmentController

using Class_Diagram.Model.Appointments;
using Model.Appointments;
using Model.Roles;
using Model.Rooms;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class AppointmentController : IAppointmentController
   {
      public Service.IAppointmentService iAppoinmentService = new AppointmentService();

        public bool AddAppointment(ref Appointment appoinment, RoomType roomType, Doctor doctor)
        {
            return iAppoinmentService.AddAppointment(ref appoinment, roomType, doctor);
        }

        public bool DeleteAppoinment(Appointment appoinment)
        {
            return iAppoinmentService.DeleteAppoinment(appoinment);
        }

        public bool EditAppoinment(Appointment appoinment)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsInTimeFrame(DateTime startTime, DateTime endTime, Doctor doctor, Room room)
        {
            return iAppoinmentService.GetAppointmentsInTimeFrame(startTime, endTime, doctor, room);
        }

        public List<Term> RecommendAppointments(DateTime startDateTime, DateTime endDateTime, Doctor doctor)
        {
            return iAppoinmentService.RecommendAppointments(startDateTime, endDateTime, doctor);
        }

        public void SetStrategy(string strategy)
        {
            if(strategy.ToLower().Equals("doctor"))
            {
                iAppoinmentService.SetStrategy(new DoctorAppointmentRecommendationStrategy());
            }
            else if(strategy.ToLower().Equals("time"))
            {
                iAppoinmentService.SetStrategy(new TimePeriodAppointmentRecommendationStrategy());
            }
        }
    }
}