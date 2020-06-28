// File:    IAppoinmentService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Interface IAppoinmentService

using Class_Diagram.Model.Appointments;
using Model.Appointments;
using Model.Roles;
using System;
using System.Collections.Generic;

namespace Service
{
    public interface IAppointmentService
    {
        List<Appointment> GetAppointmentsInTimeFrame(DateTime startTime, DateTime endTime, Doctor doctor, Model.Rooms.Room room);

        bool AddAppointment(ref Model.Appointments.Appointment appoinment, Model.Rooms.RoomType roomType, Model.Roles.Doctor doctor);

        bool EditAppoinment(Model.Appointments.Appointment appoinment);

        bool DeleteAppoinment(Model.Appointments.Appointment appoinment);

        void SetStrategy(IAppointmentRecommendationStrategy strategy);

        List<Term> RecommendAppointments(DateTime startDateTime, DateTime endDateTime, Model.Roles.Doctor doctor);

    }
}