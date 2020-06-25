// File:    AppFeedbackRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:17:12 PM
// Purpose: Definition of Class AppFeedbackRepository

using Model.Blognfeedback;
using System;
using System.Collections.Generic;

namespace Repository.Blognfeedback
{
   public class AppFeedbackRepository : Repository.IRepositoryCRUD<AppFeedback, uint>
   {
      private string path;
      private static AppFeedbackRepository instance = null;

        private AppFeedbackRepository() {}
      
      public static AppFeedbackRepository GetInstance()
      {
            if (instance == null) instance = new AppFeedbackRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public AppFeedback Create(AppFeedback item)
        {
            throw new NotImplementedException();
        }

        public AppFeedback Read(uint id)
        {
            throw new NotImplementedException();
        }

        public AppFeedback Update(AppFeedback item)
        {
            throw new NotImplementedException();
        }

        public List<AppFeedback> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}