// File:    ILeaveController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:30:59 PM
// Purpose: Definition of Interface ILeaveController

using Model.Roles;
using System.Collections.Generic;

namespace Controller
{
    public interface ILeaveController
    {
        List<Leave> GetLeavesByStaff(Model.Roles.Staff staff);

        bool AddLeave(Model.Roles.Leave leave);

    }
}