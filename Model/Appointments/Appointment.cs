// File:    Appointment.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Appointment

using Model.Blognfeedback;
using Model.Roles;
using Model.Rooms;
using System;

namespace Model.Appointments
{
    public class Appointment : Repository.IIdentifiable<uint>
    {
        private DateTime startTime;
        private DateTime endTime;
        private uint id;
        private uint medicalRecordId;

        public Appointment(DateTime startTime, DateTime endTime, uint medicalRecordId, Doctor doctor = null, Room room = null, ServiceComment serviceComment = null)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            id = 0;
            this.medicalRecordId = medicalRecordId;
            this.doctor = doctor;
            this.room = room;
            this.serviceComment = serviceComment;
        }

        public DateTime StartTime
        {
            get => startTime;
            set => startTime = value;
        }

        public DateTime EndTime
        {
            get => endTime;
            set => endTime = value;
        }

        public uint MedicalRecordId
        {
            get => medicalRecordId;
            set => medicalRecordId = value;
        }

        public Model.Roles.Doctor doctor;
        public Model.Rooms.Room room;
        public ServiceComment serviceComment;

        public uint GetId()
        {
            return id;
        }

        public void SetId(uint id)
        {
            this.id = id;
        }
    }
}