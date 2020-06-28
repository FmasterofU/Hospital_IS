// File:    IWorkingTimeRepository.cs
// Author:  fmaster
// Created: Sunday, May 31, 2020 9:27:21 AM
// Purpose: Definition of Interface IWorkingTimeRepository

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Repository.Roles
{
   public interface IWorkingTimeRepository : Repository.IRepositoryCRUD<WorkingTime, uint>
   {
      List<WorkingTime> GetAllByStaff(Model.Roles.Staff staff);
   
   }
}