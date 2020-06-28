// File:    ILeaveRepository.cs
// Author:  fmaster
// Created: Sunday, May 31, 2020 9:27:23 AM
// Purpose: Definition of Interface ILeaveRepository

using Model.Roles;
using System.Collections.Generic;

namespace Repository.Roles
{
    public interface ILeaveRepository : Repository.IRepositoryCRUD<Leave, uint>
    {
        List<Leave> GetAllByStaff(Model.Roles.Staff staff);

    }
}