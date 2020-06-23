// File:    IWorkingTimeController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:30:59 PM
// Purpose: Definition of Interface IWorkingTimeController

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Controller
{
   public interface IWorkingTimeController
   {
      Model.Roles.WorkingTime GetWorkingTimeForDate(DateTime date, Model.Roles.Staff staff);
      
      double GetWorkHours(Model.Roles.Staff staff, DateTime startDate, DateTime endDate);
      
      Model.Roles.WorkingTime GetCurrentWorkingTime(Model.Roles.Staff staff);
      
      List<WorkingTime> GetAllWorkingTimes(Model.Roles.Staff staff);
      
      bool AddWorkingTime(Model.Roles.WorkingTime workingTime);
   
   }
}