// File:    AppointmentRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:34:03 PM
// Purpose: Definition of Class AppointmentRepository

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
            throw new NotImplementedException();
        }

        public List<Appointment> GetAvailableAppointmentsInSpan(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}