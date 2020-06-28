// File:    AppointmentRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:34:03 PM
// Purpose: Definition of Class AppointmentRepository

using Class_Diagram.Model.Appointments;
using Class_Diagram.Repository;
using Model.Appointments;
using Model.Blognfeedback;
using Model.Roles;
using Model.Rooms;
using Repository.Blognfeedback;
using Repository.Roles;
using Repository.Roomsninventory;
using System;
using System.Collections.Generic;

namespace Repository.Schedule
{
   public class AppointmentRepository : IAppointmentRepository

        //Id,startTime,endTime,medicalRecordId,DoctorId,RoomId,ServiceCommentId


    {
        private string path = @"../../Data/appointment.csv";
        private static AppointmentRepository instance = null;

        public const int ID_COLUMN = 0; public const int START_TIME_COLUMN = 1; public const int END_TIME_COLUMN = 2; public const int MEDICAL_RECORD_ID_COLUMN = 3;
        public const int DOCTOR_ID_COLUMN = 4; public const int ROOM_ID_COLUMN = 5; public const int SERVICE_COMMENT_ID_COLUMN = 6;
        public const int START_OF_WORKING_TIME_HOURS = 7; public const int START_OF_WORKING_TIME_MINUTE = 0; public const int END_OF_WORKING_TIME_HOURS = 22; public const int END_OF_WORKING_TIME_MINUTE = 0;
        public const int APPOINTMENT_DURATION = 30;


        private AppointmentRepository() {}
      
      public static AppointmentRepository GetInstance()
      {
            if (instance == null) instance = new AppointmentRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public Appointment Create(Appointment item)
        {
            string[] data = new string[7];
            data[0] = Persistence.GetNewId(path).ToString();
            item.SetId(uint.Parse(data[0]));
            data[1] = item.StartTime.Ticks.ToString();
            data[2] = item.EndTime.Ticks.ToString();
            data[3] = item.MedicalRecordId.ToString();
            data[4] = item.doctor.GetId().ToString();
            data[5] = item.room.GetId().ToString();
            if (item.serviceComment != null) data[6] = item.serviceComment.GetId().ToString();
            bool isAdded = Persistence.WriteEntry(path, data);
            if (isAdded) return item;
            else return null;
        }

        public Appointment Read(uint id)
        {
            List<string[]> data = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            if (data.Count == 1)
            {
                uint appID = uint.Parse(data[0][0]);
                DateTime startTime = new DateTime(long.Parse(data[0][1]));
                DateTime endTime = new DateTime(long.Parse(data[0][2]));
                uint mrID = uint.Parse(data[0][3]);
                uint docID = uint.Parse(data[0][4]);
                Doctor d = (Doctor)PeopleRepository.GetInstance().Read(docID);
                uint roomID = uint.Parse(data[0][5]);
                //TODO: room read
                Room r = RoomRepository.GetInstance().Read(roomID);
                uint commID = uint.Parse(data[0][6]);
                //TODO: comment read
                ServiceComment comm = ServiceCommentRepository.GetInstance().Read(commID);

                Appointment ret = new Appointment(startTime, endTime, mrID, d, r, comm);
                ret.SetId(appID);
                return ret;
            }
            return null;
        }

        public Appointment Update(Appointment item)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetExistingAppointmentsInSpan(DateTime start, DateTime end)
        {
            List<string> allIds = Persistence.ReadAllPrimaryIds(path);
            List<Appointment> ret = new List<Appointment>();
            foreach(string id in allIds)
            {
                Appointment appointment = Read(uint.Parse(id));
                if (appointment.StartTime>=start && appointment.EndTime<=end)
                    ret.Add(appointment);
            }
            return ret;
        }

        public List<Term> GetAvailableAppointmentsInSpan(DateTime start, DateTime end)
        {
            List<Appointment> existingAppointment = GetExistingAppointmentsInSpan(start, end);
            DateTime appointment = start;
            List<Term> availableTerms = new List<Term>();

            int examRoomCount = RoomRepository.GetInstance().GetAllByType(RoomType.examRoom).Count;

            while (appointment < end)
            {
                if (IsWorkingTime(appointment))
                {
                    int freeRooms = examRoomCount;
                    foreach (Appointment reservedAppointment in existingAppointment)
                    {
                        if (reservedAppointment.StartTime.Equals(appointment))
                            freeRooms--;
                    }
                    if (freeRooms > 0)
                        availableTerms.Add(new Term(appointment, appointment.AddMinutes(APPOINTMENT_DURATION)));
                }
                appointment.AddMinutes(APPOINTMENT_DURATION);
            }
            return availableTerms;
        }

        private bool IsWorkingTime(DateTime date)
        {
            DateTime startTime = new DateTime(date.Year, date.Month, date.Day, START_OF_WORKING_TIME_HOURS, START_OF_WORKING_TIME_MINUTE, 0);
            DateTime endTime = new DateTime(date.Year, date.Month, date.Day, END_OF_WORKING_TIME_HOURS, END_OF_WORKING_TIME_MINUTE, 0);
            return date >= startTime && date <= endTime.AddMinutes(-APPOINTMENT_DURATION);
        }
    }
}
