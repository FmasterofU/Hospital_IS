// File:    ILeaveService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Interface ILeaveService

using Model.Roles;
using System.Collections.Generic;

namespace Service
{
    public interface ILeaveService
    {
        List<Leave> GetLeavesByStaff(Model.Roles.Staff staff);

        bool AddLeave(Model.Roles.Leave leave);

    }
}