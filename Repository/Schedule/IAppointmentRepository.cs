// File:    IAppointmentRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:34:03 PM
// Purpose: Definition of Interface IAppointmentRepository

using Class_Diagram.Model.Appointments;
using Model.Appointments;
using System;
using System.Collections.Generic;

namespace Repository.Schedule
{
   public interface IAppointmentRepository : Repository.IRepositoryCRUD<Appointment, uint>
   {
      List<Appointment> GetExistingAppointmentsInSpan(DateTime start, DateTime end);

      List<Term> GetAvailableAppointmentsInSpan(DateTime start, DateTime end);

    }
}