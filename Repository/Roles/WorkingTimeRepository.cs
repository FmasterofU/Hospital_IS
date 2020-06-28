// File:    WorkingTimeRepository.cs
// Author:  fmaster
// Created: Sunday, May 24, 2020 11:16:46 AM
// Purpose: Definition of Class WorkingTimeRepository

using Class_Diagram.Repository;
using Model.Roles;
using System;
using System.Collections.Generic;

namespace Repository.Roles
{
    public class WorkingTimeRepository : IWorkingTimeRepository

    //Id,StaffId,StartTime,EndTime,Timestamp

    {
        private string path = @"../../Data/working_time.csv";
        private static WorkingTimeRepository instance = null;

        private WorkingTimeRepository() { }

        public static WorkingTimeRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkingTimeRepository();
            }

            return instance;
        }

        public List<WorkingTime> GetAllByStaff(Staff staff)
        {
            List<string[]> ids = Persistence.ReadEntryByKey(path, staff.GetId().ToString(), 1);
            List<WorkingTime> ret = new List<WorkingTime>();
            foreach (string[] s in ids)
            {
                ret.Add(Read(uint.Parse(s[0])));
            }

            return ret;
        }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public WorkingTime Create(WorkingTime item)
        {
            string[] data = new string[5];
            item.SetId(Persistence.GetNewId(path));
            data[0] = item.GetId().ToString();
            data[1] = item.IdStaff.ToString();
            data[2] = item.StartTime.Ticks.ToString();
            data[3] = item.EndTime.Ticks.ToString();
            data[4] = item.Timestamp.Ticks.ToString();
            bool isAdded = Persistence.WriteEntry(path, data);
            if (isAdded)
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public WorkingTime Read(uint id)
        {
            List<string[]> data = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            if (data.Count == 1)
            {
                uint wtID = uint.Parse(data[0][0]);
                uint staffID = uint.Parse(data[0][1]);
                Staff s = (Staff)PeopleRepository.GetInstance().Read(staffID);
                DateTime startTime = new DateTime(long.Parse(data[0][2]));
                DateTime endTime = new DateTime(long.Parse(data[0][3]));
                DateTime timestamp = new DateTime(long.Parse(data[0][4]));

                WorkingTime ret = new WorkingTime(timestamp, startTime, endTime, staffID, s);
                ret.SetId(wtID);
                return ret;
            }
            return null;
        }

        public WorkingTime Update(WorkingTime item)
        {
            throw new NotImplementedException();
        }

        public List<WorkingTime> GetAll()
        {
            List<string> ids = Persistence.ReadAllPrimaryIds(path);
            List<WorkingTime> ret = new List<WorkingTime>();
            foreach (string s in ids)
            {
                ret.Add(Read(uint.Parse(s)));
            }

            return ret;
        }
    }
}