// File:    WorkingTimeController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:05 PM
// Purpose: Definition of Class WorkingTimeController

using Model.Roles;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class WorkingTimeController : IWorkingTimeController
   {
      public Service.IWorkingTimeService iWorkingTimeService = new WorkingTimeService();

        public bool AddWorkingTime(WorkingTime workingTime)
        {
            return iWorkingTimeService.AddWorkingTime(workingTime);
        }

        public List<WorkingTime> GetAllWorkingTimes(Staff staff)
        {
            return iWorkingTimeService.GetAllWorkingTimes(staff);
        }

        public WorkingTime GetCurrentWorkingTime(Staff staff)
        {
            return iWorkingTimeService.GetCurrentWorkingTime(staff);
        }

        public double GetWorkHours(Staff staff, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public WorkingTime GetWorkingTimeForDate(DateTime date, Staff staff)
        {
            return iWorkingTimeService.GetWorkingTimeForDate(date, staff);
        }
    }
}