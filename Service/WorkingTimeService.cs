// File:    WorkingTimeService.cs
// Author:  fmaster
// Created: Tuesday, June 23, 2020 9:00:07 PM
// Purpose: Definition of Class WorkingTimeService

using Model.Roles;
using Repository.Roles;
using System;
using System.Collections.Generic;

namespace Service
{
    public class WorkingTimeService : IWorkingTimeService
    {
        public bool AddWorkingTime(WorkingTime workingTime)
        {
            WorkingTime adding = WorkingTimeRepository.GetInstance().Create(workingTime);
            //TODO: check ret val
            return true;
        }

        public List<WorkingTime> GetAllWorkingTimes(Staff staff)
        {
            return WorkingTimeRepository.GetInstance().GetAllByStaff(staff);
        }

        public WorkingTime GetCurrentWorkingTime(Staff staff)
        {
            List<WorkingTime> all = GetAllWorkingTimes(staff);
            WorkingTime ret = all[0];
            long min = Math.Abs(DateTime.Now.Ticks - all[0].Timestamp.Ticks);
            long diff;
            foreach (WorkingTime time in all)
            {
                diff = Math.Abs(DateTime.Now.Ticks - time.Timestamp.Ticks);
                if (diff < min)
                {
                    min = diff;
                    ret = time;
                }
            }
            return ret;
        }

        public double GetWorkHours(Staff staff, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public WorkingTime GetWorkingTimeForDate(DateTime date, Staff staff)
        {
            List<WorkingTime> all = GetAllWorkingTimes(staff);
            List<WorkingTime> timesBefore = new List<WorkingTime>();
            foreach(WorkingTime wt in all)
            {
                if(DateTime.Compare(date, wt.Timestamp) > 0)
                {
                    timesBefore.Add(wt);
                }
            }
            if (timesBefore.Count == 0) return null;
            WorkingTime ret = timesBefore[0];
            long min = Math.Abs(DateTime.Now.Ticks - timesBefore[0].Timestamp.Ticks);
            long diff;
            foreach (WorkingTime time in timesBefore)
            {
                diff = Math.Abs(date.Ticks - time.Timestamp.Ticks);
                if (diff < min)
                {
                    min = diff;
                    ret = time;
                }
            }
            return ret;
        }
    }
}