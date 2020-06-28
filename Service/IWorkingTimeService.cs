// File:    IWorkingTimeService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Interface IWorkingTimeService

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Service
{
    public interface IWorkingTimeService
    {
        Model.Roles.WorkingTime GetWorkingTimeForDate(DateTime date, Model.Roles.Staff staff);

        double GetWorkHours(Model.Roles.Staff staff, DateTime startDate, DateTime endDate);

        Model.Roles.WorkingTime GetCurrentWorkingTime(Model.Roles.Staff staff);

        List<WorkingTime> GetAllWorkingTimes(Model.Roles.Staff staff);

        WorkingTime AddWorkingTime(Model.Roles.WorkingTime workingTime);

    }
}