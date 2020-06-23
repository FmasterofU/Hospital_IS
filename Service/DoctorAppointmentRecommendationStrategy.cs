// File:    DoctorAppointmentRecommendationStrategy.cs
// Author:  fmaster
// Created: Tuesday, June 23, 2020 6:13:05 PM
// Purpose: Definition of Class DoctorAppointmentRecommendationStrategy

using Model.Appointments;
using Model.Roles;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DoctorAppointmentRecommendationStrategy : IAppointmentRecommendationStrategy
    {
        public List<Appointment> RecommendAppointments(DateTime startDateTime, DateTime endDateTime, Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}