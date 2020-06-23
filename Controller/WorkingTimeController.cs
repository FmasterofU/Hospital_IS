// File:    WorkingTimeController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:05 PM
// Purpose: Definition of Class WorkingTimeController

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class WorkingTimeController : IWorkingTimeController
   {
      public Service.IWorkingTimeService iWorkingTimeService;

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