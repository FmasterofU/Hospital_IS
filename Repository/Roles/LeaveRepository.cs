// File:    LeaveRepository.cs
// Author:  fmaster
// Created: Saturday, May 23, 2020 10:32:05 PM
// Purpose: Definition of Class LeaveRepository

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Repository.Roles
{
   public class LeaveRepository : ILeaveRepository
   {
      private string path;
      private LeaveRepository instance;
      
      public static LeaveRepository GetInstance()
      {
         throw new NotImplementedException();
      }

        public List<Leave> GetAllByStaff(Staff staff)
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public Leave Create(Leave item)
        {
            throw new NotImplementedException();
        }

        public Leave Read(uint id)
        {
            throw new NotImplementedException();
        }

        public Leave Update(Leave item)
        {
            throw new NotImplementedException();
        }

        public List<Leave> GetAll()
        {
            throw new NotImplementedException();
        }

        public LeaveRepository leaveRepositoryB;
   
   }
}