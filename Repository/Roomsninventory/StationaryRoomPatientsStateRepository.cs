// File:    StationaryRoomPatientsStateRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:08:39 PM
// Purpose: Definition of Class StationaryRoomPatientsStateRepository

using Class_Diagram.Repository;
using Model.Rooms;
using System;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
    public class StationaryRoomPatientsStateRepository : IStationaryRoomPatientsStateRepository

    //Id,RoomId,PatientsNumber,Timestamp

    {
        private string path = @"../../Data/stationary_room_patients_state.csv";
        private static StationaryRoomPatientsStateRepository instance = null;

        private StationaryRoomPatientsStateRepository() { }

        public static StationaryRoomPatientsStateRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new StationaryRoomPatientsStateRepository();
            }

            return instance;
        }

        public List<StationaryRoomPatientsState> GetAllByRoom(StationaryRoom room)
        {
            List<string[]> ids = Persistence.ReadEntryByKey(path, room.GetId().ToString(), 1);
            List<StationaryRoomPatientsState> srps = new List<StationaryRoomPatientsState>();
            foreach (string[] s in ids)
            {
                srps.Add(Read(uint.Parse(s[0])));
            }

            return srps;
        }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public StationaryRoomPatientsState Create(StationaryRoomPatientsState item)
        {
            string[] data = new string[4];
            item.SetId(Persistence.GetNewId(path));
            data[0] = item.GetId().ToString();
            data[1] = item.RoomId.ToString();
            data[2] = item.PatientsNumber.ToString();
            data[3] = item.Timestamp.Ticks.ToString();
            if (Persistence.WriteEntry(path, data))
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public StationaryRoomPatientsState Read(uint id)
        {
            List<string[]> data = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            return new StationaryRoomPatientsState(uint.Parse(data[0][0]), new DateTime(long.Parse(data[0][3])), uint.Parse(data[0][2]), uint.Parse(data[0][1]));
        }

        public StationaryRoomPatientsState Update(StationaryRoomPatientsState item)
        {
            string[] data = new string[4];
            data[0] = item.GetId().ToString();
            data[1] = item.RoomId.ToString();
            data[2] = item.PatientsNumber.ToString();
            data[3] = item.Timestamp.Ticks.ToString();
            if (Persistence.EditEntry(path, data))
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public List<StationaryRoomPatientsState> GetAll()
        {
            List<string> ids = Persistence.ReadAllPrimaryIds(path);
            List<StationaryRoomPatientsState> srps = new List<StationaryRoomPatientsState>();
            foreach (string s in ids)
            {
                srps.Add(Read(uint.Parse(s)));
            }

            return srps;
        }
    }
}