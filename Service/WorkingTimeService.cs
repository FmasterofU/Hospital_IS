// File:    WorkingTimeService.cs
// Author:  fmaster
// Created: Tuesday, June 23, 2020 9:00:07 PM
// Purpose: Definition of Class WorkingTimeService

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Service
{
    public class WorkingTimeService : IWorkingTimeService
    {
        public bool AddWorkingTime(WorkingTime workingTime)
        {
            throw new NotImplementedException();
        }

        public List<WorkingTime> GetAllWorkingTimes(Staff staff)
        {
            throw new NotImplementedException();
        }

        public WorkingTime GetCurrentWorkingTime(Staff staff)
        {
            throw new NotImplementedException();
        }

        public double GetWorkHours(Staff staff, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public WorkingTime GetWorkingTimeForDate(DateTime date, Staff staff)
        {
            throw new NotImplementedException();
        }
    }
}