// File:    TimePeriodAppointmentRecommendationStrategy.cs
// Author:  fmaster
// Created: Tuesday, June 23, 2020 6:13:05 PM
// Purpose: Definition of Class TimePeriodAppointmentRecommendationStrategy

using Class_Diagram.Model.Appointments;
using Model.Appointments;
using Model.Roles;
using System;
using System.Collections.Generic;

namespace Service
{
    public class TimePeriodAppointmentRecommendationStrategy : IAppointmentRecommendationStrategy
    {
        public List<Term> RecommendAppointments(DateTime startDateTime, DateTime endDateTime, Doctor doctor)
        {
            AppointmentService service = new AppointmentService();
            return service.GetAvailableInTimeFrame(startDateTime, endDateTime, null);
        }
    }
}