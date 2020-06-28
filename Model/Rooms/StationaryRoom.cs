// File:    StationaryRoom.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class StationaryRoom

using Model.Roles;
using System.Collections.Generic;

namespace Model.Rooms
{
    public class StationaryRoom : Room
    {
        private int capacity;

        public StationaryRoom(RoomType type, string name, List<ItemCount> itemCount, int capacity, List<Patient> patient,
                StationaryRoomPatientsState stationaryRoomPatientsState) : base(type, name, itemCount)
        {
            this.capacity = capacity;
            this.patient = patient;
            this.stationaryRoomPatientsState = stationaryRoomPatientsState;
        }

        public StationaryRoom(uint id, RoomType type, string name, List<ItemCount> itemCount, int capacity, List<Patient> patient,
                StationaryRoomPatientsState stationaryRoomPatientsState) : base(id, type, name, itemCount)
        {
            this.capacity = capacity;
            this.patient = patient;
            this.stationaryRoomPatientsState = stationaryRoomPatientsState;
        }

        public StationaryRoom(Room room, int capacity, List<Patient> patient,
                StationaryRoomPatientsState stationaryRoomPatientsState) : base(room)
        {
            this.capacity = capacity;
            this.patient = patient;
            this.stationaryRoomPatientsState = stationaryRoomPatientsState;
        }

        public int Capacity
        {
            get => capacity;
            set => capacity = value;
        }

        public System.Collections.Generic.List<Patient> patient;

        /// <summary>
        /// Property for collection of Model.Roles.Patient
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Patient> Patient
        {
            get
            {
                if (patient == null)
                {
                    patient = new System.Collections.Generic.List<Patient>();
                }

                return patient;
            }
            set
            {
                RemoveAllPatient();
                if (value != null)
                {
                    foreach (Model.Roles.Patient oPatient in value)
                    {
                        AddPatient(oPatient);
                    }
                }
            }
        }

        /// <summary>
        /// Add a new Model.Roles.Patient in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddPatient(Model.Roles.Patient newPatient)
        {
            if (newPatient == null)
            {
                return;
            }

            if (patient == null)
            {
                patient = new System.Collections.Generic.List<Patient>();
            }

            if (!patient.Contains(newPatient))
            {
                patient.Add(newPatient);
            }
        }

        /// <summary>
        /// Remove an existing Model.Roles.Patient from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemovePatient(Model.Roles.Patient oldPatient)
        {
            if (oldPatient == null)
            {
                return;
            }

            if (patient != null)
            {
                if (patient.Contains(oldPatient))
                {
                    patient.Remove(oldPatient);
                }
            }
        }

        /// <summary>
        /// Remove all instances of Model.Roles.Patient from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllPatient()
        {
            if (patient != null)
            {
                patient.Clear();
            }
        }
        public StationaryRoomPatientsState stationaryRoomPatientsState;

    }
}