// File:    AppointmentService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Class AppointmentService

using Model.Appointments;
using Model.Roles;
using Model.Rooms;
using Repository.Roomsninventory;
using Repository.Schedule;
using System;
using System.Collections.Generic;

namespace Service
{
   public class AppointmentService : IAppointmentService
   {
      public IAppointmentRecommendationStrategy iAppointmentRecommendationStrategy;

        public bool AddAppointment(ref Appointment appoinment, RoomType roomType, Doctor doctor)
        {
            appoinment.doctor = doctor;
            List<Room> rooms = RoomRepository.GetInstance().GetAllByType(roomType);
            List<Appointment> appointments = AppointmentRepository.GetInstance().GetExistingAppointmentsInSpan(appoinment.StartTime, appoinment.EndTime);
            HashSet<Room> roomSet = new HashSet<Room>();
            foreach(Appointment apps in appointments)
            {
                roomSet.Add(apps.room);
            }
            foreach(Room room in rooms)
            {
                if(!roomSet.Contains(room))
                {
                    appoinment.room = room;
                    AppointmentRepository.GetInstance().Create(appoinment);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteAppoinment(Appointment appoinment)
        {
            return AppointmentRepository.GetInstance().Delete(appoinment.GetId());
        }

        public bool EditAppoinment(Appointment appoinment)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsInTimeFrame(DateTime startTime, DateTime endTime, Doctor doctor, Room room)
        {
            List<Appointment> appointments = AppointmentRepository.GetInstance().GetExistingAppointmentsInSpan(startTime, endTime);
            if (doctor == null && room == null) return appointments;
            else if(doctor == null && room != null)
            {
                List<Appointment> ret = new List<Appointment>();
                foreach (Appointment apps in appointments)
                {
                    if (apps.room.GetId() == room.GetId()) ret.Add(apps);
                }
                return ret;
            }
            else if(doctor != null && room == null)
            {
                List<Appointment> ret = new List<Appointment>();
                foreach (Appointment apps in appointments)
                {
                    if (apps.doctor.GetId() == doctor.GetId()) ret.Add(apps);
                }
                return ret;
            }
            else
            {
                List<Appointment> ret = new List<Appointment>();
                foreach (Appointment apps in appointments)
                {
                    if (apps.doctor.GetId() == doctor.GetId() && apps.room.GetId() == room.GetId()) ret.Add(apps);
                }
                return ret;
            }

        }

        public List<Appointment> RecommendAppointments(DateTime startDateTime, DateTime endDateTime, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void SetStrategy(IAppointmentRecommendationStrategy strategy)
        {
            throw new NotImplementedException();
        }
    }
}