// File:    DoctorAppointmentRecommendationStrategy.cs
// Author:  fmaster
// Created: Tuesday, June 23, 2020 6:13:05 PM
// Purpose: Definition of Class DoctorAppointmentRecommendationStrategy

using Class_Diagram.Model.Appointments;
using Model.Appointments;
using Model.Roles;
using Repository.Schedule;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DoctorAppointmentRecommendationStrategy : IAppointmentRecommendationStrategy
    {
        public List<Term> RecommendAppointments(DateTime startDateTime, DateTime endDateTime, Doctor doctor)
        {
            List<Term> free = AppointmentRepository.GetInstance().GetAvailableAppointmentsInSpan(startDateTime, endDateTime);
            if (doctor != null)
            {
                AppointmentService service = new AppointmentService();
                List<Appointment> all = service.GetAppointmentsInTimeFrame(startDateTime, endDateTime, doctor, null);
                List<Term> ret = new List<Term>();
                foreach (Term app in free)
                {
                    bool x = false;
                    foreach (Appointment appo in all)
                    {
                        if (DateTime.Compare(app.StartTime, appo.StartTime) == 0 && DateTime.Compare(app.EndTime, appo.EndTime) == 0)
                        {
                            x = true;
                            break;
                        }
                    }
                    if (!x) ret.Add(app);
                }
                return ret;
            }
            return free;
        }
    }
}