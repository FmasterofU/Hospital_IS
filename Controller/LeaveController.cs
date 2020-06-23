// File:    LeaveController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:03 PM
// Purpose: Definition of Class LeaveController

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class LeaveController : ILeaveController
   {
      public Service.ILeaveService iLeaveService;

        public bool AddLeave(Leave leave)
        {
            throw new NotImplementedException();
        }

        public List<Leave> GetLeavesByStaff(Staff staff)
        {
            throw new NotImplementedException();
        }
    }
}