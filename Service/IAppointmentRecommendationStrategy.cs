// File:    IAppointmentRecommendationStrategy.cs
// Author:  fmaster
// Created: Tuesday, June 23, 2020 6:01:14 PM
// Purpose: Definition of Interface IAppointmentRecommendationStrategy

using Class_Diagram.Model.Appointments;
using Model.Appointments;
using System;
using System.Collections.Generic;

namespace Service
{
   public interface IAppointmentRecommendationStrategy
   {
      List<Term> RecommendAppointments(DateTime startDateTime, DateTime endDateTime, Model.Roles.Doctor doctor);
   
   }
}