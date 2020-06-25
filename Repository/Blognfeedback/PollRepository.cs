// File:    PollRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:17:12 PM
// Purpose: Definition of Class PollRepository

using Model.Blognfeedback;
using System;
using System.Collections.Generic;

namespace Repository.Blognfeedback
{
   public class PollRepository : Repository.IRepositoryCRUD<Poll, uint>
   {
      private string path;
      private static PollRepository instance = null;

        private PollRepository() {}
      
      public static PollRepository GetInstance()
      {
            if (instance == null) instance = new PollRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public Poll Create(Poll item)
        {
            throw new NotImplementedException();
        }

        public Poll Read(uint id)
        {
            throw new NotImplementedException();
        }

        public Poll Update(Poll item)
        {
            throw new NotImplementedException();
        }

        public List<Poll> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}