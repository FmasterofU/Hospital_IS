// File:    WorkingTimeRepository.cs
// Author:  fmaster
// Created: Sunday, May 24, 2020 11:16:46 AM
// Purpose: Definition of Class WorkingTimeRepository

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Repository.Roles
{
   public class WorkingTimeRepository : IWorkingTimeRepository
   {
      private string path;
      private static WorkingTimeRepository instance = null;

        private WorkingTimeRepository() {}
      
      public static WorkingTimeRepository GetInstance()
      {
            if (instance == null) instance = new WorkingTimeRepository();
            return instance;
      }

        public List<WorkingTime> GetAllByStaff(Staff staff)
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public WorkingTime Create(WorkingTime item)
        {
            throw new NotImplementedException();
        }

        public WorkingTime Read(uint id)
        {
            throw new NotImplementedException();
        }

        public WorkingTime Update(WorkingTime item)
        {
            throw new NotImplementedException();
        }

        public List<WorkingTime> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}