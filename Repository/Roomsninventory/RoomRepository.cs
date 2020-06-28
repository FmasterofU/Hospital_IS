// File:    RoomRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:30:38 PM
// Purpose: Definition of Class RoomRepository

using Class_Diagram.Repository;
using Model.Roles;
using Model.Rooms;
using Repository.Roles;
using System;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
   public class RoomRepository : IRoomRepository

        //Id,Type,Name,ItemCountIds,Capacity,PatientIds,stationaryRoomPatientsStateId

    {
        private string path = @"../../Data/room.csv";
        private static RoomRepository instance = null;

        private RoomRepository() {}
      
      public static RoomRepository GetInstance()
      {
            if (instance == null) instance = new RoomRepository();
            return instance;
      }

        public List<Room> GetAllByType(RoomType type)
        {
            List<string[]> ids = Persistence.ReadEntryByKey(path, type.ToString(), 1);
            List<Room> ret = new List<Room>();
            foreach (string[] s in ids)
                ret.Add(Read(uint.Parse(s[0])));
            return ret;
        }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public Room Create(Room item)
        {
            string[] temp = new string[7];
            item.SetId(Persistence.GetNewId(path));
            temp[0] = item.GetId().ToString();
            temp[1] = item.Type.ToString();
            temp[2] = item.Name;
            temp[3] = "";
            foreach (ItemCount ic in item.ItemCount)
                temp[3] += ic.GetId() + " ";
            temp[3] = temp[3].Trim();
            temp[4] = "";
            temp[5] = "";
            temp[6] = "";
            if (item.Type == RoomType.stationary)
            {
                StationaryRoom statRoom = item as StationaryRoom;
                temp[4] = statRoom.Capacity.ToString();
                foreach (Patient p in statRoom.Patient)
                    temp[5] += p.GetId().ToString() + " ";
                temp[5] = temp[5].Trim();
                temp[6] = statRoom.stationaryRoomPatientsState.GetId().ToString();
            }
            if (Persistence.WriteEntry(path, temp))
                return item;
            else return null;
        }

        public Room Read(uint id)
        {
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            string[] icids = temp[0][3].Split(' ');
            List<ItemCount> ics = new List<ItemCount>();
            foreach (string s in icids)
                ics.Add(ItemCountRepository.GetInstance().Read(uint.Parse(s)));
            Room room = new Room(uint.Parse(temp[0][0]), (RoomType)int.Parse(temp[0][1]), temp[0][2], ics);
            if ((RoomType)int.Parse(temp[0][1]) == RoomType.stationary)
            {
                string[] pids = temp[0][5].Split(' ');
                List<Patient> p = new List<Patient>();
                foreach (string s in pids)
                    p.Add(PeopleRepository.GetInstance().Read(s[0]) as Patient);
                return new StationaryRoom(room, int.Parse(temp[0][4]), p, StationaryRoomPatientsStateRepository.GetInstance().Read(uint.Parse(temp[0][6])));
            }
            else return room;
        }

        public Room Update(Room item)
        {
            string[] temp = new string[7];
            temp[0] = item.GetId().ToString();
            temp[1] = item.Type.ToString();
            temp[2] = item.Name;
            temp[3] = "";
            foreach (ItemCount ic in item.ItemCount)
                temp[3] += ic.GetId() + " ";
            temp[3] = temp[3].Trim();
            temp[4] = "";
            temp[5] = "";
            temp[6] = "";
            if (item.Type == RoomType.stationary)
            {
                StationaryRoom statRoom = item as StationaryRoom;
                temp[4] = statRoom.Capacity.ToString();
                foreach (Patient p in statRoom.Patient)
                    temp[5] += p.GetId().ToString() + " ";
                temp[5] = temp[5].Trim();
                temp[6] = statRoom.stationaryRoomPatientsState.GetId().ToString();
            }
            if (Persistence.EditEntry(path, temp))
                return item;
            else return null;
        }

        public List<Room> GetAll()
        {
            List<string> ids = Persistence.ReadAllPrimaryIds(path);
            List<Room> ret = new List<Room>();
            foreach (string s in ids)
                ret.Add(Read(uint.Parse(s)));
            return ret;
        }
   }
}